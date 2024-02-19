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
}

export async function addTask(userId, taskDescription, startDate, endDate, status, projectId) {
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
                        status,
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

export async function getTask(id) {
    try {
        const url = createUrl(`Task/${id}`);
        const headers = {
            'Authorization': `Bearer ${sessionStorage.token}`,
        };
        const response = await axios.get(url, { headers });
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}

export async function updateTask(id, userId, taskDescription, startDate, endDate, status, projectId) {
    try {
        // Convert dates to the required format "yyyy-MM-dd"
        const formattedStartDate = new Date(startDate).toISOString().split('T')[0];
        const formattedEndDate = new Date(endDate).toISOString().split('T')[0];
        
        const url = createUrl(`Task/${id}`); // Assuming the endpoint for updating tasks is 'Tasks/{id}'
        const headers = {
            'Authorization': `Bearer ${sessionStorage.token}`,
            'Content-Type': 'application/json',
        };
        const body = {
            userId,
            taskDescription,
            startDate: formattedStartDate, // Use the formatted startDate
            endDate: formattedEndDate, // Use the formatted endDate
            status,
            projectId
        };
        const response = await axios.put(url, body, { headers });
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}
