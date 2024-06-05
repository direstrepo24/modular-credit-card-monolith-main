
import { inject, injectable } from "inversify";
import  { Command, Failure, NoResult, Result } from "@core/index";
import { CARD_SYMBOLS, type CardRepository} from "@domain/cards";

@injectable()
export class DeleteCardUseCase extends Command<Promise<Result<NoResult, Failure>>,number> {
    constructor(
        @inject(CARD_SYMBOLS.CARD_REPOSITORY)
        private readonly _cardkRepository: CardRepository,
    ) {
        super()
    }
    execute = (params: number): Promise<Result<NoResult, Failure>> =>
        this._cardkRepository.deleteById(params);
}