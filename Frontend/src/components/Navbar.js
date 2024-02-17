import { Link, useNavigate } from "react-router-dom";

export function Navbar() {
    const navigate = useNavigate();
    const onLogout = () => {
        sessionStorage.removeItem('token');
        navigate('/')
    }
    return (<>
        <nav className="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
            <div className="container-fluid">
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
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
                        <li>
                            <button onClick={onLogout} className="nav-link" aria-current="page">LogOut</button>
                        </li>
                    </ul>

                </div>
            </div>
        </nav >
    </>)
}
export default Navbar;