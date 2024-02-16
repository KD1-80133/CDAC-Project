import { Route, Routes } from "react-router-dom";
import Signin from './pages/Signin';
import Signup from './pages/Signup';
import Home from './pages/Home';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import ResetPassword from "./pages/Resetpassword";
import Changepassword from "./pages/Changepassword";
import Task from "./pages/Task";
import Project from "./pages/Project";
import AddTask from "./pages/AddTask";
import AddProject from "./pages/AddProject";

function App() {
  return (
    <div className="container-fluid">
      <Routes>
        <Route index element={<Signin />} />
        <Route path='/' element={<Signin />} />
        <Route path='/signin' element={<Signin />} />

        <Route path='/signup' element={<Signup />} />
        <Route path='/home' element={<Home />} />
        <Route path='/resetpassword' element={<ResetPassword />} />
        <Route path='/changepassword' element={<Changepassword />} />
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
