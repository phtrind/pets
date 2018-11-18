using Newtonsoft.Json;
using PetSaver.Contracts.FineUploader;
using System;
using System.Collections.Generic;
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
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable,
                                                                       "This request is not properly formatted - not multipart."));
            }

            var path = @"D:\Documents\Git\pets\PetSaver.Site\anuncios";

            var provider = new MultipartFormDataStreamProvider(path);

            //READ CONTENTS OF REQUEST TO MEMORY WITHOUT FLUSHING TO DISK
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            var guidAnuncio = result.FormData["Guid"];
            var name = result.FormData["qquuid"];

            Directory.CreateDirectory($"{path}/{guidAnuncio}");

            var cont = 0;

            //get the posted files  
            foreach (MultipartFileData file in result.FileData)
            {
                string extension = Utilities.MimeTypeHelper.GetExtension(file.Headers.ContentType.MediaType);

                if (File.Exists($"{path}/{guidAnuncio}/{name}{extension}"))
                {
                    File.Delete($"{path}/{name}{extension}");
                }

                File.Move(file.LocalFileName, $"{path}/{guidAnuncio}/{name}{extension}");

                cont++;
            }

            var retorno = JsonConvert.SerializeObject(new FineUploaderResponse
            {
                success = true,
                extraInformation = 123
            });

            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(retorno, System.Text.Encoding.UTF8, "text/plain")
            };

            return resp;
        }
    }
}
