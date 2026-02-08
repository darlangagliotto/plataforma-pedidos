import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig(({ mode }) => {
  const env = loadEnv(mode, process.cwd());

  return{
    plugins: [react()],
    server:{      
      proxy: {
        "/api/auth": {
          target:env.VITE_AUTH_API_URL,
          changeOrigin: true,
          secure: false
        },
        "/api/order": {
          target:env.VITE_ORDER_API_URL,
          changeOrigin: true,
          secure: false
        }
      }
    }
  }
})
