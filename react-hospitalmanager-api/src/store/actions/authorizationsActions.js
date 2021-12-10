import {LOGIN, LOGIN_ERROR} from '../types'
import axios from 'axios'

const host = 'https://localhost:44333/api/';

export const authorization = (credentials) => async dispatch => {
    
    try{
        const res = await axios.post(`${host}Authorizations/Login`, credentials)
        console.log(res);
        dispatch( {
            type: LOGIN,
            payload: res.data
        })

        window.location.href = "/cabinet"
    }

    catch(e){
        dispatch( {
            type: LOGIN_ERROR,
            payload: console.log(e),
        })
    }
}