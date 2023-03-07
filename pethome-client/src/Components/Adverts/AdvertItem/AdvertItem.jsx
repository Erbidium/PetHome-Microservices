import React from 'react'
import s from './AdvertItem.module.css'
import convertDate from '../../../Common/DateConverter'

export const AdvertItem = ({ advert }) => {
  console.log(advert)
  return (
    <div>
      <li className={s.advertItem}>
        <div className={s.advertName}>
          <strong>
            {advert?.name}
          </strong>
        </div>
        <div className={s.infoSection}>
          <div className={s.advertInfo}>
            <div className={s.advertDescription}>
              {advert?.description}
            </div>
            <div className={s.advertTime}>
              {convertDate(advert?.startTime)} - {convertDate(advert?.endTime)
              }</div>
            <div className={s.advertLocation}>📍{advert?.location}</div>
          </div>
          <div className={s.advertCost}>{advert?.cost} ГРН</div>
        </div>
      </li>
    </div>
  )
}
