interface Props {
    children: React.ReactNode
    onClick?: () => void
}

export function Button({ children, onClick }: Props){
    return (
        <button
            onClick={onClick}
            className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
        >
            {children}
        </button>
    )
}