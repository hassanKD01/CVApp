using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Data
{
    
    public class Skill
    {
        public int ID { get; set; }

        [Required]
        [ForeignKey("CV")]
        public int CVId { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Language { get; set; }
    }
}
