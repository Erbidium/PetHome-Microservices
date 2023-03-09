import {useEffect, useState} from "react";
import s from './Requests.module.css'
import {useFetching} from "../../Hooks/useFetching";
import RequestService from "../../HTTP/RequestService";
import { RequestList } from '../../Components/Requests/RequestList/RequestList';
import {MyLoader} from "../../UI/MyLoader/MyLoader";
import { CreateRequestForm } from '../../Components/Requests/Forms/CreateRequestForm';

export default function Requests() {
    const [requests, setRequests] = useState([]);
    const [updateRequests, setUpdateRequests] = useState(false);
    const [prevData, setPrevData] = useState({});

    const [fetchRequests, loader, error] = useFetching(async () => {
        const response = await RequestService.getAllRequests()
        setRequests(response.data)
    })

    useEffect(() => {
        async function fetch() {
            try {
                await fetchRequests()
            } catch (e) {
                console.error(error)
            }
        }
        fetch()
    }, [updateRequests])

    if (loader) return <MyLoader />
    return (
        <div className={s.page}>
          <h1 style={{ textAlign: 'center', marginTop: '30px' }}> Створення  Заявки</h1>
          <CreateRequestForm
            updateRequests={updateRequests}
            setUpdateRequests={setUpdateRequests}
            prevData={prevData}
          />
          <h1 style={{ textAlign: 'center', marginTop: '30px' }}> Усі Заявки</h1>
          <div>
            <RequestList
              requests={requests}
              setUpdateRequests={setUpdateRequests}
              updateRequests={updateRequests}
              setPrevData={setPrevData}
            />
          </div>
        </div>
      )
}