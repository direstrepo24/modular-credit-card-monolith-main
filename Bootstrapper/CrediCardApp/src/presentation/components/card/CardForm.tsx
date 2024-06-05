import { CardResponseDom, CreateCardRequestDom, UpdateCardRequestDom } from "@domain/cards";
import { useForm } from "react-hook-form";
import * as Yup from 'yup';
import { yupResolver } from "@hookform/resolvers/yup";
import { AlertError } from "../base/Error";
import { useEffect } from "react";
import { useRecoilState } from "recoil";
import { authStore } from "@presentation/store/app.store";

export enum ActionCard {
    ADD,
    EDIT
}

export interface CardFormProps {
    action?: ActionCard,
    data?: CardResponseDom,
    onUpdate?: (value: UpdateCardRequestDom) => void
    onAdd?: (value: CreateCardRequestDom) => void
}

export const CardForm = ({ action = ActionCard.ADD, data, onUpdate, onAdd }: CardFormProps) => {

    const [auth] = useRecoilState(authStore);

    const validationSchema = Yup.object().shape({
        id: Yup.number().required('Campo requerido'),
        userId: Yup.string().required('Campo requerido'),
        cardNumber: Yup.string()
            .required('Campo requerido')
            .min(6, ('Debe tener minimo 6 caracteres'))
            .max(20, ('Debe tener maximo 20 caracteres')),
        ownerName: Yup.string()
            .required('Campo requerido')
            .min(2, ('Debe tener minimo 2 caracteres'))
            .max(50, ('Debe tener maximo 50 caracteres')),
        expirationdate: Yup.string()
            .required('Campo requerido')
    });

    const {
        register,
        handleSubmit,
        formState: { errors }, setValue,
    } = useForm<FormCardRequestDom>({
        resolver: yupResolver(validationSchema)
    });

    useEffect(() => {
        setValue('userId', auth?.id ?? "")
        action == ActionCard.EDIT ? setValue('id', data?.id ?? 0) : setValue('id', 0)
    }, [])

    const onSubmit = (data: FormCardRequestDom) => {
        if (action == ActionCard.EDIT) {
            
            onUpdate!(new UpdateCardRequestDom(data.id, data.cardNumber, data.ownerName, data.expirationdate))
            return;
        }
        onAdd!(new CreateCardRequestDom(data.userId, data.cardNumber, data.ownerName, data.expirationdate))        
    }

    return (
        <form onSubmit={handleSubmit(onSubmit)} className="form-control w-full max-w-xs mt-4">
            <div className="label">
                <span className="label-text">Ingresa el numero de la tarjeta</span>
            </div>
            <input type="text" defaultValue={data?.cardNumber} {...register("cardNumber")} placeholder="numero de la tarjeta" className="input input-bordered w-full max-w-xs" />
            {errors.cardNumber?.message && <AlertError error={errors.cardNumber?.message}></AlertError>}

            <div className="label">
                <span className="label-text">Ingresa el titular de la tarjeta</span>
            </div>
            <input type="text" defaultValue={data?.ownerName} {...register("ownerName")} placeholder="titular de la tarjeta" className="input input-bordered w-full max-w-xs mt-2" />
            {errors.ownerName?.message && <AlertError error={errors.ownerName?.message}></AlertError>}

            <div className="label">
                <span className="label-text">Fecha Expiracion</span>
            </div>
            <input type="month" defaultValue={data?.expirationdate?.substring(0,7)} {...register("expirationdate")} placeholder="fecha de expiracion" className="input input-bordered w-full max-w-xs mt-2" />
            {errors.expirationdate?.message && <AlertError error={errors.expirationdate?.message}></AlertError>}

            <div className="label mt-2">
                <button className="btn btn-primary">Guardar</button>
            </div>
        </form>
    );
}


export class FormCardRequestDom {
    constructor(
        public id: number,
        public userId: string,
        public cardNumber: string,
        public ownerName: string,
        public expirationdate: string
    ) { }
}