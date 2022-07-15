using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class MailVM
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Enter Customer ")]
        public string Customer { get; set; }

        [Required(ErrorMessage = "Enter Title ")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter Massege ")]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        public string Massege { get; set; }
    }
}
