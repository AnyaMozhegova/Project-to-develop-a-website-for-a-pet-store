using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForPerts.Data.Models
{
    public class EndOfShift
    {
     
        public int id { get; set; }

        [Display(Name = "Ввведите инкассацию")]
       

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint collection { get; set; }


        [Display(Name = "Ввведите сумму безналичного рассчета")]
       

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint cashless { get; set; }

        [Display(Name = "Ввведите сумму наличного рассчета")]
        

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint cash { get; set; }


        [Display(Name = "Ввведите количество купюр 5000")]
       

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint banknote5000 { get; set; }

        [Display(Name = "Ввведите количество купюр 1000")]
       
        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint bankote1000 { get; set; }

        [Display(Name = "Ввведите количество купюр 500")]
        

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint bankote500 { get; set; }

        [Display(Name = "Ввведите количество купюр 100")]
       

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint bankote100 { get; set; }

        [Display(Name = "Ввведите количество купюр 50")]
       

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint bankote50 { get; set; }

        [Display(Name = "Ввведите количество мелочи")]
        

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint bankoteSmall { get; set; }

        [Display(Name = "Ввведите возврат")]
       

        [RegularExpression(@"^\d+$", ErrorMessage = "Некорректный формат, можно вводить только цифры")]
        public uint refund { get; set; }

        [Display(Name = "Ввведите фамилию первого продавца")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат фамилии, можно вводить только кириллицу")]
        public string seller1 { get; set; }

        [Display(Name = "Ввведите фамилию второго продавца")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Некорректный формат фамилии, можно вводить только кириллицу")]
        public string seller2 { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime day { get; set; }
    }
}
