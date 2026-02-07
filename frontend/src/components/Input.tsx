interface Props{
    value: string | number
    onChange: (value: string) => void
    placeholder?: string
}

export function Input({ value, onChange, placeholder }: Props) {
    return (
        <input
            value={value}
            placeholder={placeholder}
            onChange={e => onChange(e.target.value)}
            className="border px-3 py-2 rounded w-full"
        />
    )
}