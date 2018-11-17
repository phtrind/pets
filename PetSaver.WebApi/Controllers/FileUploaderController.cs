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
    public class FileUploaderController : ApiController
    {
        // POST: api/FileUploader
        public async Task<FineUploaderResponse> Post()
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

            return new FineUploaderResponse
            {
                Success = true,
                ExtraInformation = 123
            };
        }
    }
}
