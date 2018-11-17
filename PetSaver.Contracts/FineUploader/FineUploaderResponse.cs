using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Contracts.FineUploader
{
    public class FineUploaderResponse
    {
        public bool Success { get; set; }
        public object ExtraInformation { get; set; }
    }
}
