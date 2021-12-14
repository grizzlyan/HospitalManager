import { CREATE_DOCTOR, GET_DOCTORS, GET_PAGINATIONDOCTORS, GET_DOCTORBYID, UPDATE_DOCTOR, DELETE_DOCTOR, DOCTORS_ERROR } from '../types'
import axios from 'axios'
import { axiosConfig, axiosImageConfig } from '../getToken';
const host = 'https://localhost:44333/api/';


export const createDoctor = (userDetails) => async dispatch => {
    debugger
    try {
        const res = await axios.post(`${host}Doctors/Register`, userDetails, axiosConfig)
        console.log(res)
        if (res.data.doctor.id != null) {
            const id = res.data.doctor.id

            let formData = new FormData();
            formData.append("image", userDetails.image);

            const imagePath = await axios.post(`${host}Images/${id}`, formData, axiosImageConfig)

            res.data.doctor.pathToPhoto = imagePath;
        }

        dispatch({
            type: CREATE_DOCTOR,
            payload: res.data
        })

        window.location.href = '/regResultSuccess';
    }
    catch (e) {
        dispatch({
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })

        window.location.href = '/regResultError';
    }
}

export const getDoctorById = (id) => async dispatch => {

    try {
        const res = await axios.get(`${host}Doctors/${id}`)
        dispatch({
            type: GET_DOCTORBYID,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getDoctors = () => async dispatch => {

    try {
        const res = await axios.get(`${host}Doctors`)
        console.log(res)
        dispatch({
            type: GET_DOCTORS,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getPaginDoctors = (pagePagination, sortFilterParametres, doctorFilterFieldsParametres ) => async dispatch => {

    try {
        const res = await axios.get(`${host}Doctors/paginGet`, {
            params: {
                page: pagePagination.page,
                pageSize: pagePagination.pageSize,
                sortDirection: sortFilterParametres.sortDirection,
                sortField: sortFilterParametres.sortField,
                filterDoctorField: doctorFilterFieldsParametres.filterDoctorField,
                specializationId: doctorFilterFieldsParametres.specializationId
            }
            })
        console.log(res)
        dispatch({
            type: GET_PAGINATIONDOCTORS,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
    }
}

export const updateDoctor = (doctorData) => async dispatch => {
    const id = doctorData.id
    try {
        const res = await axios.put(`${host}Doctors/${id}`, doctorData, axiosConfig)

        dispatch({
            type: UPDATE_DOCTOR,
            payload: doctorData
        })
        window.location.href = '/editSuccess';
    }
    catch (e) {
        dispatch({
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
        window.location.href = '/editError';
    }
}

export const deleteDoctor = (id) => async (dispatch) => {
    try {
        await axios.delete(`${host}Doctors/${id}`, axiosConfig)

        dispatch({
            type: DELETE_DOCTOR,
            payload: id
        })
    }
    catch (e) {
        dispatch({
            type: DOCTORS_ERROR,
            payload: console.log(e),
        })
    }
}