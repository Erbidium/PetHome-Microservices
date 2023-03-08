import { useEffect, useState } from 'react';
import s from './Adverts.module.css'
import AdvertService from '../../HTTP/AdvertService';
import { useFetching } from '../../Hooks/useFetching';
import { MyLoader } from '../../UI/MyLoader/MyLoader';
import { AdvertList } from '../../Components/Adverts/AdvertList/AdvertList';

export default function Adverts() {
  const [adverts, setAdverts] = useState([]);
  const [updateAdverts, setUpdateAdverts] = useState(false);

  const [fetchAdverts, loader, error] = useFetching(async () => {
    const response = await AdvertService.getAllAdverts()
    setAdverts(response.data)
  })

  useEffect(() => {
    async function fetch() {
      try {
        await fetchAdverts()
      } catch (e) {
        console.error(error)
      }
    }
    fetch()
  }, [updateAdverts])


  if (loader) return <MyLoader />

  return (
    <div className={s.page}>
      <h1 style={{ textAlign: 'center', marginTop: '30px' }}> Усі оголошення</h1>

      <div>
        <AdvertList
          adverts={adverts}
          setUpdateAdverts={setUpdateAdverts}
          updateAdverts={updateAdverts}
        />
      </div>
    </div>
  )
}
