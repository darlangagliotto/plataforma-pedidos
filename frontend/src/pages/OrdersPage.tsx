import { useEffect, useState } from 'react'
import { getOrders } from '../services/orderService'
import type { Order } from '../types/order'
import { PageContainer } from '../components/PageContainer';
import { Card } from '../components/Card';

export function OrdersPage() {
    const [orders, setOrders] = useState<Order[]>([])
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getOrders()
            .then(setOrders)
            .finally(() => setLoading(false))
    }, [])

    if (loading) {
        return <p>Carregando pedidos...</p>
    }

    if (orders.length === 0){
        return <p>nenhum pedido cadastrado.</p>
    }
    return (        
        <PageContainer title='Pedidos'>
            <div className='grid gap-4'>
                {orders.map((order) =>(
                    <Card key={order.id}>
                        <div className='font-mediu'>Pedido #{order.id}</div>
                        <div className='font-mediu'>Produto: {order.product}</div>
                        <div className='text-sm text-slate-600'>Quantidade: {order.quantity}</div>
                    </Card>
                ))}
            </div>
        </PageContainer>
    )
}