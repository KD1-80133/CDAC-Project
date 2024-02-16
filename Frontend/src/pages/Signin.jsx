// import { useState } from "react";
// import { Link, useNavigate } from "react-router-dom";
// import { toast } from "react-toastify";
// import { signinUser } from '../services/user'

// export function Signin() {
//     const [emailId, setEmail] = useState('')
//     const [password, setPassword] = useState('')

//     const navigate = useNavigate();

//     const onSignin = async () => {
//         console.log('Email:', emailId);
//     console.log('Password:', password);
//         if (emailId.length === 0) {
//             toast.warn('enter email')
//         } else if (password.length === 0) {
//             toast.warn('enter password')
//         } else {
//             try{
//             // make the api call
//             const result = await signinUser(emailId, password)
//             console.log('API Result:',result);

//             if (result&&result.status ==='success') {
//                 const Token = result.data.token;
//                 sessionStorage.setItem('token' , Token);
//                 toast.success('Successfully signed in');
//                 navigate('/home')
//             }
//             else{
//                 toast.error('Invalid credntials.. Please try again..');
//             }
//         }catch(error)
//         {
//             console.error('API Error:',error);
//             toast.error('An error occurred.Please try again later.');
//         }
//         }
//     };
//     return (
//         <>
//             <h1 className="title">Signin</h1>
//             <div className="row">
//                 <div className="col"></div>
//                 <div className="col">
//                     <div className="form">
//                         <div className="mb-3">
//                             <label htmlFor="">EmailId</label>
//                             <input onChange={e => setEmail(e.target.value)} type="emailId" placeholder="abc@test.com" className="form-control" />
//                         </div>
//                         <div className="mb-3">
//                             <label htmlFor="">Password</label>
//                             <input onChange={e => setPassword(e.target.value)} type="password" placeholder="xxxxxxx" className="form-control" />
//                         </div>
//                         <div className="mb-3">
//                             <div>Don't have an account?<Link to='/signup'>Signup here</Link></div>
//                             <button onClick={onSignin} className="btn btn-primary mt-2">
//                                 signin
//                             </button>


//                         </div>
//                     </div>
//                 </div>
//                 <div className="col"></div>
//             </div>


//         </>
//     )
// }
// export default Signin;
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
            // console.log(result.data.token);

            if (result['status'] == 'success') {
                const Token = result.data.token;
                sessionStorage.token = Token
                toast.success('Welcome user')
                navigate('/home')
            }
            else {
                toast.error(result['error'])
            }
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