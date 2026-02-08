import { httpClient } from "./httpClient";

export async function createOrder(product: string, quantity: number) {
    await httpClient.post('/orders', {
        product,
        quantity
    });
}

export async function getOrders(){
    const response = await httpClient.get('/orders');
    return response.data;
}