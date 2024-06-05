
import { inject, injectable } from "inversify";
import  { Failure, Query, Result } from "@core/index";
import { CARD_SYMBOLS, type CardRepository, CardResponseDom } from "@domain/cards";

@injectable()
export class AllCardsByUserUseCase extends Query<Promise<Result<CardResponseDom[], Failure>>,string> {
    constructor(
        @inject(CARD_SYMBOLS.CARD_REPOSITORY)
        private readonly _cardkRepository: CardRepository,
    ) {
        super()
    }
    execute = (params: string): Promise<Result<CardResponseDom[], Failure>> => this._cardkRepository.listByUser(params);
}