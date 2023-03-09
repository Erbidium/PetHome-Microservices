import React from 'react'
import s from './UserItem.module.css'
import { MyButton } from '../../../UI/MyButton/MyButton'
import { useFetching } from '../../../Hooks/useFetching'
import { MyLoader } from '../../../UI/MyLoader/MyLoader'
import UserService from "../../../HTTP/UserService";


export const UserItem = ({ user, setUpdateUsers, updateUsers, setPrevData, setIsUpdate }) => {

  const [deleteUserFetching, loader, error] = useFetching(async () => {
    await UserService.deleteUser(user?.id)
  })

  async function deleteUser() {
    try {
      await deleteUserFetching()
      setUpdateUsers(!updateUsers)
    } catch (e) {
      console.error(error)
    }
  }

  async function updateUser() {
    setPrevData(user)
    setIsUpdate(true)
  }

  if (loader) return <MyLoader />
  return (
    <div>
      <li className={s.userItem}>
        <div className={s.userName}>
          <strong>
            {user?.name}
          </strong>
        </div>
        <div className={s.infoSection}>
          <div className={s.userInfo}>
            <div>Email: {user?.email}</div>
            <div>📍{user?.location}</div>
          </div>
        </div>
        <div className={s.buttons}>
          <MyButton style={{ backgroundColor: 'rgba(230,0,0,1)', height: '30px' }} onClick={deleteUser}>Видалити</MyButton>
          <MyButton style={{ backgroundColor: 'rgba(160,210,20,1)', height: '30px' }} onClick={updateUser}>Редагувати</MyButton>
        </div>
      </li>
    </div>
  )
}
