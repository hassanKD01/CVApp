using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVApp.Data
{
    public class CV
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        [Required]
        public char Gender { get; set; }
        public List<Skill> Skills { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string ImageName { get; set; }
    }
}
