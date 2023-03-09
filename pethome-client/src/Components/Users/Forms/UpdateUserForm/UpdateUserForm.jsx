import React, { useState,useEffect } from 'react'
import { useFetching } from '../../../../Hooks/useFetching'
import s from './UpdateUserForm.module.css'
import { MyLoader } from '../../../../UI/MyLoader/MyLoader'
import UserService from "../../../../HTTP/UserService";

export const UpdateUserForm = ({ updateUsers, setUpdateUsers, prevData }) => {

    const [userData, setUserData] = useState(prevData);

    const [updateUserFetching, loader2, error2] = useFetching(async () => {
        const formData = new FormData();
        Object.keys(userData).forEach(function (key, index) {
            formData.append(key, Object.values(userData)[index])
        })
        await UserService.updateUser(formData, prevData?.id)
    })
    async function updateUser(e) {
        e.preventDefault()
        try {
            await updateUserFetching()
        } catch (e) {
            console.error(error2)
        }
        setUserData({ name: '', description: '', startTime: '', endTime: '', location: '', cost: '' })
        setUpdateUsers(!updateUsers)
    }

    useEffect(() => {
        setUserData(prevData)
    }, [prevData]);

    if (loader2) return <MyLoader />

}
