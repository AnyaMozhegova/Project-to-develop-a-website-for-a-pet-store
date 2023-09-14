using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForPerts.Data.Models
{
    public class ChartWork
    {
        public int id { get; set; }
        [Display(Name = "Ввведите фамилию первого продавца")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"[А-Яа-я]", ErrorMessage = "Некорректный формат фамилии, можно вводить только кириллицу")]
        public string LastNameSeller1 { get; set; }

        [Display(Name = "Ввведите имя первого продавца")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"[А-Яа-я]", ErrorMessage = "Некорректный формат имени, можно вводить только кириллицу")]
        public string FirstNameSeller1 { get; set; }


        [Display(Name = "Ввведите отчетсво первого продавца")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"[А-Яа-я]", ErrorMessage = "Некорректный формат отчества, можно вводить только кириллицу")]
        public string MiddleNameSeller1 { get; set; }


        [Display(Name = "Ввведите фамилию второго продавца")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"[А-Яа-я]", ErrorMessage = "Некорректный формат фамилии, можно вводить только кириллицу")]
        public string LastNameSeller2 { get; set; }


        [Display(Name = "Ввведите имя второго продавца")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"[А-Яа-я]", ErrorMessage = "Некорректный формат имени, можно вводить только кириллицу")]
        public string FirstNameSeller2 { get; set; }


        [Display(Name = "Ввведите отчетсво второго продавца")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"[А-Яа-я]", ErrorMessage = "Некорректный формат отчетства, можно вводить только кириллицу")]
        public string MiddleNameSeller2 { get; set; }


        [Display(Name = "Ввведите описание")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"[А-Яа-я]", ErrorMessage = "Некорректное описание, можно вводить только кириллицу")]
        public string Desc { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime day { get; set; }
    }
}
