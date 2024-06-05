import { NotFound } from "@presentation/components/base/NotFound"
import DefaultLayout from "@presentation/layouts/DefaultLayout"
import LoginPage from "@presentation/pages/LoginPage"
import { Navigate, Route, Routes } from "react-router-dom"
import { RouteGuard } from "./RouteGuard"
import HomePage from "@presentation/pages/HomePage"
 
interface AppRouteProps {
    isAuthenticated: boolean;
}

const AppRoutes = ({ isAuthenticated }: AppRouteProps) => {
    return (
        <Routes>
            <Route element={<RouteGuard isRuoteAccessible={!isAuthenticated} redirectRoute="/home" />}>
                <Route path="/login" element={<LoginPage />} />
                <Route path="/" element={<Navigate to="/login" />} />
            </Route>
            <Route element={<RouteGuard isRuoteAccessible={isAuthenticated} redirectRoute="/login" />}>
                <Route element={<DefaultLayout />}>
                    <Route path="/home" element={<HomePage />} />
                    <Route path="/" element={<Navigate to="/home" />} />
                </Route>
            </Route>
            <Route path="*" element={<NotFound />} />
        </Routes>
    );
};

export default AppRoutes;
