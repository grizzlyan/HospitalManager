import { CREATE_SPECIALIZATION, GET_SPECIALIZATIONS, GET_SPECIALIZATIONBYID, UPDATE_SPECIALIZATION, DELETE_SPECIALIZATION } from '../types'

const initialState = {
    specializations: []
}

export default function (state = initialState, action) {

    switch (action.type) {

        case CREATE_SPECIALIZATION:

            return {
                ...state,
                specializations: state.specializations.concat(action.payload),
            }

        case GET_SPECIALIZATIONS:

            return {
                ...state,
                specializations: action.payload,
            }

        case GET_SPECIALIZATIONBYID:

            return {
                ...state,
                specializations: action.payload,
            }

        case UPDATE_SPECIALIZATION:
            
            let specialization = state.specializations.find(s => s.id === action.payload.id);
            specialization.specializationName = action.payload.specializationName;

            return {
                ...state,
            }

        case DELETE_SPECIALIZATION:

            return {
                ...state,
                specializations: state.specializations.filter(({ id }) => id !== action.payload),
            }

        default: return state
    }
}