import { httpClient } from "./httpClient";

export async function createOrder(product: string, quantity: number) {
    await httpClient.post('/api/order', {
        product,
        quantity
    });
}

export async function getOrders(){
    const response = await httpClient.get('/api/order');
    return response.data;
}