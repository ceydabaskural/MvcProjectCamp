using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        public int HeadingID { get; set; }
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }


        //Category sınıfında, Heading sınıfını ilişkilendirdik, şimdi burada Heading ile Category sınıfını ilişkilendirmemiz gerekiyor. Bunun için önce Category sınıfının anahtar sütunu olan CategoryId propertysini eklemekle başlıyoruz:
        public int CategoryID { get; set; } //ilişkilendirmenin ilk aşaması, sonra:

        //Category sınıfından Category isimli bir virtual property oluşturduk
        public virtual Category Category { get; set; }


        public ICollection<Content> Contents { get; set; }
    }
}
