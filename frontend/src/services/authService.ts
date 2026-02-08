import { httpClient } from "./httpClient";

const AUTH_API = import.meta.env.VITE_AUTH_API_URL;

export async function login(username: string, password: string) {
    const response = await httpClient.post(`${AUTH_API}/api/auth/login`, {
        username,
        password
    });

    return response.data;
}