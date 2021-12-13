import { CREATE_DOCTOR, GET_DOCTORS, GET_DOCTORBYID, UPDATE_DOCTOR, DELETE_DOCTOR } from '../types'

const initialState = {
    doctors: [],
    totalCount: 0
}

export default function (state = initialState, action) {

    switch (action.type) {

        case CREATE_DOCTOR:

            return {
                ...state,
                doctors: state.doctors.concat(action.payload.doctor),
                message: action.payload.message
            }

        case GET_DOCTORS:

            return {
                ...state,
                doctors: action.payload,
            }

        case GET_DOCTORBYID:

            return {
                ...state,
                doctors: action.payload,
            }

        case UPDATE_DOCTOR:

            let doctor = state.doctors.find(d => d.id === action.payload.id);
            doctor.firstName = action.payload.firstName;
            doctor.lastName = action.payload.lastName;
            doctor.employmentDate = action.payload.employmentDate;
            doctor.workExperience = action.payload.workExperience;
            doctor.pathToPhoto = action.payload.pathToPhoto;

            return {
                ...state,
            }

        case DELETE_DOCTOR:

            return {
                ...state,
                doctors: state.doctors.filter(({ id }) => id !== action.payload),
            }

        default: return state
    }
}