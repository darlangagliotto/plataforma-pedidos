import { useState } from 'react'
import { LoginPage } from './pages/LoginPage'
import { CreateOrderPage } from './pages/CreateOrderPage'
import { OrdersPage } from './pages/OrdersPage'

export default function App() {
  const [token, setToken] = useState<string | null>(null)

  if (!token) {
    return <LoginPage onLogin={setToken} />
  }

  return (
    <div className='max-w-xl mx-auto mt-10 space-y-6'>
      <CreateOrderPage token={token} />
      <OrdersPage token={token} />
    </div>
  )
}