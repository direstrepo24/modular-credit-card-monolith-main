import { AuthUser, authStore } from "@presentation/store/app.store";
import CryptoJS from 'crypto-js';
import React, { Component } from "react";
import { SetterOrUpdater, useRecoilState } from "recoil";

interface LoginFormState {
    name: string;
    id: string;
}

interface LoginFormProps {
    authUser: SetterOrUpdater<AuthUser | null>
}

class _LoginForm extends Component<LoginFormProps, LoginFormState> {
    constructor(props: LoginFormProps) {
        super(props);
        this.state = {
            name: '',
            id: ''
        };
    }
    nameHandleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ name: event.target.value, id: this.state.id });
    }
    idHandleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ name: this.state.name, id: event.target.value });
    }

    signIn = () => {
        if(!this.state.name && !this.state.id) return
        const uuid = this.generateDeterministicUUID(Number(this.state.id));
        const user: AuthUser = {
            id: uuid,
            name: this.state.name
        }
        console.log(user)
        this.props.authUser(user)
    }

    /**
     * Convierte un número de en un UUID determinístico.
     * @param num Número.
     * @returns UUID único.
     */
    generateDeterministicUUID = (num: number): string => {
        const numStr = num.toString();
        // Crear un hash SHA-256 del número
        const hash = CryptoJS.SHA256(numStr).toString(CryptoJS.enc.Hex);
        // Formatear el hash como un UUID
        const uuid = [
            hash.substring(0, 8),
            hash.substring(8, 12),
            hash.substring(12, 16),
            hash.substring(16, 20),
            hash.substring(20, 32)
        ].join('-');
        return uuid;
    }
    render() {
        return (
            <>
                <label className="form-control w-full max-w-xs">
                    <div className="label">
                        <span className="label-text">Cual es tu nombre</span>
                    </div>
                    <input type="text" value={this.state.name}
                        onChange={this.nameHandleChange} placeholder="Ingresa tu nombre completo" className="input input-bordered w-full max-w-xs" />
                    
                    <div className="label">
                        <span className="label-text">Cual es tu indentificacion</span>
                    </div>
                     <input type="number" value={this.state.id}
                        onChange={this.idHandleChange} placeholder="Ingresa tu identificacion" className="input input-bordered w-full max-w-xs mt-2" />
                    <div className="label mt-2">
                        <span className="label-text-alt">haz clic para ingresar</span>
                        <button onClick={this.signIn} className="btn btn-primary">Ingresar</button>
                    </div>
                </label>
            </>
        );
    }
}

export const LoginForm = () => {
    const [_, setState] = useRecoilState(authStore);
    return <_LoginForm authUser={setState} />;
}