import React from 'react'
import s from './MyInput.module.css'
export const MyInput = (({ type, ...props }) => {
    return (
        <input
            className={s.MyInput}
            type={type}
            {...props}
        />
    )
}
)
