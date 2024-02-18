import axios from "axios";
import { createError, createUrl, createSuccess } from './utils';


export async function getAllEmployee() {

    const token = sessionStorage.getItem('token'); 
    
    const headers = {
        'Authorization': `Bearer ${token}`
    };

    try {
        const url = createUrl('Employee');
        
        const response = await axios.get(url, {headers});
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}



export async function getEmployee(id) {
    try {
        const url = createUrl(`Employee/${id}`);
        const headers = {
            headers: {
                'Authorization': `Bearer ${sessionStorage.token}`,
            },
        };
        const response = await axios.get(url, headers);
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}


export async function deleteEmployee(id) {
    try {
        const url = createUrl(`Employee/${id}`);
        const headers = {
            headers: {
                'Authorization': `Bearer ${sessionStorage.token}`,
            },
        };
        const response = await axios.delete(url, headers);
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}


export async function AddEmployee(firstName, lastName, hireDate, designationId, hourlyRate, deptId, managerId, userId) {
    try {
        const url = createUrl('Employee');
        const headers = {
            headers: {
                'Authorization': `Bearer ${sessionStorage.token}`,
                'Content-Type': 'application/json',
            },
        };
        const body = {
            firstName,
            lastName,
            hireDate,
            designationId,
            hourlyRate,
            deptId,
            managerId,
            userId
        };
        const response = await axios.post(url, body, headers);
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}


export async function updateEmployee(id, firstName, lastName, hireDate, designationId, hourlyRate, deptId, managerId, userId) {
    try {
        // Convert hireDate to the required format "yyyy-MM-dd"
        const formattedHireDate = new Date(hireDate).toISOString().split('T')[0];
        
        const url = createUrl(`Employee/${id}`);
        const headers = {
            headers: {
                'Authorization': `Bearer ${sessionStorage.token}`,
                'Content-Type': 'application/json',
            },
        };
        const body = {
            firstName,
            lastName,
            hireDate: formattedHireDate, // Use the formatted hireDate
            designationId,
            hourlyRate,
            deptId,
            managerId,
            userId
        };
        const response = await axios.put(url, body, headers);
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}



