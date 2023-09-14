using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForPerts.Data.Models
{
    public class Seller
    {
        public int Id { get; set; }


        [Display(Name = "Ввведите фамилию")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат фамилии, можно вводить только кириллицу")]
        public string? LastName { get; set; }

        [Display(Name = "Ввведите имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат имени, можно вводить только кириллицу")]
        public string? FirstName { get; set; }


        [Display(Name = "Ввведите отчество")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат отчества, можно вводить только кириллицу")]
        public string? MiddleName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }


        [Display(Name = "Ввведите номер телефона")]

        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Длина строки должна быть 11символов")]

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат телефона, можно вводить только цифры")]
        public string? Phone { get; set; }

        [Display(Name = "Ввведите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Длина строки должна быть от 6 до 50 символов")]

        public string? Email { get; set; }

        [Display(Name = "Ввведите пароль")]
        [StringLength(4)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Длина номера телефона не более 4 символов")]

        public string? Password { get; set; }




        [Range(typeof(bool), "true", "true")]
        public bool? isWork { set; get; }

        [Range(0, int.MaxValue, ErrorMessage = "yearWork должен быть положительным числом")]
        public int? yearWork { get; set; }
    }
}
