import React from 'react'
import s from './AdvertItem.module.css'
import convertDate from '../../../Common/DateConverter'
import { MyButton } from '../../../UI/MyButton/MyButton'
import { useFetching } from '../../../Hooks/useFetching'
import AdvertService from '../../../HTTP/AdvertService'
import { MyLoader } from '../../../UI/MyLoader/MyLoader'


export const AdvertItem = ({ advert, setUpdateAdverts, updateAdverts }) => {

  const [deleteAdvertFetching, loader, error] = useFetching(async () => {
    await AdvertService.deleteAdvert(advert?.id)
  })

  async function deleteAdvert() {
    try {
      await deleteAdvertFetching()
      setUpdateAdverts(!updateAdverts)
    } catch (e) {
      console.error(error)
    }
  }

  if (loader) return <MyLoader />
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
        <div className={s.buttons}>
          <MyButton style={{ backgroundColor: 'rgba(230,0,0,1)', height: '30px' }} onClick={deleteAdvert}>Видалити</MyButton>
          <MyButton style={{ backgroundColor: 'rgba(160,210,20,1)', height: '30px' }}>Редагувати</MyButton>
        </div>
      </li>
    </div>
  )
}
