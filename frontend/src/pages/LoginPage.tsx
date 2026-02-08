import React, { useState } from 'react'
import { login } from '../api/auth.api'
import { Button } from '../components/Button'
import { Input } from '../components/Input'
import { useAuth } from '../auth/AuthContext'
import { useNavigate } from 'react-router-dom'

export function LoginPage() {
    const { login } = useAuth();
    const navigate = useNavigate();

    const [userName, setUserName] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState('');

    async function handleSubmit(e: React.FormEvent) {
        e.preventDefault();
        setError('');
        
        try {
            await login(userName, password);
            navigate('/orders');
        } catch {
            setError('Usuário ou senha inválidos');
        }        
    }

    return (
        <div className='min-h-screen flex items-center justify-center bg-slate-900'>
            <form
                onSubmit={handleSubmit}
                className='bg-white p-8 rounded shadow-md w-96'
            >
            <h1 className='text-2xl font-bold mb-2 text-center'>
                Plataforma de Pedidos
            </h1>
            <p className="text-sm text-gray-500 mb-6 text-center">
                Acesse o sistema para gerenciar pedidos
            </p>

            <Input value={userName} onChange={setUserName} placeholder='Usuário' />
            <Input type='password' value={password} onChange={setPassword} placeholder='Senha' />

            {error && (
                <div className='text-red-600 text-sm mb-4'>
                    {error}
                </div>
            )}

            <Button>Entrar</Button>
            </form>
        </div>
    )
}