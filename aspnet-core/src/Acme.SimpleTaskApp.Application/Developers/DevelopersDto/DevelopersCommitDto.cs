using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto.DevelopersDto
{
    public class DevelopersCommitDto
    {
        public Developer developer { get; set; }

        public Gorev gorev { get; set; }

        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }

        public int MyProperty { get; set; }
    }
}
