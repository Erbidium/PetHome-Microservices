import React, { useState } from 'react'
import { MyInput } from '../../../UI/Inputs/MyInput'
import { MyButton } from '../../../UI/MyButton/MyButton'
import { MyTextArea } from '../../../UI/TextArea/MyTextArea'
import AdvertService from '../../../HTTP/AdvertService'
import { useFetching } from '../../../Hooks/useFetching'
import s from './CreateAdvertForm.module.css'
import { MyLoader } from '../../../UI/MyLoader/MyLoader'

export const CreteAdvertForm = ({ updateAdverts, setUpdateAdverts }) => {

    const [advertData, setAdvertData] = useState({ name: '', description: '', startTime: '', endTime: '', location: '', cost: '' });

    const [createAdvertFetching, loader, error] = useFetching(async () => {
        const formData = new FormData();
        Object.keys(advertData).forEach(function (key, index) {
            formData.append(key, Object.values(advertData)[index])
        })
        await AdvertService.createAdvert(formData)
    })

    async function createAdvert(e) {
        e.preventDefault()
        console.log(advertData)
        try {
            await createAdvertFetching()
        } catch (e) {
            console.error(error)
        }
        setAdvertData({ name: '', description: '', startTime: '', endTime: '', location: '', cost: '' })
        setUpdateAdverts(!updateAdverts)
    }

    if (loader) return <MyLoader />
    return (
        <div className={s.form}>
            <form>
                <MyInput
                    placeholder='Введіть назву'
                    value={advertData.name}
                    onChange={e => setAdvertData({ ...advertData, name: e.target.value })}
                />
                <MyTextArea
                    placeholder='Введіть опис'
                    value={advertData.description}
                    onChange={e => setAdvertData({ ...advertData, description: e.target.value })}
                />
                <MyInput
                    placeholder='Введіть дату початку'
                    value={advertData.startTime}
                    onChange={e => setAdvertData({ ...advertData, startTime: e.target.value })}
                />
                <MyInput
                    placeholder='Введіть дату закінчення'
                    value={advertData.endTime}
                    onChange={e => setAdvertData({ ...advertData, endTime: e.target.value })}
                />
                <MyInput
                    placeholder='Введіть локацію'
                    value={advertData.location}
                    onChange={e => setAdvertData({ ...advertData, location: e.target.value })}
                />
                <MyInput
                    placeholder='Введіть суму виплати'
                    type='number'
                    value={advertData.cost}
                    onChange={e => setAdvertData({ ...advertData, cost: e.target.value })}
                />
                <MyButton onClick={(e) => createAdvert(e)}>Створити оголошення</MyButton>
            </form>
        </div>
    )
}
