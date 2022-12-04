using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class Command
    {
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
