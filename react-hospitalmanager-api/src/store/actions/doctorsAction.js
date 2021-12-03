import {CREATE_DOCTOR, GET_DOCTORS, GET_DOCTORBYID, UPDATE_DOCTOR, DELETE_DOCTOR, DOCTORS_ERROR} from '../types'
import axios from 'axios'
const host = 'https://localhost:44333/api/';

export const createDoctor = (doctorData, userDetails) => async dispatch => {
    
    try{
        const res = await axios.post(`${host}Doctors/Register`, doctorData, userDetails)
        dispatch( {
            type: CREATE_DOCTOR,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getDoctorById = (id) => async dispatch => {
    
    try{
        const res = await axios.get(`${host}Doctors/${id}`)
        dispatch( {
            type: GET_DOCTORBYID,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getDoctors = () => async dispatch => {
    
    try{
        const res = await axios.get(`${host}Doctors`)
        dispatch( {
            type: GET_DOCTORS,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
    }
}

export const updateDoctor = (doctorData) => async dispatch => {
    const id = doctorData.id
    try{
        const res = await axios.put(`${host}Doctors/${id}`, doctorData)

        dispatch( {
            type: UPDATE_DOCTOR,
            payload: doctorData
        })
    }
    catch(e){
        dispatch( {
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
    }
}

export const deleteDoctor = (id) => async (dispatch) => {
    try{
        await axios.delete(`${host}Doctors/${id}`)

        dispatch({
            type: DELETE_DOCTOR,
            payload: id
        })
    }
    catch(e){
        dispatch({
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
    }
}