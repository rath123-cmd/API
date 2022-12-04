using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class CommandWriteModel
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
