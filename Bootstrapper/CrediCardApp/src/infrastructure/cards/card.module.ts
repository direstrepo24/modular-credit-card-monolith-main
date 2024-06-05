import { ContainerModule } from "inversify";
import "reflect-metadata";
import { CARD_SYMBOLS, CardRepository } from "@domain/cards";
import { CardImplRepository } from "./card-impl.repository";
import { AllCardsByUserUseCase } from "@application/card/queries/all-cards-by-user.usecase";
import { CreateCardUseCase } from "@application/card/commands/create-card.usecase";
import { UpdateCardUseCase } from "@application/card/commands/update-card.usecase";
import { DeleteCardUseCase } from "@application/card/commands/delete-card.usecase";

const cardModule = new ContainerModule((bind) => {
    bind<CardRepository>(CARD_SYMBOLS.CARD_REPOSITORY)
      .to(CardImplRepository)
      .inSingletonScope();
    bind<AllCardsByUserUseCase>(CARD_SYMBOLS.CARD_LIST)
      .to(AllCardsByUserUseCase)
      .inSingletonScope();
    bind<CreateCardUseCase>(CARD_SYMBOLS.CARD_CREATE)
      .to(CreateCardUseCase)
      .inSingletonScope();
    bind<UpdateCardUseCase>(CARD_SYMBOLS.CARD_UPDATE)
      .to(UpdateCardUseCase)
      .inSingletonScope();
    bind<DeleteCardUseCase>(CARD_SYMBOLS.CARD_DELETE)
      .to(DeleteCardUseCase)
      .inSingletonScope();
  });
  export { cardModule };