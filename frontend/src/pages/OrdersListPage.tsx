import { useEffect, useState } from "react";
import { getOrders } from "../api/order.api";

export function OrderListPage({ token }: { token:string}) {
    const [orders, setOrders] = useState<any[]>([]);

    useEffect(() => {
        getOrders(token).then(setOrders);
    }, [token]);

    return (
        <div className='p-6'>
            <h1 className='text-xl font-semibold mb-4'>Pedidos</h1>
            <ul className="space-y-2">
                {orders.map(order => (
                    <li key={order.id} className="p-4 bg-white rounded shadow">
                        {order.quantity}
                    </li>
                ))}
            </ul>
        </div>
    )
}