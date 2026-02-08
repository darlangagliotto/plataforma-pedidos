import { httpClient } from "./httpClient";

const ORDER_API = import.meta.env.VITE_ORDER_API_URL;

export async function createOrder(description: string) {
    await httpClient.post(`${ORDER_API}/orders`, {
        description
    });
}

export async function getOrders(){
    const response = await httpClient.get(`${ORDER_API}/orders`);
    return response.data;
}