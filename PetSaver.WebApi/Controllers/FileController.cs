using PetSaver.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PetSaver.WebApi.Controllers
{
    public class FileController : ApiController
    {
        // GET: api/File
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/File/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/File
        //[Route("api/FileaIdAnuncio}")]
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            //var path = HttpContext.Current.Server.MapPath("~/App_Data/Fotos");
            var path = @"D:\Documents\Git\pets\PetSaver.Site\anuncios";

            var provider = new MultipartFormDataStreamProvider(path);

            var result = await Request.Content.ReadAsMultipartAsync(provider);

            var model = result.FormData["jsonData"];

            //if (model == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}

            //TODO: Do something with the JSON data.  

            var cont = 1;

            //get the posted files  
            foreach (MultipartFileData file in result.FileData)
            {
                string extension = Utilities.MimeTypeHelper.GetExtension(file.Headers.ContentType.MediaType);

                if (File.Exists($"{path}/{cont}{extension}"))
                {
                    File.Delete($"{path}/{cont}{extension}");
                }

                File.Move(file.LocalFileName, $"{path}/{cont}{extension}");

                cont++;
            }

            return Request.CreateResponse(HttpStatusCode.OK, "success!");
        }

        // PUT: api/File/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/File/5
        public void Delete(int id)
        {
        }
    }
}
