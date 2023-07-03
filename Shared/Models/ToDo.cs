using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppWSAM.Shared.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int StatusId { get; set; }
        public string? StatusName { get; set; }

        [ForeignKey("StatusId")]
        public Status? Status { get; set; }
    }
}
