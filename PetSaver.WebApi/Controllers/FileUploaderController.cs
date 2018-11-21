using Newtonsoft.Json;
using PetSaver.Contracts.FineUploader;
using PetSaver.Exceptions;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers
{
    [Authorize]
    public class FileUploaderController : ApiController
    {
        // POST: api/FileUploader
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "A requisição não é um MimeMultipart."));
            }

            var rootPath = ConfigurationManager.AppSettings[Utilities.Constantes.PathFotosAnuncios] ?? string.Empty;

            if (string.IsNullOrEmpty(rootPath))
            {
                throw new BusinessException("O endereço da pasta raiz das fotos nos anúncios não está definido no config.");
            }

            Directory.CreateDirectory($"{rootPath}/temp");

            var provider = new MultipartFormDataStreamProvider($"{rootPath}/temp");

            var result = await Request.Content.ReadAsMultipartAsync(provider);

            var guidAnuncio = result.FormData["Guid"];

            Directory.CreateDirectory($"{rootPath}/{guidAnuncio}");

            if (!result.FileData.Any())
            {
                throw new BusinessException("Nenhuma imagem foi recebida.");
            }

            var file = result.FileData[0];

            if (!Utilities.MimeTypeHelper.MimeIsValid(file.Headers.ContentType.MediaType))
            {
                throw new BusinessException("O tipo de arquivo enviado não é válido.");
            }

            string extension = Utilities.MimeTypeHelper.GetExtension(file.Headers.ContentType.MediaType);

            var filePath = $"{rootPath}/{guidAnuncio}/{new Random().Next(0, 1000)}{extension}";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Move(file.LocalFileName, filePath);

            var objRetorno = JsonConvert.SerializeObject(new FineUploaderResponse
            {
                success = true
            });

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(objRetorno, System.Text.Encoding.UTF8, "text/plain")
            };
        }
    }
}
