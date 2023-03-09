import React from 'react'
import s from './UserList.module.css'
import { UserItem } from "../UserItem/UserItem";

export const UserList = ({ users, setUpdateUsers, updateUsers, setPrevData,setIsUpdate }) => {
    if (!users.length) {
        return <div>
            <h1 style={{ textAlign: 'center' }}>
                Немає користувачів
            </h1>
        </div>
    }

    return (
        <div style={{ marginBottom: '50px' }}>
            <ul>
                {users.map((user) =>
                    <UserItem
                        setPrevData={setPrevData}
                        user={user}
                        key={user.id}
                        setUpdateUsers={setUpdateUsers}
                        updateUsers={updateUsers}
                        setIsUpdate={setIsUpdate}
                    />
                )}
            </ul>
        </div>

    )
}
