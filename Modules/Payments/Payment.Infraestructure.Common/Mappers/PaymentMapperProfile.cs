using AutoMapper;
using Payment.Domain;
namespace Payment.Infraestructure.Common;

public class CardMapperProfile: Profile
{
    public CardMapperProfile(){
        CreateMap<PaymentEntity, PaymentResponseDTO>();
        CreateMap<CreatePaymentRequestDTO, PaymentEntity>();
    }
}