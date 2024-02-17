import axios from 'axios';
import { createError, createUrl, createSuccess } from './utils'

export async function getAllTask() {
    
    try {
        const url = createUrl('Task')

        const headers= {
            headers:{
            token: sessionStorage['token'],
        },
    }
        
       
        const response = await axios.get(url , headers)
        return createSuccess(response.data)
    } catch (ex) {
        return createError(ex)
    }
}

export async function addTask( userId, taskDescription, startDate, endDate, /*workHours,*/ Status,projectId, /*percentage*/) {
    try {
        const url = createUrl('Task')
        const body = {
            
            userId,
            taskDescription,
            startDate,
            endDate,
            // workHours,
            Status,
            projectId,
           // percentage
        }
        const response = await axios.post(url, body)
        return createSuccess(response.data)
    } catch (ex) {
        return createError(ex)
    }
}