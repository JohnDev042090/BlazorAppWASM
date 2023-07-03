using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppWSAM.Shared.Models
{
    public class ImageLibrary
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public string? FullPath { get; set; }
        public string? UniqueTitle { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
