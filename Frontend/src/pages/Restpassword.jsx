import { useState } from "react";
import {  useNavigate } from "react-router-dom";
import Changepassword from "./Changepassword";


export function Resetpassword() {
    const [email, setEmail] = useState('')
    const [otp, setOtp] = useState('')
    const [password, setPassword] = useState('')

    //const navigate = useNavigate();

    
    
    return (
        <>
            <h1 className="title">Reset Password</h1>
            <div className="row">
                <div className="col"></div>
                <div className="col">
                    <div className="form">
                        <div className="mb-3">
                            <label htmlFor="">Email</label>
                            <input onChange={e => setEmail(e.target.value)} type="email" placeholder="abc@test.com" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">Otp</label>
                            <input onChange={e => setOtp(e.target.value)} type="otp" placeholder="Enter OTP Here" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">Password</label>
                            <input onChange={e => setPassword(e.target.value)} type="password" placeholder="Enter Password Here" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <button className="btn btn-primary mt-2">
                                Submit
                            </button>
                        </div>
                    </div>
                </div>
                <div className="col"></div>
            </div>


        </>
    )
}

export default Resetpassword;