import {useEffect, useState} from "react";
import {useFetching} from "../../Hooks/useFetching";
import RequestService from "../../HTTP/RequestService";
import {MyLoader} from "../../UI/MyLoader/MyLoader";

export default function Requests() {
    const [requests, setRequests] = useState([]);
    const [updateRequests, setUpdateRequests] = useState(false);
    const [prevData, setPrevData] = useState({});
    const [isUpdate, setIsUpdate] = useState(false);

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
    return <div>Users</div>
}