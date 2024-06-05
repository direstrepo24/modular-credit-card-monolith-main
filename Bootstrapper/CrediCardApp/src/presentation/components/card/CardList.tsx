import { CardResponseDom } from "@domain/cards";

export interface CardListProps {
  cards: CardResponseDom[],
  onEdit: (value: CardResponseDom) => void
  onDelete: (id: number) => void
}

const maskCreditCardNumber = (creditCardNumber: string) => {
  const maskedDigits = '*'.repeat(creditCardNumber.length - 4);
  const visibleDigits = creditCardNumber.slice(-4);
  return maskedDigits + visibleDigits;
}

export const CardList = ({ cards = [], onEdit, onDelete }: CardListProps) => {
  return <div className="overflow-x-auto">
    <table className="table table-zebra">
      {/* head */}
      <thead>
        <tr>
          <th></th>
          <th>Numero Tarjeta</th>
          <th>Titular</th>
          <th>Fecha de Expiracion</th>
          <th>Opciones</th>
        </tr>
      </thead>
      <tbody>
        {cards.map((item, index) => <tr key={item.id}>
          <th>{ index+1}</th>
          <td>{ maskCreditCardNumber(item.cardNumber) }</td>
          <td>{ item.ownerName }</td>
          <td>{item.expirationdate.substring(0,7)}</td>
          <td>
              <button onClick={() => onEdit(item)} className="btn btn-primary mr-2">Editar</button>
              <button onClick={() => onDelete(item.id)} className="btn btn-secondary">Eliminar</button>
          </td>
        </tr>)}
      </tbody>
    </table>
  </div>;
}