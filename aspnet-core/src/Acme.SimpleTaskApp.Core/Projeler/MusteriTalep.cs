using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler
{
    public class MusteriTalep : FullAuditedEntity
    {
        public string MusteriIstek { get; set; }
        //public MusteriTalep()
        //{

        //    MusteriIstekTarihi = Clock.Now;

        //}
        public DateTime MusteriIstekTarihi { get; set; }
    }
}
