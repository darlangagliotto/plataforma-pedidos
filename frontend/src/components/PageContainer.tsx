interface PageContainerProps{
    title: string;
    children: React.ReactNode;
}

export function PageContainer({ title, children }: PageContainerProps) {
    return (
        <div className="flex flex-col gap-6">
            <h1 className="text-2xl font-semibold">{title}</h1>
            {children}
        </div>
    );
}