using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForPerts.Data.Models
{
    public class Manager
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
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не более 11 символов")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат телефона, можно вводить только цифры")]
        public string? Phone { get; set; }

        [Display(Name = "Ввведите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 20, ErrorMessage = "Длина строки должна быть от 20 до 50 символов")]
       
        public string? Email { get; set; }

        [Display(Name = "Ввведите пароль")]
        [StringLength(4)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Длина номера телефона не менее 4 символов")]
        
        public string? Password { get; set; }


        [Range(typeof(bool), "true", "true")]
        public bool? isWork { set; get; }


        [Range(0, int.MaxValue, ErrorMessage = "yearWork должен быть положительным числом")]
        public int? yearWork { get; set; }
    }
}
