import { Link, Outlet, useNavigate } from "react-router-dom";
import { useAuth } from "../auth/AuthContext";

export function AppLayout() {
    const { logout } = useAuth();
    const navigate = useNavigate();

    function handleLogout() {
        logout();
        navigate("/login");
    }

    return (
        <div className="min-h-screen bg-gray-100">
            <header className="bg-slate-900 text-white px-6 py-4 flex justify-between items-center">
                <div className="text-lg font-semibold">
                    Plataforma de Pedidos
                </div>

                <nav className="flex gap-6 items-center">
                    <Link to="/orders" className="hover:text-slate-300">
                        Pedidos
                    </Link>
                    <Link to="/orders/new" className="hover:text-slate-300">
                        Novo Pedido
                    </Link>

                    <span className="text-sm text-slate-300">
                        Nome Usuario
                    </span>

                    <button
                        onClick={handleLogout}
                        className="bg-red-600 hover:bg-red-700 px-3 py-1 rounded text-sm"
                    >
                        Logout
                    </button>
                </nav>
            </header>

            <main className="p-6">
                <Outlet />
            </main>
        </div>
    )
}