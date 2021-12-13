import { CREATE_PATIENT, GET_PATIENTS, GET_PATIENTBYID, UPDATE_PATIENT, DELETE_PATIENT } from '../types'

const initialState = {
    patients: [],
    patient : null
}

export default function (state = initialState, action) {

    switch (action.type) {

        case CREATE_PATIENT:

            return {
                ...state,
                patients: state.patients.concat(action.payload.patient),
            }

        case GET_PATIENTS:

            return {
                ...state,
                patients: action.payload,
            }

        case GET_PATIENTBYID:
            
            return {
                ...state.patient,
                patient: action.payload,     
            }

        case UPDATE_PATIENT:

            let patient = state.patients.find(p => p.id === action.payload.id);
            patient.firstName = action.payload.firstName;
            patient.lastName = action.payload.lastName;
            patient.city = action.payload.city;

            return {
                ...state,
            }

        case DELETE_PATIENT:

            return {
                ...state,
                patients: state.patients.filter(({ id }) => id !== action.payload),
            }

        default: return state
    }
}