using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApplication.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }

        [Required, Display(Name = "LessonName")]
        public string LessonName { get; set; }

        public string Details { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }

        public Product Product { get; set; }

        [NotMapped]
        public IFormFile Resources { get; set; }

    }
}
