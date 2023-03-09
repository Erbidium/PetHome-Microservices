import React from 'react'
import s from './RequestItem.module.css'
import convertDate from '../../../Common/DateConverter'
import { MyButton } from '../../../UI/MyButton/MyButton'
import { useFetching } from '../../../Hooks/useFetching'
import RequestService from '../../../HTTP/RequestService'
import { MyLoader } from '../../../UI/MyLoader/MyLoader'


export const RequestItem = ({ request, setUpdateRequests, updateRequests }) => {

  const [deleteRequestFetching, loader, error] = useFetching(async () => {
    await RequestService.deleteRequest(request?.id)
  })

  const [applyRequestFetching, loader2, error2] = useFetching(async () => {
    await RequestService.applyRequest(request?.id)
  })

  const [confirmRequestFetching, loader3, error3] = useFetching(async () => {
    await RequestService.confirmRequest(request?.id)
  })

  const [rejectRequestFetching, loader4, error4] = useFetching(async () => {
    await RequestService.rejectRequest(request?.id)
  })

  async function deleteRequest() {
    try {
      await deleteRequestFetching()
      setUpdateRequests(!updateRequests)
    } catch (e) {
      console.error(error)
    }
  }

  async function applyRequest() {
    try {
      await applyRequestFetching()
      setUpdateRequests(!updateRequests)
    } catch (e) {
      console.error(error2)
    }
  }

  async function confirmRequest() {
    try {
      await confirmRequestFetching()
      setUpdateRequests(!updateRequests)
    } catch (e) {
      console.error(error3)
    }
  }

  async function rejectRequest() {
    try {
      await rejectRequestFetching()
      setUpdateRequests(!updateRequests)
    } catch (e) {
      console.error(error4)
    }
  }

  if (loader || loader2 || loader3 || loader4) return <MyLoader />
  return (
    <div>
      <li className={s.requestItem}>
        <div className={s.infoSection}>
          <div className={s.requestInfo}>
            <div className={s.requestName}><strong>Request ID:</strong> {request?.id}</div>
            <div className={s.requestName}><strong>From user ID:</strong> "{request?.userId}"</div>
            <div className={s.requestName}><strong>To advert ID:</strong> {request?.advertId}</div>
            <div className={s.requestName}><strong>State:</strong> {request?.status}</div>
          </div>
        </div>
        <div className={s.buttons}>
          <MyButton style={{ backgroundColor: 'rgba(230,0,0,1)', height: '30px' }} onClick={deleteRequest}>Видалити</MyButton>
          <MyButton style={{ backgroundColor: 'rgba(150,150,150,1)', height: '30px' }} onClick={applyRequest}>a</MyButton>
          <MyButton style={{ backgroundColor: 'rgba(160,210,20,1)', height: '30px' }} onClick={confirmRequest}>c</MyButton>
          <MyButton style={{ backgroundColor: 'rgba(250,20,20,1)', height: '30px' }} onClick={rejectRequest}>r</MyButton>
        </div>
      </li>
    </div>
  )
}
