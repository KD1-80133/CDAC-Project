// Navbar.js

import React from "react";
import { Link, useNavigate } from "react-router-dom";
import "./Navbar.css";

export function Navbar() {
    const navigate = useNavigate();
    const onLogout = () => {
        sessionStorage.removeItem('token');
        navigate('/');
    };

    return (
        <nav className="navbar navbar-expand-lg " data-bs-theme="dark">
            <div className="container-fluid">
                <div className="navbar-brand">Employee Task Management</div>
                <div className="navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                            <Link className="nav-link" aria-current="page" to="/home">Home</Link>
                        </li>
                        <li>
                            <Link className="nav-link" aria-current="page" to="/employee">Employee</Link>
                        </li>
                        <li>
                            <Link className="nav-link" aria-current="page" to="/project">Project</Link>
                        </li>
                        <li>
                            <Link className="nav-link" aria-current="page" to="/task">Task</Link>
                        </li>
                        
                    </ul>
                    <button onClick={onLogout} className="btn btn-outline-light">Logout</button>
                </div>
            </div>
        </nav>
    );
}

export default Navbar;
