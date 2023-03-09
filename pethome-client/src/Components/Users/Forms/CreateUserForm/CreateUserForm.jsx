import React, { useState,useEffect } from 'react'
import { useFetching } from '../../../../Hooks/useFetching'
import s from './CreateUserForm.module.css'
import { MyLoader } from '../../../../UI/MyLoader/MyLoader'
import UserService from "../../../../HTTP/UserService";
import {MyInput} from "../../../../UI/Inputs/MyInput";
import {MyTextArea} from "../../../../UI/TextArea/MyTextArea";
import {MyButton} from "../../../../UI/MyButton/MyButton";

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
    return (
        <div className={s.form}>
            <form>
                <MyInput
                    placeholder='Введіть назву'
                    value={userData?.name}
                    onChange={e => setUserData({ ...userData, name: e.target.value })}
                />
                <MyInput
                    placeholder='Введіть email'
                    value={userData?.email}
                    onChange={e => setUserData({ ...userData, email: e.target.value })}
                />
                <MyInput
                    placeholder='Введіть локацію'
                    value={userData?.location}
                    onChange={e => setUserData({ ...userData, location: e.target.value })}
                />
                <MyInput
                    placeholder='Введіть пароль'
                    value={userData?.password}
                    onChange={e => setUserData({ ...userData, password: e.target.value })}
                />
                <MyButton onClick={(e) => createUser(e)}>Створити користувача</MyButton>
            </form>
        </div>
    )
}
