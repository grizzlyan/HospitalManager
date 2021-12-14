import { CREATE_SPECIALIZATION, GET_SPECIALIZATIONS, GET_PAGINATIONSPECIALIZATIONS, GET_SPECIALIZATIONBYID, UPDATE_SPECIALIZATION, DELETE_SPECIALIZATION, SPECIALIZATIONS_ERROR } from '../types'
import axios from 'axios'
import { axiosConfig } from '../getToken';
const host = 'https://localhost:44333/api/';

export const createSpecialization = (specializationData) => async dispatch => {

    try {
        const res = await axios.post(`${host}Specializations`, specializationData, axiosConfig)
        dispatch({
            type: CREATE_SPECIALIZATION,
            payload: res.data
        })

        window.location.href = '/addSpecializationResultSuccess'
    }
    catch (e) {
        dispatch({
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
        window.location.href = '/addSpecializationResultError'
    }
}

export const getSpecializationById = (id) => async dispatch => {

    try {
        const res = await axios.get(`${host}Specializations/${id}`)
        dispatch({
            type: GET_SPECIALIZATIONBYID,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getSpecializations = (pagePagination, sortFilterParametres) => async dispatch => {

    try {
        const res = await axios.get(`${host}Specializations/paginGet`, {
            params: {
                page: pagePagination.page,
                pageSize: pagePagination.pageSize,
                sortDirection: sortFilterParametres.sortDirection,
                sortField: sortFilterParametres.sortField
            }
        })

        console.log(res)
        
        dispatch({
            type: GET_PAGINATIONSPECIALIZATIONS,
            payload: res.data, pagePagination
        })
    }
    catch (e) {
        dispatch({
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
    }
}

export const getAllSpecializations = () => async dispatch => {

    try {
        const res = await axios.get(`${host}Specializations/allSpecializations`)
        
        dispatch({
            type: GET_SPECIALIZATIONS,
            payload: res.data
        })
    }
    catch (e) {
        dispatch({
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
    }
}

export const updateSpecialization = (specializationData) => async dispatch => {
    const id = specializationData.id
    try {
        const res = await axios.put(`${host}Specializations/${id}`, specializationData, axiosConfig)

        dispatch({
            type: UPDATE_SPECIALIZATION,
            payload: specializationData
        })
        window.location.href = '/editSuccess';
    }
    catch (e) {
        dispatch({
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
        window.location.href = '/editError';
    }
}

export const deleteSpecialization = (id) => async (dispatch) => {
    try {
        const res = await axios.delete(`${host}Specializations/${id}`, axiosConfig)
        console.log(res);
        dispatch({
            type: DELETE_SPECIALIZATION,
            payload: id
        })
    }
    catch (e) {
        dispatch({
            type: SPECIALIZATIONS_ERROR,
            payload: console.log(e),
        })
    }
}