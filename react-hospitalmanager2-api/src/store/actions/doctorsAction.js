import {CREATE_DOCTOR, GET_DOCTORS, GET_DOCTORBYID, UPDATE_DOCTOR, DELETE_DOCTOR, DOCTORS_ERROR} from '../types'
import axios from 'axios'

export const createDoctor = (doctorData, userDetails) => async dispatch => {
    
    try{
        const res = await axios.post(`https://localhost:44376/Doctors/Register`, doctorData, userDetails)
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
        const res = await axios.get(`https://localhost:44376/Doctors/${id}`)
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
        const res = await axios.get(`https://localhost:44376/Doctors`)
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
        const res = await axios.put(`https://localhost:44376/Doctors/${id}`, doctorData)

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
        await axios.delete(`https://localhost:44376/Doctors/${id}`)

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