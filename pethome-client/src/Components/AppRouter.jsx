import { React } from 'react'
import { Route, Routes } from "react-router-dom";
import Adverts from '../Pages/Adverts/Adverts';
import Requests from '../Pages/Requests/Requests';
import Users from '../Pages/Users/Users';
import Auth from '../Pages/Auth/Auth';

export default function AppRouter() {
    return (
        <Routes>
          <Route path="/adverts" element=<Adverts /> exact />
          <Route path="/requests" element=<Requests /> exact />
          <Route path="/users" element=<Users /> exact />
          <Route path="/auth" element=<Auth /> exact />
        </Routes>
    );
  }