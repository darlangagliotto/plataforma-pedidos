import React, { createContext, useContext, useState } from "react";
import { login as loginApi } from "../services/authService";

interface AuthContextType {
    token: string | null;
    user: string | null;
    login: (username: string, password: string) => Promise<void>;
    logout: () => void;
    isAuthenticated: boolean;
}

const AuthContext = createContext<AuthContextType>({} as AuthContextType);

export function AuthProvider({ children }: { children: React.ReactNode }) {
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<string | null>(null);

    async function login(username: string, password: string) {
        const response = await loginApi(username, password);
        setToken(response.token);
        setUser(username)
    }

    function logout() {        
        setToken(null);
        setUser(null);
    }

    return (
        <AuthContext.Provider 
            value ={{ 
                token, 
                user,
                login,
                logout,
                isAuthenticated: !!token 
            }}
        >
           {children}
        </AuthContext.Provider>
    )
}

export function useAuth() {
    return useContext(AuthContext);
}