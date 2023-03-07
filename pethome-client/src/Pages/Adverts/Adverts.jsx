import { useEffect, useState } from 'react';
import s from './Adverts.module.css'
import AdvertService from '../../HTTP/AdvertService';
import { useFetching } from '../../Hooks/useFetching';
import { MyLoader } from '../../UI/MyLoader/MyLoader';
import { AdvertList } from '../../Components/Adverts/AdvertList/AdvertList';

export default function Adverts() {
  const [adverts, setAdverts] = useState([]);

  const [fetchAdverts, loader, error] = useFetching(async () => {
    const response = await AdvertService.getAllAdverts()
    setAdverts(response.data)
  })

  useEffect(() => {
    async function fetchData() {
      try {
        await fetchAdverts()
      } catch (e) {
        console.error(error)
      }
    }
    fetchData();
  }, [])

  return (
    <div className={s.page}>
      <h1 style={{ textAlign: 'center', marginTop: '30px' }}> Усі оголошення</h1>
      {loader
        ? <div style={{ display: 'flex', justifyContent: 'center', marginTop: '50px' }}><MyLoader /></div>
        :
        <div>
          <AdvertList
            adverts={adverts}
          />
        </div>
      }
    </div>
  )
}
