import {CREATE_SPECIALIZATION, GET_SPECIALIZATIONS, GET_SPECIALIZATIONBYID, UPDATE_SPECIALIZATION, DELETE_SPECIALIZATION, SPECIALIZATIONS_ERROR} from '../types'
import axios from 'axios'
const host = 'https://localhost:44333/api/';

export const createSpecialization = (specializationData) => async dispatch => {
    
    try{
        const res = await axios.post(`${host}Specialization`, specializationData)
        dispatch( {
            type: CREATE_SPECIALIZATION,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getSpecializationById = (id) => async dispatch => {
    
    try{
        const res = await axios.get(`${host}Specialization/${id}`)
        dispatch( {
            type: GET_SPECIALIZATIONBYID,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getSpecializations = () => async dispatch => {
    
    try{
        const res = await axios.get(`${host}Specialization`)
        dispatch( {
            type: GET_SPECIALIZATIONS,
            payload: res.data
        })
    }
    catch(e){
        dispatch( {
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
    }
}

export const updateSpecialization = (specializationData) => async dispatch => {
    const id = specializationData.id
    try{
        const res = await axios.put(`${host}Specialization/${id}`, specializationData)

        dispatch( {
            type: UPDATE_SPECIALIZATION,
            payload: specializationData
        })
    }
    catch(e){
        dispatch( {
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
    }
}

export const deletePatient = (id) => async (dispatch) => {
    try{
        await axios.delete(`${host}Specialization/${id}`)

        dispatch({
            type: DELETE_SPECIALIZATION,
            payload: id
        })
    }
    catch(e){
        dispatch({
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
    }
}