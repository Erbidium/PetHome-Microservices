import React from 'react'
import { AdvertItem } from '../AdvertItem/AdvertItem'
import s from './AdvertList.module.css'

export const AdvertList = ({ adverts, setUpdateAdverts, updateAdverts, setPrevData,setIsRedo }) => {
    if (!adverts.length) {
        return <div>
            <h1 style={{ textAlign: 'center' }}>
                Оголошень поки немає.
            </h1>
        </div>
    }

    return (
        <div style={{ marginBottom: '50px' }}>
            <ul>
                {adverts.map((advert) =>
                    <AdvertItem
                        setPrevData={setPrevData}
                        advert={advert}
                        key={advert.id}
                        setUpdateAdverts={setUpdateAdverts}
                        updateAdverts={updateAdverts}
                        setIsRedo={setIsRedo}
                    />
                )}
            </ul>
        </div>

    )
}