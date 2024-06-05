import { Navigate, Outlet } from "react-router-dom"

interface RouteGuardProp{
    isRuoteAccessible?: boolean
    redirectRoute?: string
}
export const RouteGuard = ({
    isRuoteAccessible = false,
    redirectRoute= '/'
}: RouteGuardProp): JSX.Element => isRuoteAccessible ? <Outlet />: <Navigate to={redirectRoute} replace />