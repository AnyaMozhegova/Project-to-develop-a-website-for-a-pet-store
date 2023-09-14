using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopForPerts.Data.Models;


namespace ShopForPerts.Data
{
    public class DBOdjects
    {
        public static void Initial(AppDB content)

        {



            if (!content.Categories.Any())
                content.Categories.AddRange(Categoryq.Select(c => c.Value));
            if (!content.Products.Any())
            {
                content.AddRange(
                     new Product
                     {
                         Name = "Корм сухой JoY",
                         ShortDes = "Корм от компании JoY полезен для животных, так как содержит полезные витамины",
                         LongDes = "",
                         price = 400,
                         isFavourite = true,
                         Available = true,
                         image = "/img/1.png",
                         Category = Categoryq["Кошки"]
                     },
                     new Product
                     {
                         Name = "Лежанка",
                         ShortDes = "Такая лежанка станет прекрасным местом отдыха для вашего питомца",
                         LongDes = "",
                         price = 400,
                         isFavourite = true,
                         Available = true,
                         image = "/img/2.png",
                         Category = Categoryq["Кошки"]
                     },
                     new Product
                     {
                         Name = "Корм сухой",
                         ShortDes = "Корм, подходящий для котят",
                         LongDes = "",
                         price = 400,
                         isFavourite = false,
                         Available = true,
                         image = "/img/3.jpg",
                         Category = Categoryq["Кошки"]
                     },
                     new Product
                     {
                         Name = "Удочка Морковка",
                         ShortDes = "Веселая игрушка, которая точно станет любимицей",
                         LongDes = "",
                         price = 600,
                         isFavourite = false,
                         Available = true,
                         image = "/img/5.png",
                         Category = Categoryq["Кошки"]
                     },
                      new Product
                      {
                          Name = "Попона зимняя",
                          ShortDes = "В такой одежке собака точно не замерзнет",
                          LongDes = "",
                          price = 1000,
                          isFavourite = false,
                          Available = true,
                          image = "/img/6.jpg",
                          Category = Categoryq["Собаки"]
                      },
                       new Product
                       {
                           Name = "Гусь-обнимусь",
                           ShortDes = "Хорошая игрушка для любимой собаки",
                           LongDes = "",
                           price = 1200,
                           isFavourite = true,
                           Available = true,
                           image = "/img/7.jpg",
                           Category = Categoryq["Собаки"]
                       },
                       new Product
                       {
                           Name = "Дождевик L",
                           ShortDes = "Ваша собака больше не будет мокнуть",
                           LongDes = "",
                           price = 1500,
                           isFavourite = true,
                           Available = true,
                           image = "/img/8.jpg",
                           Category = Categoryq["Собаки"]
                       },
                        new Product
                        {
                            Name = "Корм 2кг ZILLII белая рыба с лососем",
                            ShortDes = "ZILLII- новая и интересная компания, производящая полезные лакомства ",
                            LongDes = "",
                            price = 500,
                            isFavourite = true,
                            Available = true,
                            image = "/img/9.jpg",
                            Category = Categoryq["Собаки"]
                        },
                         new Product
                         {
                             Name = "Корм 3кг ZILLII белая рыба с лососем",
                             ShortDes = "ZILLII- новая и интересная компания, производящая полезные лакомства ",
                             LongDes = "",
                             price = 500,
                             isFavourite = false,
                             Available = true,
                             image = "/img/9.jpg",
                             Category = Categoryq["Собаки"]
                         }



                         


                     );
                content.SaveChanges();


            }
            content.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categoryq
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{CategoryName="Собаки"},
                        new Category{CategoryName="Кошки"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }
        }
    }
}
