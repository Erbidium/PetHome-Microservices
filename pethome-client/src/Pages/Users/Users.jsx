import {useEffect, useState} from "react";
import s from './Users.module.css'
import {useFetching} from "../../Hooks/useFetching";
import UserService from "../../HTTP/UserService";
import {MyLoader} from "../../UI/MyLoader/MyLoader";
import {UserList} from "../../Components/Users/UserList/UserList";
import {CreteUserForm} from "../../Components/Users/Forms/CreateUserForm/CreateUserForm";
import {UpdateUserForm} from "../../Components/Users/Forms/UpdateUserForm/UpdateUserForm";

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
        {
            isUpdate ?
                <UpdateUserForm
                    updateUsers={updateUsers}
                    setUpdateUsers={setUpdateUsers}
                    prevData={prevData}
                />
                :
                <CreteUserForm
                    updateUsers={updateUsers}
                    setUpdateUsers={setUpdateUsers}
                    prevData={{ name: '', email: '', location: '', password: '' }}
                />
        }

            <h1 style={{ textAlign: 'center', marginTop: '30px' }}> Усі користувачі</h1>
            <div>
                <UserList
                    users={users}
                    setUpdateUsers={setUpdateUsers}
                    updateUsers={updateUsers}
                    setPrevData={setPrevData}
                    setIsUpdate={setIsUpdate}
                />
            </div>
        </div>
    )
}
