import { httpClient } from "./httpClient";

const AUTH_API = import.meta.env.VITE_AUTH_API_URL;

export async function login(user: string, password: string) {
    const response = await httpClient.post(`${AUTH_API}/login`, {
        user,
        password
    });

    return response.data;
}