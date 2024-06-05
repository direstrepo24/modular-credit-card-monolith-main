
export class CreateCardRequestDom {
    constructor(
        public userId: string,
        public cardNumber: string,
        public ownerName: string,
        public expirationdate: string
    ) {}
}

export class UpdateCardRequestDom {
    constructor(
        public id: number,
        public cardNumber: string,
        public ownerName: string,
        public expirationdate: string
    ) {}
}