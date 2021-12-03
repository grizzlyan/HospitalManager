import {LOGIN, LOGINS_ERROR} from '../types'
import axios from 'axios'

export const authorization = (credentials) => async dispatch => {
    
    try{
        const res = await axios.post(`https://localhost:44376/Authorizations`, credentials)
        dispatch( {
            type: LOGIN,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: LOGINS_ERROR,
            payload: console.log(e),
        })
    }
}