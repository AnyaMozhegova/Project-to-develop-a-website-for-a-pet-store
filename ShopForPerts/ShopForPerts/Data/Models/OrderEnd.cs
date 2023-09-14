using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForPerts.Data.Models
{
    public class OrderEnd
    {
       
        public int id { get; set; }

        [Display(Name = "Ввведите имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат имени, можно вводить только кириллицу")]
        public string? name { get; set; }

        [Display(Name = "Ввведите фамилию")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат фамилии, можно вводить только кириллицу")]
        public string? surname { get; set; }

        [Display(Name = "Ввведите адрес")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный адрес, можно вводить только кириллицу и цифры")]
        public string? adress { get; set; }

        [Display(Name = "Ввведите номер телефона")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не более 11 символов")]
        [Range(0, int.MaxValue, ErrorMessage = "yearWork должен быть положительным числом")]
        public string? phone { get; set; }

        [Display(Name = "Ввведите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 20, ErrorMessage = "Длина строки должна быть от 20 до 50 символов")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес почты")]
        public string? email { get; set; }

        [DataType(DataType.DateTime)]

        public DateTime orderTime { get; set; }


    }
}
