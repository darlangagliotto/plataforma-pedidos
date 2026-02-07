import { useState } from 'react'
import { createOrder } from '../api/order.api'
import { Button } from '../components/Button'
import { Input } from '../components/Input'

export function CreateOrderPage({ token }: { token: string }) {
    const [product, setProduct] = useState('');
    const [quantity, setQuantity] = useState(1);

    async function handleCreate() {
        await createOrder(product, quantity, token);
        alert('Pedido criado!');
    }

    return (
        <div className='space-y-4'>
            <Input value={product} onChange={setProduct} placeholder='Produto' />
            <Input value={quantity} onChange={v => setQuantity(Number(v))} />
            <Button onClick={handleCreate}>Criar Pedido</Button>
        </div>
    )
}