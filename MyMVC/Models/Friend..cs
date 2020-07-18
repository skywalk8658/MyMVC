using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyMVC.Models
{
    public class Friend
    {

        public  int Id { get; set; }

        [Display(Name = "姓名")]
        public  string Name { get; set; }

        [Display(Name = "地址")]
        public string Addres { get; set; }

        [Display(Name = "電子信箱")]
        public string Email { get; set; }
    }
}