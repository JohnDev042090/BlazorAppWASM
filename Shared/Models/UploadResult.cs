using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppWSAM.Shared.Models
{
    public class UploadResult
    {
        public bool Uploaded { get; set; }
        public string? FileName { get; set; }
        public string? StoredFileName { get; set; }
        public string? Path { get; set; }
        public string? FullPath { get; set; }
        public int ErrorCode { get; set; }
    }
}
