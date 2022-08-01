using Acme.SimpleTaskApp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto
{
    public class DeveloperDto
    {
        public User User { get; set; }

        public long UserId { get; set; }

        public string DeveloperName { get; set; }
        public string DeveloperSide { get; set; }

        public int DeveloperCommits { get; set; }

    }
}
