using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beletskaya.Library.Models
{
    public class Book
    {
        [Display(Name = "Id книги")]
        public int Id { get; set; }
        [Display(Name = "Название книги")]
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Издатель")]
        public string Publisher { get; set; }
        [Display(Name = "Год выпуска")]
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name}; Author: {Author}; Publisher: {Publisher}; Year: {Year}";
        }
    }
}