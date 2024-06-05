import React, { useState } from 'react'
import { Failure, NoResult } from '@core/index';
import { AllCardsByUserUseCase } from '@application/card/queries/all-cards-by-user.usecase';
import { CardResponseDom, CreateCardRequestDom, UpdateCardRequestDom } from '@domain/cards';
import { useRecoilState } from 'recoil';
import { authStore } from '@presentation/store/app.store';
import { DeleteCardUseCase } from '@application/card/commands/delete-card.usecase';
import { CreateCardUseCase } from '@application/card/commands/create-card.usecase';
import { UpdateCardUseCase } from '@application/card/commands/update-card.usecase';
 
function useCards(
    allCardsByUserUseCase: AllCardsByUserUseCase,
    deleteCardUseCase: DeleteCardUseCase,
    createCardUseCase: CreateCardUseCase,
    updateCardUseCase: UpdateCardUseCase,
) {
 
    const [cards, setCards] = useState<CardResponseDom[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<boolean>(false);
    const [auth] = useRecoilState(authStore);

    React.useEffect(() => {
        allCards()
    }, [allCardsByUserUseCase])

    const allCards = async () => {
        setLoading(true)
        const result = await allCardsByUserUseCase?.execute(auth?.id ?? "")
        result.fold((data: CardResponseDom[]) => setCards(data), (_: Failure) => setError(true))
        setLoading(false)
    };
   
    const deleteCard = async (id: number) => {
        const result = await deleteCardUseCase.execute(id)
        result.fold((_: NoResult) => allCards(), (_: Failure) => setError(true))
    };
 
    const addCard = async (request: CreateCardRequestDom) => {
        const result = await createCardUseCase?.execute(request)
        result.fold((_: CardResponseDom) => allCards(), (_: Failure) => setError(true))
    };

    const updateCard = async (request: UpdateCardRequestDom) => {
        const result = await updateCardUseCase?.execute(request)
        result.fold((_: CardResponseDom) => allCards(), (_: Failure) => setError(true))
    };
   
    return {
        cards,
        loading,
        error,
        deleteCard,
        updateCard,
        addCard
    };
}
export { useCards }