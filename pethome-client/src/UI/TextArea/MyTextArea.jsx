import React from 'react'
import s from './MyTextArea.module.css'

export const MyTextArea = ({ ...props }) => {
    return (
        <textarea
            {...props}
        />
    )
}
