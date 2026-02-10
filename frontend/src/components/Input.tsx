interface Props{
    value: string | number
    onChange: (value: string) => void
    placeholder?: string
     type?: 'text' | 'password' | 'email' | 'number'
}

export function Input({ value, onChange, placeholder, type = 'text' }: Props) {
    return (
        <div className="flex flex-col gap-1">            
            <input
                type={type}
                value={value}
                placeholder={placeholder}
                onChange={e => onChange(e.target.value)}
                className="border border-slate-300 rounded-md px-3 py-2 focus:outline-none focus:ring-2 focus:ring-primary"
            />
        </div>
    )
}