import config from "../config";


//const SERVER_URL = 'http://localhost:5037'
export function createUrl(path) {
    return `${config.server}/${path}`
}
export function createError(error) {
    return { status: 'error', error }
}
export function createSuccess(data) {
    return { status: 'success', data }
}

