import { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { toast } from 'react-toastify'
import { signupUser } from '../services/user'

export function Signup() {
    const [userName, setuserName] = useState('')
    const [email, setEmail] = useState('')
    const [mobileNo, setmobileNo] = useState('')
    const [password, setPassword] = useState('')
    const [roleId, setroleId] = useState('')
    const [confirmPassword, setConfirmPassword] = useState('')

    const navigate = useNavigate();

    const onSignup = async () => {
        if (userName.length == 0) {
            toast.warn('enter userName')
        } else if (email.length == 0) {
            toast.warn('enter email')
        } else if (password.length == 0) {
            toast.warn('enter password')
        } else if (confirmPassword.length == 0) {
            toast.warn('enter confirm password')
        } else if (password != confirmPassword) {
            toast.warn('password does not match')
        } else {
            // make the api call
            const result = await signupUser(userName, password, mobileNo, email, roleId)
            if (result['status'] == 'success') {
                toast.success('Successfully registered the user')
                navigate('/')
            } else {
                toast.error(result['error'])
            }
        }
        
    }

    return (
        <>
            <h1 className="title">Signup</h1>
            <div className="row">
                <div className="col"></div>
                <div className="col">
                    <div className="form">
                        <div className="mb-3">
                            <label htmlFor="">userName</label>
                            <input onChange={e => setuserName(e.target.value)} type="text" className="form-control" />
                        </div>
                        {/* <div className="mb-3">
                            <label htmlFor="">Last Namw</label>
                            <input onChange={e => setLastName(e.target.value)} type="text" className="form-control" />
                        </div> */}
                        <div className="mb-3">
                            <label htmlFor="">Email</label>
                            <input onChange={e => setEmail(e.target.value)} type="email" placeholder="abc@test.com" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">Password</label>
                            <input onChange={e => setPassword(e.target.value)} type="password" placeholder="xxxxxxx" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">confirm Password</label>
                            <input onChange={e => setConfirmPassword(e.target.value)} type="password" placeholder="xxxxxxx" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">Mobile No</label>
                            <input onChange={e => setmobileNo(e.target.value)} type="text" placeholder="10 Digit" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="">RoleID</label>
                            <input onChange={e => setroleId(e.target.value)} type="number" placeholder="1/2/3" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <div>already have an account?<Link to='/'>Signin here</Link></div>
                            <button onClick={onSignup} className="btn btn-primary mt-2">
                                signup
                            </button>


                        </div>
                    </div>
                </div>
                <div className="col"></div>
            </div>


        </>
    )
}
export default Signup;
