using Abp.Domain.Repositories;
using Acme.SimpleTaskApp.Projeler.Developers.DevelopersDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Developers
{
    public class DevelopersAppService:IDevelopersAppService
    {
        private readonly IRepository<Developer> _repository;

        public DevelopersAppService(IRepository<Developer> repository)
        {
            _repository = repository;
        }

        public async Task<List<DeveloperDto>> GetDeveloperList()
        {
            var entity = await _repository.GetAll().Include(a => a.User).Skip(0).Take(10).ToListAsync();

            return entity.Select(e => new DeveloperDto
            {
                UserId = e.UserId,
                DeveloperName=e.DeveloperName,
                DeveloperSide=e.DeveloperSide,
                DeveloperCommits=e.DeveloperCommits,
            }
            ).ToList();
        }
    }
}
