import {CREATE_DOCTOR, GET_DOCTORS, GET_DOCTORBYID, UPDATE_DOCTOR, DELETE_DOCTOR, DOCTORS_ERROR} from '../types'
import axios from 'axios'
import axiosConfig, { axiosImageConfig } from '../getToken';
const host = 'https://localhost:44333/api/';

export const createDoctor = (userDetails) => async dispatch => {

    try{
        const res = await axios.post(`${host}Doctors/Register`, userDetails, axiosConfig)

        if(res.data.doctor.id != null)
        {
            const id = res.data.doctor.id

            let formData = new FormData();
            formData.append("image", userDetails.image);

           const imagePath = await axios.post(`${host}Images/${id}`, formData, axiosImageConfig)

           res.data.pathToPhoto = imagePath;
        }

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
        const res = await axios.put(`${host}Doctors/${id}`, doctorData, axiosConfig)

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
        await axios.delete(`${host}Doctors/${id}`, axiosConfig)

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