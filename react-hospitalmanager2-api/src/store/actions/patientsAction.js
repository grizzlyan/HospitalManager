import {CREATE_PATIENT, GET_PATIENTS, GET_PATIENTBYID, UPDATE_PATIENT, DELETE_PATIENT, PATIENTS_ERROR} from '../types'
import axios from 'axios'

export const createPatient = (patientData, userDetails) => async dispatch => {
    
    try{
        const res = await axios.post(`https://localhost:44376/Patients/Register`, patientData, userDetails)
        dispatch( {
            type: CREATE_PATIENT,
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

export const getPatientById = (id) => async dispatch => {
    
    try{
        const res = await axios.get(`https://localhost:44376/Patients/${id}`)
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
        const res = await axios.get(`https://localhost:44376/Patients`)
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
        const res = await axios.put(`https://localhost:44376/Patients/${id}`, patientData)

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
        await axios.delete(`https://localhost:44376/Patients/${id}`)

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