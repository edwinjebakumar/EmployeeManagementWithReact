import logo from './logo.svg';
import './App.css';

import { Button } from 'react-bootstrap';
import { Home } from './components/Home';
import { Department } from './components/Department';
import { Employee } from './components/Employee';
import { Navigation } from './components/Navigation';

import { BrowserRouter, Routes, Route } from 'react-router-dom';
function App() {
  return (
    <div className="container">
      {/* <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header> */}

      {/* <h2>Hello react!</h2>
      <Button variant='primary'>Bootstrap button</Button> */}

      <h3 className='m-3 d-flex justify-content-center'>This is the App component</h3>
      <h5 className='m-3 d-flex justify-content-center'>Employee Management Portal</h5>
      
      <BrowserRouter>
      <Navigation></Navigation>
        <Routes>
          <Route path='/' Component={Home} />
          <Route path='/Department' Component={Department} />
          <Route path='/Employee' Component={Employee} />
        </Routes>
      </BrowserRouter>

    </div>
  );
}

export default App;
