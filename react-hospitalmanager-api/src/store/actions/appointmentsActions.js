import { CREATE_APPOINTMENT, GET_APPOINTMENTS, GET_APPOINTMENTBYID, GET_APPOINTMENTBYDOCTORID, GET_APPOINTMENTBYPATIENTID, UPDATE_APPOINTMENT, DELETE_APPOINTMENT, APPOINTMENTS_ERROR } from '../types'
import axios from 'axios'
import {axiosConfig} from '../getToken';

const host = 'https://localhost:44333/api/';

export const createAppointment = (appointmentData) => async dispatch => {

    try {
        const res = await axios.post(`${host}Appointments`, appointmentData, axiosConfig)

        dispatch({
            type: CREATE_APPOINTMENT,
            payload: res.data
        })

        window.location.href = "/appointmentSuccess";
    }
    catch (e) {
        dispatch({
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
        window.location.href = "/appointmentError";
    }
}

export const getAppointments = () => async dispatch => {

    try {
        const res = await axios.get(`${host}Appointments`, axiosConfig)
        dispatch({
            type: GET_APPOINTMENTS,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getAppointmentById = (id) => async dispatch => {

    try {
        const res = await axios.get(`${host}Appointments/${id}`, axiosConfig)
        dispatch({
            type: GET_APPOINTMENTBYID,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getAppointmentByDoctorId = (doctorId) => async dispatch => {

    try {
        const res = await axios.get(`${host}Appointments/appointmentsByDoctorId/${doctorId}`, axiosConfig)
        dispatch({
            type: GET_APPOINTMENTBYDOCTORID,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getAppointmentByPatientId = (patientId) => async dispatch => {
console.log(patientId)
    try {
        const res = await axios.get(`${host}Appointments/appointmentsByPatientId/${patientId}`, axiosConfig)
        dispatch({
            type: GET_APPOINTMENTBYPATIENTID,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const updateAppointment = (appointmentData) => async dispatch => {
    const id = appointmentData.id
    try {
        const res = await axios.put(`${host}Appointments/${id}`, appointmentData, axiosConfig)

        dispatch({
            type: UPDATE_APPOINTMENT,
            payload: appointmentData
        })
    }
    catch (e) {
        dispatch({
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const deleteAppointment = (id) => async (dispatch) => {
    try {
        await axios.delete(`${host}Appointments/${id}`, axiosConfig)

        dispatch({
            type: DELETE_APPOINTMENT,
            payload: id
        })
    }
    catch (e) {
        dispatch({
            type: APPOINTMENTS_ERROR,
            payload: console.log(e),
        })
    }
}