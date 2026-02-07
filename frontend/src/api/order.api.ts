import type { Order } from '../types/order';

export async function createOrder(product: string, quantity: number, token: string) {
    const response = await fetch('http://localhost:5001/api/orders', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify({product, quantity})
    })

    if (!response.ok) {
        throw new Error('Erro ao criar o pedido')
    }

    return response.json();
}

export async function getOrders(token: string): Promise<Order[]> {
    const response = await fetch('http://localhost:5001/api/orders', {
        headers: {
        'Authorization': `Bearer ${token}`
        }
    })

    if (!response.ok) {
        throw new Error('Erro ao buscar pedidos')
    }

    return response.json();
}