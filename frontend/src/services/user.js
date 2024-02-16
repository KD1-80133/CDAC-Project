import axios from 'axios';
import { createError, createUrl, createSuccess } from './utils'

export async function signupUser(userName, password, mobileNo, emailId, roleId) {
    try {
        const url = createUrl('User/SignUp')
        const body = {
            userName,
            password,
            mobileNo,
            emailId,
            roleId
        }
        const response = await axios.post(url, body)
        return createSuccess(response.data)
    } catch (ex) {
        return createError(ex)
    }
}

export async function signinUser(emailId, password) {
    try {
        const url = createUrl('User/Login')
        const body = {
            emailId,
            password,
        }
        const response = await axios.post(url, body)
        return createSuccess(response.data)
    } catch (ex) {
        return createError(ex)
    }
}

export async function changePassword(emailId, oldpassword,newpassword) {
    
    try {
        const url = createUrl('user/ChangePassword')
        const body = {
            emailId,
            oldpassword,
            newpassword
        }
        const response = await axios.post(url, body)
        console.log(response.data);
        return createSuccess(response.data)
    } catch (ex) {
        return createError(ex)
    }
}