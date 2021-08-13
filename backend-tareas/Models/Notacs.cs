using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend_tareas.Models
{
    public class Notacs
    {
        public int Id { get; set; }

        [Required]
        public string Descript { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
