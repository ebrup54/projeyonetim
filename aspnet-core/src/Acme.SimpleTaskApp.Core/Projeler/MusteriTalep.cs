using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler
{
    [Table("MusteriTalepler")]
    public class MusteriTalep: FullAuditedEntity
    {
        public string Talep { get; set; }

        public int ProjeId { get; set; }
        public Proje proje { get; set; }
        public string Aciklama { get; set; }

        public DateTime BaslamaTarih { get; set; }

        public DateTime BitisTarih { get; set; }

        public Musteri musteri { get; set; }


        [ForeignKey(nameof(MusteriId))]
        public int MusteriId { get; set; }
        //public MusteriTalep()
        //{
        //    BaslamaTarih = DateTime.Now;
        //}
    }
}
