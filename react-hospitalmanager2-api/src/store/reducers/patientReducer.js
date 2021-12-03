import {CREATE_PATIENT, GET_PATIENTS, GET_PATIENTBYID, UPDATE_PATIENT, DELETE_PATIENT} from '../types'

const initialState = {
    patients:[],
    loading:true
}

export default function(state = initialState, action){

    switch(action.type){

        case CREATE_PATIENT:
            
            return {
                ...state,
                patientsContainer:state.patients.concat(action.payload),
                loading:false
            } 

        case GET_PATIENTS:
        return {
            ...state,
            patientsContainer:action.payload,
            loading:false

        }

        case GET_PATIENTBYID:
            return {
                ...state,
                patientsContainer: action.payload,
                loading:false
            }

        case UPDATE_PATIENT:
            let patient = state.patients.find(p => p.id === action.payload.id);
            patient.firstName = action.payload.firstName;
            patient.lastName = action.payload.lastName;
            return {
                ...state,
                loading:false
            }

        case DELETE_PATIENT:
            return {
                ...state,
                patientsContainer:state.patients.filter(({ id }) => id !== action.payload),
                loading:false
            }
        default: return state
    }
}