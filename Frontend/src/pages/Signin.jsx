import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { signinUser } from '../services/user';
import './Signin.css';

export function Signin() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const navigate = useNavigate();

    const onSignin = async () => {
        if (email.length === 0) {
            toast.warn('Enter email');
        } else if (password.length === 0) {
            toast.warn('Enter password');
        } else {
            // Make the API call
            const result = await signinUser(email, password);

            if (result.status === 'success') {
                const Token = result.data.token;
                sessionStorage.token = Token;
                toast.success('Welcome user');
                navigate('/home');
            } else {
                toast.error(result.error);
            }
        }
    };

    return (
        <>
            

            {/* Two-column layout */}
            <div className="container mt-4">
                <div className="row">
                    {/* Image column */}
                    <div className="col-md-8">
                        <img src="Login12.jpg" alt="Login" className="img-fluid rounded" />
                    </div>

                    {/* Login form column */}
                    <div className="col-md-4">
                        <h1 className="title">Sign In</h1>
                        <div className="card">
                            <div className="card-body">
                                <div className="mb-3">
                                    <label htmlFor="inputEmail" className="form-label">Email</label>
                                    <input
                                        onChange={(e) => setEmail(e.target.value)}
                                        type="email"
                                        className="form-control"
                                        id="inputEmail"
                                        placeholder="Enter your email"
                                    />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="inputPassword" className="form-label">Password</label>
                                    <input
                                        onChange={(e) => setPassword(e.target.value)}
                                        type="password"
                                        className="form-control"
                                        id="inputPassword"
                                        placeholder="Enter your password"
                                    />
                                    
                                </div>
                                <div className="mb-3">
                                        <div>Don't have an account? <Link to='/signup'>Signup here</Link></div>
                                        <div>Reset Password Here? <Link to='/Resetpassword'>Reset Password</Link></div>
                                        <div>Change Password Here? <Link to='/Changepassword'>Change Password</Link></div>
                                        </div>
                                <button onClick={onSignin} className="btn btn-primary mt-2">
                                    Sign In
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default Signin;

