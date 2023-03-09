import React, { useState,useEffect } from 'react'
import { MyInput } from '../../../UI/Inputs/MyInput'
import { MyButton } from '../../../UI/MyButton/MyButton'
import { MyTextArea } from '../../../UI/TextArea/MyTextArea'
import RequestService from '../../../HTTP/RequestService'
import { useFetching } from '../../../Hooks/useFetching'
import s from './CreateRequestForm.module.css'
import { MyLoader } from '../../../UI/MyLoader/MyLoader'

export const CreateRequestForm = ({ updateRequests, setUpdateRequests, prevData }) => {

    const [requestData, setRequestData] = useState(prevData);

    const [createRequestFetching, loader, error] = useFetching(async () => {
        const formData = new FormData();
        Object.keys(requestData).forEach(function (key, index) {
            formData.append(key, Object.values(requestData)[index])
        })
        await RequestService.createRequest(formData)
    })

    async function createRequest(e) {
        e.preventDefault()
        try {
            await createRequestFetching()
        } catch (e) {
            console.error(error)
        }
        setRequestData({ advertId: ' '})
        setUpdateRequests(!updateRequests)
    }

    useEffect(() => {
        setRequestData(prevData)
    }, [prevData]);

    if (loader) return <MyLoader />
    return (
        <div className={s.form}>
            <form>
                <MyInput
                    placeholder='Введіть ID оголошення'
                    type='number'
                    value={requestData?.advertId}
                    onChange={e =>
                        {
                        console.log(e.target.value)
                        setRequestData({ ...requestData, advertId: e.target.value })
                    }}
                    
                />
                <MyButton onClick={(e) => createRequest(e)}>Створити заявку</MyButton>
            </form>
        </div>
    )
}
