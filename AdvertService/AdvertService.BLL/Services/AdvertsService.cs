using AdvertService.BLL.DTOs;
using AdvertService.BLL.Services.Base;
using AdvertService.BLL.Services.Interfaces;
using AdvertService.DAL.Entities;
using AdvertService.DAL.Enums;
using AdvertService.DAL.Interfaces;
using AutoMapper;


namespace AdvertService.BLL.Services
{
    public class AdvertsService:BaseService, IAdvertService
    {
        public AdvertsService(IAdvertsRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
        }
        public async Task<List<AdvertDTO>> getAdverts()
        {
            var fitAdverts = await _advertsRepository.Get();
            List<AdvertDTO> advertsDTO = _mapper.Map<List<AdvertDTO>>(fitAdverts);
            return (advertsDTO);
        }

        public async Task<AdvertDTO> getAdvertById(int advertId)
        {
            Advert? advert = await _advertsRepository.GetById(advertId);
            if (advert == null) throw new KeyNotFoundException("Advert not found");

            AdvertDTO advertDTO = _mapper.Map<AdvertDTO>(advert);
            return advertDTO;
        }

        public async Task addAdvert(AdvertCreateRedoDTO advertToAdd)
        {
            Advert newAdvert = _mapper.Map<Advert>(advertToAdd);

            newAdvert.ownerId = "userID"; // here is hardcode
            await _advertsRepository.Add(newAdvert);
            await _advertsRepository.SaveChangesAsync();

        }
        public async Task MarkAsFinished(int advertId)
        {
            var advertInDb = await _advertsRepository.GetById(advertId);
            if (advertInDb == null) throw new KeyNotFoundException("Advert not found.");
            if (advertInDb.ownerId != "userID") throw new ArgumentException("You do not have the access."); //here is hardcode

            advertInDb.status = AdvertStatusEnum.finished;
            await _advertsRepository.Update(advertInDb);
            await _advertsRepository.SaveChangesAsync();
        }
        public async Task deleteAdvert(int advertId)
        {
            var advertInDb = await _advertsRepository.GetById(advertId);
            if (advertInDb == null) throw new KeyNotFoundException("Advert not found.");
            if (advertInDb.ownerId != "userID") throw new ArgumentException("You do not have the access."); //here is hardcode

            await _advertsRepository.Delete(advertInDb);
            await _advertsRepository.SaveChangesAsync();
        }
        public async Task updateAdvert(AdvertCreateRedoDTO newData, int advertId)
        {
            var advertInDb = await _advertsRepository.GetById(advertId);
            if (advertInDb == null) throw new KeyNotFoundException("Advert not found.");
            if (advertInDb.ownerId != "userID") throw new ArgumentException("You do not have the access."); //here is hardcode

            advertInDb = _mapper.Map(newData, advertInDb);

            await _advertsRepository.Update(advertInDb);
            await _advertsRepository.SaveChangesAsync();
        }
    }
}

