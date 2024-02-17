import React from 'react';
import { Routes, Route } from 'react-router-dom';
import   Signin  from './pages/Signin';
import Signup from './pages/Signup';
import Home from './pages/Home';
import  Resetpassword  from './pages/Restpassword';
import Changepassword from './pages/Restpassword';
import Task from './pages/Task';
import AddTask from './pages/AddTask';
import AddProject from './pages/AddProject';
import Project from './pages/Project';
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
        <Route path='/resetpassword' element={<Resetpassword />} />
        <Route path='/changepassword' element={<Changepassword />} />
        <Route path='/home' element={<Home />} />
        <Route path='/task' element={<Task />} />
        <Route path='/addtask' element={<AddTask />} />
        <Route path='/project' element={<Project />} />
        <Route path='/addproject' element={<AddProject />} />
      </Routes>
      <ToastContainer />
    </div>
  );
}

export default App;
