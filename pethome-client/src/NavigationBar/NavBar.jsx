import s from './NavBar.module.css'
import { Link } from 'react-router-dom';
import { React} from 'react'
import Logo from '../Assets/PetHome.png'

export default function NavBar() {
    return (
        <div className={s.navBar}>
            <Link to="/about"><img src={Logo} alt='logo' href='/adverts' /></Link>
            <div className= {s.menu}>
                <Link to="/adverts" >Оголошення</Link>
                <Link to="/requests">Заявки</Link>
                <Link to="/users" >Користувачі</Link>
                <Link to="/auth">Авторизація</Link>
            </div>
        </div>
    )
}