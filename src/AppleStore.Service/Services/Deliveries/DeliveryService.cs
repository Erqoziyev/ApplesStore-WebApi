using AppleStore.DataAccess.Interfaces.Deliveries;
using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Deliveries;
using AppleStore.Domain.Exceptions.Deliveries;
using AppleStore.Service.Common.Helpers;
using AppleStore.Service.Dtos.Deliveries;
using AppleStore.Service.Interfaces.Common;
using AppleStore.Service.Interfaces.Deliveries;
using System.Runtime.Serialization;

namespace AppleStore.Service.Services.Deliveries;

public class DeliveryService : IDeliveryService
{
    private IDeliveryRepository _repository;
    private IFileService _fileservice;

    public DeliveryService(IDeliveryRepository deliveryRepository, IFileService fileService)
    {
        this._repository = deliveryRepository;
        this._fileservice = fileService;
    }
    public async Task<bool> CreateAsync(DeliveryCreateDto dto)
    {
        string ImagePath = await _fileservice.UploadImageAsync(dto.Avatar);
        Delivery delivery = new Delivery();
        delivery.FirstName = dto.FirstName;
        delivery.LastName = dto.LastName;
        delivery.PhoneNumber = dto.PhoneNumber;
        delivery.PassportSeria = dto.PassportSeriaNumber;
        delivery.Region = dto.Region;
        delivery.BirthDate = dto.BirthDate;
        delivery.IsMale = dto.IsMale;
        delivery.ImagePath = ImagePath;
        delivery.CreatedAt = delivery.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.CreateAsync(delivery);
        return dbResult > 0;
    }

    public async Task<bool> DeleteAsync(long deliveryId)
    {
        var delivery = await _repository.GetByIdAsync(deliveryId);
        if(delivery is null) throw new DeliveryNotFoundException();
        else
        {
            await _fileservice.DeleteImageAsync(delivery.ImagePath);
            var result = await _repository.DeleteAsync(deliveryId);
            return result > 0;
        }
    }

    public async Task<IList<Delivery>> GetAllAsync(PaginationParams @params)
    {
        var deliveries = await _repository.GetAllAsync(@params);
        return deliveries;
    }

    public async Task<Delivery> GetByIdAsync(long deliveryId)
    {
        var delivery = await _repository.GetByIdAsync(deliveryId);
        if (delivery is null) throw new DeliveryNotFoundException();
        else return delivery;
    }

    public async Task<bool> UpdateAsync(long deliveryId, DeliveryUpdateDto dto)
    {
        var delivery = await _repository.GetByIdAsync(deliveryId);
        if (delivery is null) throw new DeliveryNotFoundException();

        delivery.FirstName = dto.FirstName;
        delivery.LastName = dto.LastName;
        delivery.PhoneNumber = dto.PhoneNumber;
        delivery.PassportSeria = dto.PassportSeriaNumber;
        delivery.Region = dto.Region;
        delivery.BirthDate = dto.BirthDate;
        delivery.IsMale = dto.IsMale;

        if (dto.Avatar is not null)
        {
            await _fileservice.DeleteImageAsync(delivery.ImagePath);
            delivery.ImagePath = await _fileservice.UploadImageAsync(dto.Avatar);
        }

        delivery.UpdatedAt = TimeHelper.GetDateTime();

        var dbresult = await _repository.UpdateAsync(deliveryId, delivery);
        return dbresult > 0;
    }
}
