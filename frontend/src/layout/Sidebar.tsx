import { Link, useLocation } from "react-router-dom";

export function Sidebar() {
    const { pathname } = useLocation();

    function linkClass(path: string) {
        return pathname === path
        ? 'text-primary font-medium'
        : 'text-slate-700 hover:text-primary'
    }

    return (
        <aside className="w-56 bg-white border-r border-slate-200 p-4 flex flex-col gap-3">
            <Link to="/orders" className={linkClass('/orders')}>
                Pedidos
            </Link>
            <Link to="/orders/new" className={linkClass('/orders/new')}>
                Novo Pedido
            </Link>
        </aside>
    );
}