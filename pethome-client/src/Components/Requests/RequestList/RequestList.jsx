import React from 'react'
import { RequestItem } from '../../Requests/RequestItem/RequestItem'
import s from './RequestList.module.css'

export const RequestList = ({ requests, setUpdateRequests, updateRequests, setPrevData, setIsRedo }) => {
    if (!requests.length) {
        return <div>
            <h1 style={{ textAlign: 'center' }}>
                Заявок поки немає.
            </h1>
        </div>
    }

    return (
        <div style={{ marginBottom: '50px' }}>
            <ul>
                {requests.map((request) =>
                    <RequestItem
                        setPrevData={setPrevData}
                        request={request}
                        key={request.id}
                        setUpdateRequests={setUpdateRequests}
                        updateRequests={updateRequests}
                        setIsRedo={setIsRedo}
                    />
                )}
            </ul>
        </div>

    )
}