using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShopForPerts.Data.Models
{
    public class Order
    {

        
        public int id { get; set; }

        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректное имя, можно вводить только кириллицу")]
        [Display(Name = "Ввведите имя")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]

        public string? name { get; set; }

        [Display(Name = "Ввведите фамилию")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат фамилии, можно вводить только кириллицу")]
        public string? surname { get; set; }

        [Display(Name = "Ввведите адрес")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        
        public string? adress { get; set; }

        [Display(Name = "Ввведите номер телефона")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не более 11 символов")]
      
        public string? phone { get; set; }

        [Display(Name = "Ввведите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 10 до 15 символов")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес почты")]
        public string? email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
