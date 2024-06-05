import { inject, injectable } from "inversify";
import { Failure, HTTP_CLIENT_SYMBOLS, HttpClientOptions, Left, NoResult, Result, Right, UnknowFailure, type HttpClient } from "@core/index";
import { CardRepository, CardResponseDom, CreateCardRequestDom, UpdateCardRequestDom } from "@domain/cards";
import { CardResponseDto } from "./dtos/card.dto";
import { CardMapper } from "./mapper/card.mapper";

@injectable()
export class CardImplRepository implements CardRepository {
    baseURL: any = process.env.VITE_BASE_URL
    constructor(
        @inject(HTTP_CLIENT_SYMBOLS.FETCH)
        private readonly httpClient: HttpClient,
    ) {}
    async listByUser(userId: string): Promise<Result<CardResponseDom[], Failure>> {
        const options = <HttpClientOptions>{
            path:`${this.baseURL}/api/v1/Card/GetAllByUser/${userId}`,
            removeDefaultHeaders: ['Authorization']
        };
        let result = await this.httpClient.get<CardResponseDto[]>(options)
        return result.ok ?  new Right<CardResponseDom[]>(result.data.map(CardMapper.toDom)):  new Left<Failure>(new UnknowFailure(`Unknow error: ${result.error}`))
    }
    async create(request: CreateCardRequestDom): Promise<Result<CardResponseDom, Failure>> {
        const options = <HttpClientOptions>{
            path: `${this.baseURL}/api/v1/Card/Create`,
            body: CardMapper.toCreateDto(request),
        };
        let result = await this.httpClient.post<CardResponseDto>(options)
        return result.ok ?  new Right<CardResponseDom>(CardMapper.toDom(result.data)):  new Left<Failure>(new UnknowFailure(`Unknow error: ${result.error}`))
    }
    async update(request: UpdateCardRequestDom): Promise<Result<CardResponseDom, Failure>> {
        const options = <HttpClientOptions>{
            path: `${this.baseURL}/api/v1/Card/Update/${request.id}`,
            body: CardMapper.toUpdateDto(request),
        };
        let result = await this.httpClient.put<CardResponseDto>(options)
        return result.ok ?  new Right<CardResponseDom>(CardMapper.toDom(result.data)):  new Left<Failure>(new UnknowFailure(`Unknow error: ${result.error}`))
    }
    async deleteById(id: number): Promise<Result<NoResult, Failure>> {
        const options = <HttpClientOptions>{
            path: `${this.baseURL}/api/v1/Card/Delete/${id}`,
        };
        let result = await this.httpClient.delete<void>(options)
        return result.ok ?  new Right<NoResult>(NoResult):  new Left<Failure>(new UnknowFailure(`Unknow error: ${result.error}`))
    }
}