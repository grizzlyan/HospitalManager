import {CREATE_APPOINTMENT, GET_APPOINTMENTS, GET_APPOINTMENTBYID, GET_APPOINTMENTBYDOCTORID, UPDATE_APPOINTMENT, DELETE_APPOINTMENT, APPOINTMENTS_ERROR} from '../types'
import axios from 'axios'
const host = 'https://localhost:44333/api/';

export const createAppointment = (appointmentData) => async dispatch => {
    
    try{
        const res = await axios.post(`${host}Appointments`, appointmentData)
        dispatch( {
            type: CREATE_APPOINTMENT,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getAppointments = () => async dispatch => {
    
    try{
        const res = await axios.get(`${host}Appointments`)
        dispatch( {
            type: GET_APPOINTMENTS,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getAppointmentById = (id) => async dispatch => {
    
    try{
        const res = await axios.get(`${host}Appointments/${id}`)
        dispatch( {
            type: GET_APPOINTMENTBYID,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getAppointmentByDoctorId = (doctorId) => async dispatch => {
    
    try{
        const res = await axios.get(`${host}Appointments/${doctorId}`)
        dispatch( {
            type: GET_APPOINTMENTBYDOCTORID,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const updateDoctor = (appointmentData) => async dispatch => {
    const id = appointmentData.id
    try{
        const res = await axios.put(`${host}Appointments/${id}`, appointmentData)

        dispatch( {
            type: UPDATE_APPOINTMENT,
            payload: appointmentData
        })
    }
    catch(e){
        dispatch( {
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const deleteDoctor = (id) => async (dispatch) => {
    try{
        await axios.delete(`${host}Appointments/${id}`)

        dispatch({
            type: DELETE_APPOINTMENT,
            payload: id
        })
    }
    catch(e){
        dispatch({
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}