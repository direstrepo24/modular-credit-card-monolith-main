import { Failure, NoResult, Result } from "@core/index"
import { CardResponseDom } from "../models/card-response.dom"
import { CreateCardRequestDom, UpdateCardRequestDom } from "../models/card-request.dom"

export interface CardRepository{
    listByUser(userId: string) : Promise<Result<CardResponseDom[], Failure>>
    create(request: CreateCardRequestDom): Promise<Result<CardResponseDom, Failure>>
    update(request: UpdateCardRequestDom): Promise<Result<CardResponseDom, Failure>>
    deleteById(id: number): Promise<Result<NoResult, Failure>>
}