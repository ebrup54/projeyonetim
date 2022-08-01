using Abp.Domain.Repositories;
using Abp.UI;
using Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Gorevler
{
    public class GorevAppService : IGorevAppService
    {
        private readonly IRepository<Gorev> _repository;
        private readonly IRepository<Proje> _proje;
      
        public GorevAppService(IRepository<Gorev> repository, IRepository<Proje> proje)
        {
            _repository = repository;
            _proje = proje;
        }





        public async Task<List<GorevDto>> GetGorevList()
        {
            var entitylist = await _repository.GetAllListAsync();
            return entitylist.Select(e => new GorevDto
            {
                GorevId = e.Id,
                GorevTanimi = e.GorevTanimi,
                ProjeID = e.ProjeID,
                BaslamaZamani = e.BaslamaZamani,
                DeveloperId = e.DeveloperId,



            }).ToList();
        }

        public async Task<GorevDto> GetGorevById(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(id);

            if (entity == null)
            {
                throw new UserFriendlyException("Geçersiz Gorev Id");
            }

            return new GorevDto()
            {
                GorevId = entity.Id,
                GorevTanimi = entity.GorevTanimi,
                ProjeID = entity.ProjeID,
                BaslamaZamani = entity.BaslamaZamani,
                DeveloperId = entity.DeveloperId
            };
        }

        public async Task<List<GorevDto>> GetGorevByProject(int projectId)
        {
            //if (projectId==null)
            //{
            //    throw new UserFriendlyException("Geçersiz Proje Id");
            //}

            var entityList = await _repository.GetAllListAsync(x => x.ProjeID == projectId);

            return entityList.Select(e => new GorevDto
            {
                GorevId = e.Id,
                GorevTanimi = e.GorevTanimi,
                ProjeID = e.ProjeID,
                BaslamaZamani = e.BaslamaZamani,
                DeveloperId = e.DeveloperId
            }).ToList();

        }

        public async Task GorevEkle(GorevEkleDto input)
        {
            if (!input.ProjeId.HasValue || input.ProjeId == 0)
            {
                throw new UserFriendlyException("Geçersiz Proje Id");
            }


            var entity = new Gorev
            {
                ProjeID = input.ProjeId,
                GorevTanimi = input.GorevTanimi,
                DeveloperId = input.DeveloperId,
                Durum = input.Durum,
                BaslamaZamani = input.BaslamaZamani,

            };
            await _repository.InsertAsync(entity);
        }




        public async Task GorevGuncelle(GorevGuncelleDto input)
        {
            if (!input.GorevId.HasValue || input.GorevId == 0)
            {
                throw new UserFriendlyException("Geçersiz Görev Id");
            }
            var entity = await _repository.GetAsync(input.GorevId.Value);
            entity.GorevTanimi = input.GorevTanimi;
            entity.Durum = input.Durum;
            entity.DeveloperId = input.DeveloperId;

            await _repository.UpdateAsync(entity);
        }
        




        public async Task DeleteGorev(int id)
        {
            await _repository.DeleteAsync(id);
        }

        //public void Deneme(int id)
        //{
        //    var gorev = _repository.Get(id);

        //    var dto = new GorevDto()
        //    {
        //        GorevAdi = gorev.GorevAdi,
        //        Developer = new UserDtoTest()
        //        {
        //            KullanciAdi = gorev.Developer.User.Name
        //        }
        //    };

        //}
    }
}
