import { useState } from 'react'
import { createOrder } from '../services/orderService'
import { Button } from '../components/Button'
import { Input } from '../components/Input'
import { PageContainer } from '../components/PageContainer';

export function CreateOrderPage() {
    const [product, setProduct] = useState('');
    const [quantity, setQuantity] = useState(1);

    async function handleCreate() {
        await createOrder(product, quantity);
        alert('Pedido criado!');
    }

    return (
        <PageContainer title='Novo Pedido'>
            <div className='max-w-md flex flex-col gap-4'>
                <Input value={product} onChange={setProduct} placeholder='Produto' />
                <Input value={quantity} onChange={v => setQuantity(Number(v))} />
                <Button onClick={handleCreate}>Salvar Pedido</Button>
            </div>
        </PageContainer>
    )
}