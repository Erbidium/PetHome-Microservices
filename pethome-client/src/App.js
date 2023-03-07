import { BrowserRouter } from "react-router-dom"
import AppRouter from "./Components/AppRouter.jsx";
import NavBar from './NavigationBar/NavBar.jsx'
import './Styles/App.css';
function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <NavBar />
        <AppRouter />
      </BrowserRouter>
    </div>
  );
}

export default App;
