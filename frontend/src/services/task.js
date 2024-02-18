import axios from 'axios';
import { createError, createUrl, createSuccess } from './utils'

export async function getAllTask() {
    
    const token = sessionStorage.getItem('token'); 
    
    const headers = {
        'Authorization': `Bearer ${token}`
    };

    try {
        const url = createUrl('Task')
       
        const response = await axios.get(url, { headers });
       
        return createSuccess(response.data)
    } catch (ex) {
       
        return createError(ex)
    }
};

export async function addTask(userId, taskDescription, startDate, endDate,Status,projectId) {
    const getHeaders = () => {
        const token = sessionStorage.getItem('token');
    
        if (token) {
            return {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json' 
            };
        } else {
            return {
                'Content-Type': 'application/json' 
            };
        }
    };

    try {
        const url = createUrl('Task');

        const body = {
                        userId,
                        taskDescription,
                        startDate,
                        endDate,
                        Status,
                        projectId,
                      
        };

        const headers = getHeaders();

        const response = await axios.post(url, body, { headers });

        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}

export async function deleteTask(id) {
    try {
        const url = createUrl(`Task/${id}`);
        const token = sessionStorage.getItem('token');

        if (!token) {
            throw new Error('Token is missing');
        }

        const headers = {
            'Authorization': `Bearer ${token}`,
        };

        const response = await axios.delete(url, { headers });
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}


