using System.Text.RegularExpressions;
using AutoMapper;
using Transaction.Domain;

namespace Transaction.Infraestructure.Common;

public class CardMapperProfile: Profile
{
    public CardMapperProfile(){
        CreateMap<TransactionEntity, TransactionResponseDTO>()
            .ForMember(a=>a.Type,source => source.MapFrom(src => src.Type.ToString()));
        CreateMap<CreateTransactionRequestDTO, TransactionEntity>();
    }
}