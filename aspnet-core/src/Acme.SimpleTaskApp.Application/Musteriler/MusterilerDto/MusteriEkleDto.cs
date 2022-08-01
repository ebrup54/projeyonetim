using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Customers.CustomersDtos
{
    public class MusteriEkleDto
    {
        public Proje proje { get; set; }

        public int ProjeId { get; set; }
        public int? MusteriId { get; set; }
        public string MusteriAdi { get; set; }
        public string Iletisim { get; set; }
        public string Aciklama { get; set; }

        public string MusteriIstek { get; set; }
        public DateTime MusteriIstekTarihi { get; set; }
    }
}
