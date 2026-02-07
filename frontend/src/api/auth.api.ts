export async function login(username: string, password: string) {
    const response = await fetch('http://localhost:5002/api/auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify({username, password})
    })

    if (!response.ok){
        throw new Error('Login inválido')
    }

    return response.json();
}