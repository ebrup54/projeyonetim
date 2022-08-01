using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Musteriler.MusteriTalep
{
    public class MusteriTalepDto
    {
        public int ProjeId { get; set; }
        public Proje proje { get; set; }
        public int MusteriTalepId { get; set; }
        public Musteri Musteri { get; set; }

        public string MusteriTalep { get; set; }
        public string MusteriAciklama { get; set; }
        public DateTime BaslangicTarih { get; set;}

        public DateTime BitisTarih { get; set; }

    }
}
