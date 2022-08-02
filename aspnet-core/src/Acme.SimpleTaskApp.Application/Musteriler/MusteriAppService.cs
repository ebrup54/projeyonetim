using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.UI;
using Acme.SimpleTaskApp.Authorization;
using Acme.SimpleTaskApp.Authorization.Roles;
using Acme.SimpleTaskApp.Authorization.Users;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Projeler.Customers.CustomersDtos;
using Acme.SimpleTaskApp.Projeler.Gorevler.GorevlerDtos;
using Acme.SimpleTaskApp.Projeler.Musteriler.MusteriTalep;
using Acme.SimpleTaskApp.Roles.Dto;
using Acme.SimpleTaskApp.Users;
using Acme.SimpleTaskApp.Users.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Customers
{
    public class MusteriAppService : IMusteriAppService
    {
        private readonly IRepository<Musteri> _repository;
        private readonly IRepository<MusteriTalep> _talepRepository;
        public MusteriAppService(IRepository<Musteri> repository, IRepository<MusteriTalep> talepRepository)
        {
            _repository = repository;
            _talepRepository = talepRepository;
        }



        public async Task<List<MusteriDto>> GetMusteriList()
        {
            var entitylist = await _repository.GetAll().Include(a=>a.User).ToListAsync();
            

            return entitylist.Select(e => new MusteriDto
            {
                MusteriId = e.Id,
                MusteriAdi = e.MusteriAdi,
                Aciklama = e.Aciklama,
                Iletisim = e.Iletisim,
                UserId=e.User.Id,
                Username=e.User.UserName,
            }).ToList();
        }

        public async Task<MusteriDto> GetMusteriById(int musteriId)
        {
            var entity = await _repository.GetAll().Where(a => a.Id == musteriId).Include(a => a.User).FirstOrDefaultAsync();

            return new MusteriDto()
            {
                MusteriId=entity.Id,
                MusteriAdi=entity.MusteriAdi,
                //müşteriler usera gelince düzelecek
                //UserId=entity.User.Id,
                //Username = entity.User.UserName,
            };
        }

        public async Task<MusteriTalepDuzenleDto> MusteriTalepUpdate(int talepId)
        {
            var entity = await _talepRepository.GetAll().Where(a => a.Id == talepId).Include(a => a.musteri).Include(a => a.proje).FirstOrDefaultAsync();

            return new MusteriTalepDuzenleDto()
            {
                MusteriAciklama = entity.Aciklama,
                MusteriTalep = entity.Talep,
                BaslangicTarih = DateTime.Now,
                ProjeId = entity.ProjeId,
            };
        }

        public async Task MusteriEkle(MusteriEkleDto input)
        {          
                        
            if (string.IsNullOrEmpty(input.MusteriAdi))
            {
                throw new UserFriendlyException("Müsteri Adı Boş Olamaz");
            }
            var entity = new Musteri
            {
                MusteriAdi = input.MusteriAdi,
                Aciklama = input.Aciklama,
                Iletisim = input.Iletisim,   
                
            };
            await _repository.InsertAsync(entity);
        }
        



        public async Task MusteriGuncelle(MusteriGuncelleDto input)
        {
            //if (!input.CustomerId.HasValue || input.CustomerId == 0)
            //{
            //    throw new System.Exception("Proje Bulunamadı");
            //}
            if (string.IsNullOrEmpty(input.MusteriAdi))
            {
                throw new UserFriendlyException("Müşteri Adı Boş Olamaz");
            }
            if (!input.MusteriId.HasValue || input.MusteriId == 0)
            {
                throw new UserFriendlyException("Geçersiz Müşteri Id");
            }

            var entity = await _repository.GetAsync(input.MusteriId.Value);
            entity.MusteriAdi = input.MusteriAdi;
            entity.Aciklama = input.Aciklama;
            entity.Iletisim = input.Iletisim;         

            await _repository.UpdateAsync(entity);
        }

        public async Task MusteriTalepEkle(MusteriTalepEkleDto input)
        {
            if (input.ProjeId == 0)
            {
                throw new UserFriendlyException("Geçersiz Proje Id");
            }
            var entity = new MusteriTalep
            {
                MusteriId = input.Musteri.Id,
                ProjeId=input.ProjeId,
                Talep=input.MusteriTalep,
                Aciklama=input.MusteriAciklama,
                BaslamaTarih=DateTime.Now,

            };

            await _talepRepository.InsertAsync(entity);
        }
            public async Task DeleteMusteri(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
