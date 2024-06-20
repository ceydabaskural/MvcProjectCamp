using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }


        //TABLO İLİŞKİLENDİRME
        //Property nin türü ICollection isminde bir koleksiyon olacak anlamına gelen 'ICollection' interface idir. Bu şu anlama gelir: Bu sınıfa ait bir koleksiyon oluşturmak istediğimiz anlamına gelir.
        //ICollection<T> : T değeri entity istediği anlamına gelir(yani ilişkilendirmek istediğimiz classın adı). Aşağıda Heading sınıfını kullandık.
        //Bu işlemi birde Heading class ında gerçekleştirmemiz gerekiyor.
        public ICollection<Heading> Headings { get; set; }
    }
}
