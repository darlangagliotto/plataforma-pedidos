interface Props{
    value: string | number
    onChange: (value: string) => void
    placeholder?: string
     type?: 'text' | 'password' | 'email' | 'number'
}

export function Input({ value, onChange, placeholder, type = 'text' }: Props) {
    return (
        <input
            type={type}
            value={value}
            placeholder={placeholder}
            onChange={e => onChange(e.target.value)}
            className="border px-3 py-2 rounded w-full"
        />
    )
}