import { LoginPage } from './pages/LoginPage'
import { CreateOrderPage } from './pages/CreateOrderPage'
import { OrdersPage } from './pages/OrdersPage'
import { AuthProvider } from './auth/AuthContext'
import { Navigate, Route, Routes } from 'react-router-dom'
import { ProtectedRoute } from './auth/ProtectedRoute'

export default function App() {
  return (    
      <AuthProvider>        
          <Routes>
            <Route path='/login' element={<LoginPage />} />

            <Route element={<ProtectedRoute />}>
              <Route path='/orders' element={<OrdersPage />} />
              <Route path='/orders/create' element={<CreateOrderPage />} />
            </Route>

            <Route path='*' element={<Navigate to="/login" />} />
          </Routes>
      </AuthProvider>
  )
}