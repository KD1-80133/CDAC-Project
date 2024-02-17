import axios from 'axios';
import { createError, createUrl, createSuccess } from './utils'

export async function getAllProject() {
    
    try {
        const url = createUrl('Projects')

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

export async function addProject( title, startDate, endDate) {
    try {
        const url = createUrl('Projects')
        const body = {
           title,
           startDate,
            endDate
        }
        const response = await axios.post(url, body)
        return createSuccess(response.data)
    } catch (ex) {
        return createError(ex)
    }
}