import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
import { signupUser } from '../services/user';
import './Signin.css';

export function Signup() {
    const [userName, setUserName] = useState('');
    const [email, setEmail] = useState('');
    const [mobileNo, setMobileNo] = useState('');
    const [password, setPassword] = useState('');
    const [roleId, setRoleId] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const navigate = useNavigate();

    const onSignup = async () => {
        if (userName.length === 0) {
            toast.warn('Enter username');
        } else if (email.length === 0) {
            toast.warn('Enter email');
        } else if (password.length === 0) {
            toast.warn('Enter password');
        } else if (confirmPassword.length === 0) {
            toast.warn('Enter confirm password');
        } else if (password !== confirmPassword) {
            toast.warn('Password does not match');
        } else {
            // make the API call
            const result = await signupUser(userName, password, mobileNo, email, roleId);
            if (result.status === 'success') {
                toast.success('Successfully registered the user');
                navigate('/');
            } else {
                toast.error(result.error);
            }
        }
    };

    return (
        <>
            <div className="container mt-4">
                <div className="row">
                    {/* Image column */}
                    <div className="col-md-8">
                        <img src="Login12.jpg" alt="Login" className="img-fluid rounded" />
                    </div>

                    {/* Signup form column */}
                    <div className="col-md-4">
                        <h1 className="title">Signup</h1>
                        <div className="form">
                            <div className="mb-3">
                                <label htmlFor="">Username</label>
                                <input onChange={(e) => setUserName(e.target.value)} type="text" className="form-control" />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="">Email</label>
                                <input onChange={(e) => setEmail(e.target.value)} type="email" placeholder="abc@test.com" className="form-control" />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="">Password</label>
                                <input onChange={(e) => setPassword(e.target.value)} type="password" placeholder="xxxxxxx" className="form-control" />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="">Confirm Password</label>
                                <input onChange={(e) => setConfirmPassword(e.target.value)} type="password" placeholder="xxxxxxx" className="form-control" />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="">Mobile No</label>
                                <input onChange={(e) => setMobileNo(e.target.value)} type="text" placeholder="10 Digit" className="form-control" />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="">Role ID</label>
                                <input onChange={(e) => setRoleId(e.target.value)} type="number" placeholder="1/2/3" className="form-control" />
                            </div>
                            <div className="mb-3">
                                <div>Already have an account? <Link to='/signin'>Sign in here</Link></div>
                                <button onClick={onSignup} className="btn btn-primary mt-2">
                                    Signup
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default Signup;
