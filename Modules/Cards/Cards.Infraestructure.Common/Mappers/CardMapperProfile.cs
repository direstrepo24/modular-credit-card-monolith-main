using System.Text.RegularExpressions;
using AutoMapper;
using Cards.Domain;

namespace Cards.Infraestructure.Common;

public class CardMapperProfile: Profile
{
    public CardMapperProfile(){
        CreateMap<CardEntity, CardResponseDTO>();
            //.ForMember(a=>a.CardNumber,source => source.MapFrom(src => MaskNumber(src.CardNumber)));
        CreateMap<CreateCardRequestDTO, CardEntity>();
        CreateMap<UpdateCardRequestDTO, CardEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //ignora las propiedades nulas en el DTO.
    }

    private string MaskNumber(string CardNumber){
        var lastDigits = CardNumber.Substring(CardNumber.Length - 4);
        var digitsMask = lastDigits.PadLeft(CardNumber.Length, '*');
        digitsMask = Regex.Replace(digitsMask,".{4}", "$0 ");
        return digitsMask.Trim();
    }
}