import React from 'react';
import { Routes, Route } from 'react-router-dom';
import   Signin  from './pages/Signin';
import Signup from './pages/Signup';
import Home from './pages/Home';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return (
    <div className="container">
      <Routes>
        <Route index element={<Signin />} />
        <Route path='/' element={<Signin />} />
        <Route path='/Signin' element={<Signin />} />
        <Route path='/signup' element={<Signup />} />
        <Route path='/home' element={<Home />} />
      </Routes>
      <ToastContainer />
    </div>
  );
}

export default App;
