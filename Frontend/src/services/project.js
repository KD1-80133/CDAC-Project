import axios from 'axios';
import { createError, createUrl, createSuccess } from './utils';

export async function getAllProject() {
    const token = sessionStorage.getItem('token');
    const headers = {
        'Authorization': `Bearer ${token}`
    };

    try {
        const url = createUrl('Projects');
        const response = await axios.get(url, { headers });
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}

export async function getProject(id) {
    try {
        const url = createUrl(`Projects/${id}`);
        const headers = {
            'Authorization': `Bearer ${sessionStorage.token}`,
        };
        const response = await axios.get(url, { headers });
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}

export async function addProject(title, startDate, endDate) {
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
        const url = createUrl('Projects');
        const body = {
            title,
            startDate,
            endDate
        };
        const headers = getHeaders();
        const response = await axios.post(url, body, { headers });
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}

export async function deleteProject(projectId) {
    try {
        const url = createUrl(`Projects/${projectId}`);
        const token = sessionStorage.getItem('token');
        
        if (!token) {
            throw new Error('Token is missing');
        }

        const headers = {
            'Authorization': `Bearer ${token}`
        };

        const response = await axios.delete(url, { headers });
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
}

export async function updateProject(id, title, startDate, endDate) {
    try {
        const formattedStartDate = new Date(startDate).toISOString().split('T')[0];
        const formattedEndDate = new Date(endDate).toISOString().split('T')[0];
        
        const url = createUrl(`Projects/${id}`);
        const headers = {
            'Authorization': `Bearer ${sessionStorage.token}`,
            'Content-Type': 'application/json',
        };
        const body = {
            title,
            startDate: formattedStartDate,
            endDate: formattedEndDate,
        };
        const response = await axios.put(url, body, { headers });
        return createSuccess(response.data);
    } catch (ex) {
        return createError(ex);
    }
};
