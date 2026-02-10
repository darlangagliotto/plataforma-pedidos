import { Routes, Route, Navigate } from "react-router-dom";
import { AppLayout } from "../layout/AppLayout";
import { OrdersPage } from "../pages/OrdersPage";
import { CreateOrderPage } from "../pages/CreateOrderPage";
import { LoginPage } from "../pages/LoginPage";
import { ProtectedRoute } from "../auth/ProtectedRoute";

export function AppRoutes() {
    return (
        <Routes>
            <Route path="/login" element={<LoginPage />} />
             <Route element={<ProtectedRoute />}>
                <Route element={<AppLayout />}>
                    <Route path="/" element={<Navigate to="/orders" />} />
                    <Route path="/orders" element={<OrdersPage />} />
                    <Route path="/orders/new" element={<CreateOrderPage />} />
                </Route>
            </Route>
            <Route path="*" element={<Navigate to="/login" />} />
        </Routes>
    );
}
