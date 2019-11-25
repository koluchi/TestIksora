using EghteenPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EghteenPlus.DA
{
    public class EghteenPlusInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EPContext>
    {
        protected override void Seed(EPContext context)
        {
            var products = new List<Product>
            {
                new Product{ Id=Guid.NewGuid(), Name="Компактный мастурбатор", Descr="Мастурбатор-вагина Femme Fatale To Gо, 21см", Price=1555, Url="https://www.eroshop.ru/files/gallery/10739_skin_01.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Эрекционное кольцо", Descr="Эрекционное кольцо Eclipse Vibrating от ToyJoy, 3.3см", Price=3475, Url="https://www.eroshop.ru/files/gallery/10232_purple_01.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Стимулятор", Descr="Стимулятор Aura Double Stimulator от Toy Joy, 14.5 см", Price=4765, Url="https://www.eroshop.ru/files/gallery/10235_purple_01.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Кляп-шарик", Descr="Перламутровый кляп-шарик, 5см", Price=1205, Url="https://www.eroshop.ru/files/gallery/300539.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Фалоимитатор", Descr="Реалистик с выносным пультом, 20 см", Price=2535, Url="https://www.eroshop.ru/files/gallery/82954.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Фиксаторы для ног", Descr="Фиксаторы для ног", Price=885, Url="https://www.eroshop.ru/files/gallery/83070_25057.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Ошейник", Descr="Широкий ошейник со шнуровкой", Price=1995, Url="https://www.eroshop.ru/files/gallery/31271.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Свеча зажигания", Descr="Свеча зажигания для Chevrolet Lanos, 0242235663", Price=82, Url="https://static2.ixora-auto.ru/CatalogAccessories/Image2/CATALOG_PRODUCT_126134_150.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Втулка выжимного подшипника", Descr="Втулка выжимного подшипника PEUGEOT 207", Price=402, Url="https://static2.ixora-auto.ru/CatalogAccessories/Image2/CATALOG_PRODUCT_142228_150.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Палец суппорта", Descr="Палец суппорта HYUNDAI ix35, 5822237000", Price=124, Url="https://static2.ixora-auto.ru/CatalogAccessories/Image2/CATALOG_PRODUCT_136096_150.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Опора амортизатора с подшипником", Descr="Опора амортизатора с подшипником OPEL KADETT E, 21652299", Price=788, Url="https://static2.ixora-auto.ru/CatalogAccessories/Image2/CATALOG_PRODUCT_134220_150.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Наконечник рулевой левый", Descr="Наконечник рулевой левый для Honda Civic, CEHO6L", Price=659, Url="https://static2.ixora-auto.ru/CatalogAccessories/Image2/CATALOG_PRODUCT_131190_150.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Тяга рулевая", Descr="Тяга рулевая для Toyota Corolla E12, CRT54", Price=720, Url="https://static2.ixora-auto.ru/CatalogAccessories/Image2/CATALOG_PRODUCT_119316_150.jpg" },
                new Product{ Id=Guid.NewGuid(), Name="Пыльник пальца тормозного суппорта", Descr="Пыльник пальца тормозного суппорта KIA SORENTO", Price=114, Url="https://static2.ixora-auto.ru/CatalogAccessories/Image2/CATALOG_PRODUCT_136870_150.jpg" },
            };
            products.ForEach(product => context.Products.Add(product));
            context.SaveChanges();
        }
    }
}