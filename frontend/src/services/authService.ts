import { httpClient } from "./httpClient";

export async function login(username: string, password: string) {
    const response = await httpClient.post('/api/auth/login', {
        username,
        password
    });

    return response.data;
}