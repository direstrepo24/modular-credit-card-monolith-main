
import { inject, injectable } from "inversify";
import  { Command, Failure, Result } from "@core/index";
import { CARD_SYMBOLS, type CardRepository, CardResponseDom, UpdateCardRequestDom} from "@domain/cards";

@injectable()
export class UpdateCardUseCase extends Command<Promise<Result<CardResponseDom, Failure>>,UpdateCardRequestDom> {
    constructor(
        @inject(CARD_SYMBOLS.CARD_REPOSITORY)
        private readonly _cardkRepository: CardRepository,
    ) {
        super()
    }
    execute = (params: UpdateCardRequestDom): Promise<Result<CardResponseDom, Failure>> =>
        this._cardkRepository.update(params);
}