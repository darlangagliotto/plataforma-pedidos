import React from "react";

interface CardProps{
    children: React.ReactNode;
};

export function Card( { children }: CardProps){
    return (
        <div className="bg-white rounded-md p-4 shadown-sm border border-slate-200">
            {children}
        </div>
    )
}