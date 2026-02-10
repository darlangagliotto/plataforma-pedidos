import type { Config } from "tailwindcss";

const config: Config = {
  content: ['./index.html', './src/**/*.{ts,tsx}'],
  theme: {
    extend: {
      colors: {
        primary: '#4f46e5',
        primaryDark: '#4338ca'
      }
    }
  },
  plugins: [],
};

export default config;

