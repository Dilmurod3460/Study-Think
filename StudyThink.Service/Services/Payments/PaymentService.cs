using AutoMapper;
using StudyThink.DataAccess.Interfaces.Payments;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Payments;
using StudyThink.Domain.Exceptions.Payment;
using StudyThink.Service.DTOs.Payment;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Payments;

namespace StudyThink.Service.Services.Payments;

public class PaymentService : IPaymentService
{
    private IPaymentRepository _paymentRepository;
    private IFileService _fileService;
    private IMapper _mapper;
    public PaymentService(IPaymentRepository paymentRepository, IFileService fileService, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _fileService = fileService;
        _mapper = mapper;
    }
    public async ValueTask<long> CountAsync()
    {

        long count = await _paymentRepository.CountAsync();

        if (count == 0)
            throw new PaymentTypeException();
        return count;
    }

    public async ValueTask<bool> CreateAsync(PaymentCreationDto model)
    {
        Payment payment = _mapper.Map<Payment>(model);
        bool dbResult = await _paymentRepository.CreateAsync(payment);

        return dbResult;
    }

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        bool res = await _paymentRepository.DeleteAsync(Id);

        return res;
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> paymentIds)
    {

        foreach (var i in paymentIds)
        {
            Payment payment = await _paymentRepository.GetByIdAsync(i);

            if (payment != null)
            {
                await _paymentRepository.DeleteAsync(i);
            }
        }

        return true;
    }

    public async ValueTask<IEnumerable<Payment>> GetAllAsync(PaginationParams @params)
    {

        IEnumerable<Payment> payments = await _paymentRepository.GetAllAsync(@params);

        if (payments == null)
        {
            throw new PaymentTypeException();
        }
        else
        {
            return payments;
        }
    }

    public async ValueTask<Payment> GetByIdAsync(long Id)
    {
        Payment payment = await _paymentRepository.GetByIdAsync(Id);

        if (payment == null)
        {
            throw new PaymentTypeException();
        }
        return payment;
    }

    public async ValueTask<bool> UpdateAsync(PaymentUpdateDto model)
    {
        Payment payment = _mapper.Map<Payment>(model);
        var result = await _paymentRepository.UpdateAsync(payment);

        return result;
    }
}
