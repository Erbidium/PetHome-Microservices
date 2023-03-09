import {useEffect, useState} from "react";
import {useFetching} from "../../Hooks/useFetching";
import AdvertService from "../../HTTP/AdvertService";
import UserService from "../../HTTP/UserService";
import {MyLoader} from "../../UI/MyLoader/MyLoader";

export default function Users() {
    const [users, setUsers] = useState([]);
    const [updateUsers, setUpdateUsers] = useState(false);
    const [prevData, setPrevData] = useState({});
    const [isUpdate, setIsUpdate] = useState(false);

    const [fetchUsers, loader, error] = useFetching(async () => {
        const response = await UserService.getAllUsers()
        setUsers(response.data)
    })

    useEffect(() => {
        async function fetch() {
            try {
                await fetchUsers()
            } catch (e) {
                console.error(error)
            }
        }
        fetch()
    }, [updateUsers])

    if (loader) return <MyLoader />
    return <div>Users</div>
}
