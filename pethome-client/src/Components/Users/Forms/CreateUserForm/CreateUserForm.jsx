import React, { useState,useEffect } from 'react'
import { useFetching } from '../../../../Hooks/useFetching'
import s from './CreateUserForm.module.css'
import { MyLoader } from '../../../../UI/MyLoader/MyLoader'
import UserService from "../../../../HTTP/UserService";

export const CreteUserForm = ({ updateUsers, setUpdateUsers, prevData }) => {

    const [userData, setUserData] = useState(prevData);

    const [createUserFetching, loader, error] = useFetching(async () => {
        const formData = new FormData();
        Object.keys(userData).forEach(function (key, index) {
            formData.append(key, Object.values(userData)[index])
        })
        await UserService.createUser(formData)
    })

    async function createUser(e) {
        e.preventDefault()
        console.log(userData)
        try {
            await createUserFetching()
        } catch (e) {
            console.error(error)
        }
        setUserData({ name: '', description: '', startTime: '', endTime: '', location: '', cost: '' })
        setUpdateUsers(!updateUsers)
    }

    useEffect(() => {
        setUserData(prevData)
    }, [prevData]);

    if (loader) return <MyLoader />

}
