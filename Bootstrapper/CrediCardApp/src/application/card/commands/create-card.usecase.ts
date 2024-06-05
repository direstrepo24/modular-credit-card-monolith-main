
import { inject, injectable } from "inversify";
import  { Command, Failure, Result } from "@core/index";
import { CARD_SYMBOLS, type CardRepository, CardResponseDom, CreateCardRequestDom } from "@domain/cards";

@injectable()
export class CreateCardUseCase extends Command<Promise<Result<CardResponseDom, Failure>>,CreateCardRequestDom> {
    constructor(
        @inject(CARD_SYMBOLS.CARD_REPOSITORY)
        private readonly _cardkRepository: CardRepository,
    ) {
        super()
    }
    execute = (params: CreateCardRequestDom): Promise<Result<CardResponseDom, Failure>> =>
        this._cardkRepository.create(params);
}