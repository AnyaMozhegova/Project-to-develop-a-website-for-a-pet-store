using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Models
{
    public class Product
    {


        public int id { set; get; }

        [Display(Name = "Ввведите имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат имени продукта, можно вводить только кириллицу")]
        public string Name { set; get; }

        [Display(Name = "Ввведите короткое описание")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат описания, можно вводить только кириллицу")]
        public string ShortDes { set; get; }

        [Display(Name = "Ввведите короткое описание")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 70 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат описания, можно вводить только кириллицу")]

        public string LongDes { set; get; }


        [Display(Name = "Ввведите название производителя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат названия производителя, можно вводить только кириллицу")]
        public string Manufacturer { set; get; }


        [Display(Name = "Ввведите короткое описание")]
        public string image { set; get; }

        [Display(Name = "Ввведите цену")]
        
        [Range(0, int.MaxValue, ErrorMessage = "yearWork должен быть положительным числом")]
        public ushort price { set; get; }

      

        

        [Range(typeof(bool), "true", "true")]
        public bool? isFavourite { set; get; }


        
        [Range(typeof(bool), "true", "true")]
        public bool? Available { set; get; }

        [Display(Name = "Ввведите id")]
        
        [Range(0, int.MaxValue, ErrorMessage = "yearWork должен быть положительным числом")]
        public int CategoryId { set; get; }

        public virtual Category Category { set; get; }
    }
}
