using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSignalR.Data.Models
{
    [Table("Chat")]
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }

        [Required]
        [StringLength(50)]
        public string Pseudo { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(20)]
        public string IP { get; set; }
    }
}
