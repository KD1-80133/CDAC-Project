import { useState } from "react";
import { toast } from 'react-toastify';
import { Link, useNavigate } from 'react-router-dom';
import { changePassword } from "../services/user";

export function Changepassword() {
    const [email, setEmail] = useState('');
    const [oldpassword, setOldpassword] = useState('');
    const [newpassword, setNewpassword] = useState('');

    const navigate = useNavigate();

    const onChangePassword = async () => {
        if (email.length === 0) {
            toast.warn('Enter email');
        } else if (oldpassword.length === 0) {
            toast.warn('Enter old password');
        } else if (newpassword.length === 0) {
            toast.warn('Enter new password');
        } else {
            // make the api call
            const result = await changePassword(email, oldpassword, newpassword);
            console.log(result);
            if (result.status === 'success') {
                toast.success('Successfully changed password');
                navigate('/');
            } else {
                toast.error(result.error);
            }
        }
    }

    return (
        <>
            <h1 className="title">Change Password</h1>
            <div className="row">
                <div className="col"></div>
                <div className="col">
                    <div className="form">
                        <div className="mb-3">
                            <label htmlFor="email">Email</label>
                            <input onChange={e => setEmail(e.target.value)} type="email" placeholder="abc@test.com" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="oldpassword">Old Password</label>
                            <input onChange={e => setOldpassword(e.target.value)} type="password" placeholder="Enter old password here" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="newpassword">New Password</label>
                            <input onChange={e => setNewpassword(e.target.value)} type="password" placeholder="Enter new password here" className="form-control" />
                        </div>
                        <div className="mb-3">
                            <button onClick={onChangePassword} className="btn btn-primary mt-2">
                                Submit
                            </button>
                        </div>
                    </div>
                </div>
                <div className="col"></div>
            </div>
        </>
    );
}

export default Changepassword;
