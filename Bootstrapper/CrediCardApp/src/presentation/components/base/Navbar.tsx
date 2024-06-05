import { useRecoilState } from 'recoil';
import '../../assets/styles/styles.scss'
import { authStore } from '@presentation/store/app.store';

export function NavBar() {
    const [auth, setAuthState] = useRecoilState(authStore);

    const onSignOff = () => {
        setAuthState(null)
    }
    return (
        <>
            <div className="navbar bg-base-100">
                <div className="navbar-start">
                    <a className="btn btn-ghost text-xl">{ auth?.name}</a>
                </div>
                <div className="navbar-end">
                    <a onClick={onSignOff} className="btn">Salir</a>
                </div>
            </div>
        </>
    )
}