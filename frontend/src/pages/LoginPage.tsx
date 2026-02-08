import { useState } from 'react'
import { login } from '../api/auth.api'
import { Button } from '../components/Button'
import { Input } from '../components/Input'

export function LoginPage({ onLogin }: { onLogin: (token: string) => void }) {
    const [userName, setUserName] = useState('')
    const [password, setPassword] = useState('')

    async function handleLogin() {
        const result = await login(userName, password);
        onLogin(result.token);
    }

    return (
        <div className='max-w-sm mx-auto mt-20 space-y-4'>
            <Input value={userName} onChange={setUserName} placeholder='Usuário' />
            <Input type='password' value={password} onChange={setPassword} placeholder='Senha' />
            <Button onClick={handleLogin}>Entrar</Button>
        </div>
    )
}