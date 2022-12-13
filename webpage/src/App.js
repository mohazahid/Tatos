// import logo from './logo.svg';
import './App.css';
import Navbar from './Navbar'
import Home from './pages/home'
import Game from './pages/game'
import Credits from './pages/credits'
import Logs from './pages/logs'
import {Route, Routes} from 'react-router-dom'

function App() {
  return (
  <>
    <Navbar />
      <div className="containers">
        <Routes> 
          <Route path="/" element={<Home />} />
          <Route path ="/game" element={<Game />} />
          <Route path ="/credits" element={<Credits />} />
          <Route path ="/logs" element={<Logs />} />
        </Routes>
      </div>
    </>
  )
}

export default App;
