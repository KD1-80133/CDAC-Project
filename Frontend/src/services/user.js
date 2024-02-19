import axios from 'axios';
import { createError, createUrl, createSuccess } from './utils';

export async function signupUser(userName, password, mobileNo, emailId, roleId) {
    try {
        const url = createUrl('User/SignUp');
        const body = {
            userName,
            password,
            mobileNo,
            emailId,
            roleId
        };
        const response = await axios.post(url, body);
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}

export async function signinUser(emailId, password) {
    try {
        const url = createUrl('User/Login');
        const body = {
            emailId,
            password,
        };
        const response = await axios.post(url, body);
        console.log(response.data);
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}
export async function changePassword(emailId, oldpassword, newpassword) {
    try {
        const url = createUrl('user/ChangePassword');
        const token = sessionStorage.getItem('token');
        const headers = {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json',
        };
        const body = {
            emailId,
            oldpassword,
            newpassword
        };
        console.log('Request Data:', body);
        const response = await axios.post(url, body, { headers });
        console.log('Response Data:', response.data);
        return createSuccess(response.data);
    } catch (ex) {
        console.error('Error:', ex);
        return createError(ex);
    }
}
