export interface CardResponseDto {
    id: number
    cardNumber: string
    ownerName: string
    expirationdate: string
}

export interface CreateCardRequestDto {
    userId: string
    cardNumber: string
    ownerName: string
    expirationdate: string
}

export interface UpdateCardRequestDto {
    cardNumber: string
    ownerName: string
    expirationdate: string
}