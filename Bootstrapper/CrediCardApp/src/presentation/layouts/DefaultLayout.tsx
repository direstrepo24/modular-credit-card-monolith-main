import { NavBar } from "@presentation/components/base/Navbar";
import { Outlet } from "react-router-dom";

function DefaultLayout() {
    return (
        <>
            <NavBar></NavBar>
            <section className="bg-gray-50 dark:bg-gray-900">
                <div className="px-6 py-8 mx-auto md:h-screen lg:py-0">
                    <Outlet></Outlet>
                </div>
            </section>
        </>
    )
}

export default DefaultLayout;