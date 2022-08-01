﻿using Abp.Domain.Repositories;
using Abp.UI;
using Acme.SimpleTaskApp.Projeler.Projeler.ProjelerDtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler
{

    public class ProjeAppService : IProjeAppService
    {
        private readonly IRepository<Proje> _repository;
        private readonly IRepository<Musteri> _musteri;
        public ProjeAppService(IRepository<Proje> repository, IRepository<Musteri> musteri)
        {
            _repository = repository;
            _musteri = musteri;
        }




        public async Task<List<ProjeDto>> GetProjeList()
        {
            /*
                  Musterileri repositoryden ayrı olarak çekip musteriListten
                 Musteri bilgilerine ulasabiliriz

                     PS . Yigit
             */

            var entitylist = await _repository.GetAllListAsync();
            var musteriId = entitylist.FirstOrDefault().MusteriId;
            var musteriList = await _musteri.GetAsync(musteriId);

            return entitylist.Select(e => new ProjeDto
            {
                ProjeId = e.Id,
                ProjeAdi = e.ProjeAdi,
                Description = e.Description,
                BaslamaTarihi = e.BaslamaTarihi,
                Durum = e.Durum,
                BitisTarihi = e.BitisTarihi,
                MusteriAdi = musteriList.MusteriAdi
            }).ToList();
        }


        //Müşteri için Proje görüntüleme tablosu

        public async Task<List<Proje>> GetProjeListMusteri(int musteriId)
        {
            var entitylist = await _repository.GetAllListAsync();
            var proje = new List<Proje>();
            int Control = 0;
            foreach (var item in entitylist)
            {
                if (item.Id == musteriId)
                {
                    proje.Add(item);
                    Control++;
                }
            }
            if (Control > 0)
            {
                return proje.Select(e => new Proje
                {
                    ProjeAdi = e.ProjeAdi,
                    Description = e.Description,
                    BaslamaTarihi = e.BaslamaTarihi,
                    Durum = e.Durum,
                    MusteriBitisTarihi = e.MusteriBitisTarihi,
                }).ToList();

            }
            else
            {
                throw new UserFriendlyException("Projeniz Bulunmamaktadır");
            }
        }





        public async Task<Proje> ProjeEkle(ProjeEkleDto input)
        {
            if (string.IsNullOrEmpty(input.ProjeAdi))
            {
                throw new UserFriendlyException("Proje Adı Boş Olamaz");
            }


            var entity = new Proje
            {
                ProjeAdi = input.ProjeAdi,
                Description = input.Description,
                MusteriId = input.MusteriId,
            };
            return await _repository.InsertAsync(entity);
        }



        public async Task ProjeGuncelle(ProjeGuncelleDto input)
        {
            if (!input.ProjeId.HasValue || input.ProjeId == 0)
            {
                throw new UserFriendlyException("Geçersiz Proje Id");
            }
            if (string.IsNullOrEmpty(input.ProjeAdi))
            {
                throw new UserFriendlyException("Proje Adı Boş Olamaz");
            }
            if (!input.MusteriId.HasValue || input.MusteriId == 0)
            {
                throw new UserFriendlyException("Geçersiz Müşteri Id");
            }

            //-
            var entity = await _repository.GetAsync(input.ProjeId.Value);
            entity.ProjeAdi = input.ProjeAdi;
            entity.Description = input.Description;
            entity.BitisTarihi = input.BitisTarihi;
            entity.Durum = input.Durum;
            entity.MusteriBitisTarihi = input.MusteriBitisTarihi;

            await _repository.UpdateAsync(entity);

        }


        public async Task DeleteProje(int id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}