import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { signinUser } from '../services/user'

export function Signin() {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const navigate = useNavigate();

    const onSignin = async () => {
        if (email.length == 0) {
            toast.warn('enter email')
        } else if (password.length == 0) {
            toast.warn('enter password')
        } else {
            // make the api call
            const result = await signinUser(email, password)

            navigate('/home')

        }
    }

    return (
        <>
            <h1 className="title">Signin</h1>
            <div className="row">
                <div className="col"></div>
                <div className="col">
                    <div className="form">
                        <div className="mb-3">
                            <label htmlFor="">Email</label>
                            <input onChange={e => setEmail(e.target.value)} type="email" placeholder="abc@test.com" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">Password</label>
                            <input onChange={e => setPassword(e.target.value)} type="password" placeholder="xxxxxxx" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <div>Don't have an account?<Link to='/signup'>Signup here</Link></div>
                            <div>Reset Password Here?<Link to='/Resetpassword'>Reset Password</Link></div>
                            <div>Change Password Here?<Link to='/Changepassword'>Change Password</Link></div>
                            <button onClick={onSignin} className="btn btn-primary mt-2">
                                signin
                            </button>


                        </div>
                    </div>
                </div>
                <div className="col"></div>
            </div>


        </>
    )
}
export default Signin;
