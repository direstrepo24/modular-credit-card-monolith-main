import { useCards } from "@presentation/hooks/use-cards";
import { ActionCard, CardForm } from "./CardForm";
import { CardList } from "./CardList";
import { CARD_SYMBOLS, CardResponseDom } from "@domain/cards";
import { di } from "@di/app.container";
import { AllCardsByUserUseCase, CreateCardUseCase, DeleteCardUseCase, UpdateCardUseCase } from "@application/card";
import { useState } from "react";
export const CardMain = () => {

    const [action, setAction] = useState<ActionCard>(ActionCard.ADD)
    const [selected, setSelected] = useState<CardResponseDom | undefined>(undefined)

    const {
        cards,
        loading,
        deleteCard,
        addCard,
        updateCard } = useCards(
            di.get<AllCardsByUserUseCase>(CARD_SYMBOLS.CARD_LIST),
            di.get<DeleteCardUseCase>(CARD_SYMBOLS.CARD_DELETE),
            di.get<CreateCardUseCase>(CARD_SYMBOLS.CARD_CREATE),
            di.get<UpdateCardUseCase>(CARD_SYMBOLS.CARD_UPDATE),
        );
    return (
        <div className="flex w-full mt-4">
            <div className="grid flex-grow card rounded-box place-items-center">
                {action == ActionCard.ADD &&
                    <CardForm  onAdd={addCard} data={selected} action={ActionCard.ADD} />}
                {action == ActionCard.EDIT &&  <CardForm onUpdate={(_)=>{
                        updateCard(_)
                        setSelected(undefined)
                        setAction(ActionCard.ADD)
                    }} data={selected} action={ActionCard.EDIT} />}
            </div>
            <div className="divider divider-horizontal">OR</div>
            <div className="grid flex-grow card rounded-box place-items-center">
                {loading && <span className="loading loading-ball loading-lg"></span>}
                {cards.length > 0 &&
                    <CardList onEdit={(value: CardResponseDom) => {
                        setSelected(undefined)
                        setAction(ActionCard.ADD)
                    setTimeout(() => {
                        setSelected(value)
                        setAction(ActionCard.EDIT)
                          }, 100)
                    }} onDelete={deleteCard} cards={cards}
                    />
                }
                {cards.length == 0 && <h3>Registra tu primera tarjeta</h3>}
            </div>
        </div>
    );
}