import { CardResponseDom, CreateCardRequestDom, UpdateCardRequestDom } from "@domain/cards";
import { CardResponseDto, CreateCardRequestDto, UpdateCardRequestDto } from "../dtos/card.dto";

export class CardMapper {
  static toDom(dto: CardResponseDto): CardResponseDom {
    return new CardResponseDom(
      dto.id,
      dto.cardNumber,
      dto.ownerName,
      dto.expirationdate
    );
  }

  static toCreateDto(dom: CreateCardRequestDom): CreateCardRequestDto {
    return <CreateCardRequestDto>{
      cardNumber: dom.cardNumber,
      ownerName: dom.ownerName,
      expirationdate: dom.expirationdate,
      userId: dom.userId,
    };
  }

  static toUpdateDto(dom: UpdateCardRequestDom): UpdateCardRequestDto {
    return <UpdateCardRequestDto>{
        cardNumber: dom.cardNumber,
        ownerName: dom.ownerName,
        expirationdate: dom.expirationdate
    };
  }
}
