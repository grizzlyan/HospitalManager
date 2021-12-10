import {CREATE_PATIENT, GET_PATIENTS, GET_PATIENTBYID, UPDATE_PATIENT, DELETE_PATIENT, PATIENTS_ERROR} from '../types'
import axios from 'axios'
import { axiosConfig } from '../getToken';
const host = 'https://localhost:44333/api/';

export const createPatient = (userDetails) => async dispatch => {
    
    try{
        const res = await axios.post(`${host}Patients/Register`, userDetails)

        dispatch( {
            type: CREATE_PATIENT,
            payload: res.data
        })

        window.location.href = '/login';
    }
    catch(e){
        dispatch( {
            type: PATIENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getPatientById = (id) => async dispatch => {
    
    try{
        const res = await axios.get(`${host}Patients/${id}`, axiosConfig)
        dispatch( {
            type: GET_PATIENTBYID,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: PATIENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getPatients = () => async dispatch => {
    
    try{
        const res = await axios.get(`${host}Patients`, axiosConfig)
        dispatch( {
            type: GET_PATIENTS,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: PATIENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const updatePatient = (patientData) => async dispatch => {
    const id = patientData.id
    try{
        const res = await axios.put(`${host}Patients/${id}`, patientData, axiosConfig)

        dispatch( {
            type: UPDATE_PATIENT,
            payload: patientData
        })
    }
    catch(e){
        dispatch( {
            type: PATIENTS_ERROR,
            payload: console.log(e),
        })
    }
}

export const deletePatient = (id) => async (dispatch) => {
    try{
        await axios.delete(`${host}Patients/${id}`, axiosConfig)

        dispatch({
            type: DELETE_PATIENT,
            payload: id
        })
    }
    catch(e){
        dispatch({
            type: PATIENTS_ERROR,
            payload: console.log(e),
        })
    }
}