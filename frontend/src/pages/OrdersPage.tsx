import { useEffect, useState } from 'react'
import { getOrders } from '../services/orderService'
import type { Order } from '../types/order'

export function OrdersPage() {
    const [orders, setOrders] = useState<Order[]>([])

    useEffect(() => {
        getOrders().then(setOrders)
    }, [])

    return (
        <ul className='space-y-2'>
            {orders.map(o => (
                <li key={o.id} className='border p-2 rounded'>
                    {o.product} - {o.quantity}
                </li>
            ))}
        </ul>
    )
}