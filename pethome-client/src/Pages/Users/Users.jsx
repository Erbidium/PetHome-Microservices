import {useEffect, useState} from "react";
import s from './Users.module.css'
import {useFetching} from "../../Hooks/useFetching";
import UserService from "../../HTTP/UserService";
import {MyLoader} from "../../UI/MyLoader/MyLoader";
import {UserList} from "../../Components/Users/UserList/UserList";

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
    return (
        <div className={s.page}>


            <h1 style={{ textAlign: 'center', marginTop: '30px' }}> Усі оголошення</h1>
            <div>
                <UserList
                    users={users}
                    setUpdateAdverts={setUpdateUsers}
                    updateAdverts={updateUsers}
                    setPrevData={setPrevData}
                    setIsRedo={setIsUpdate}
                />
            </div>
        </div>
    )
}
