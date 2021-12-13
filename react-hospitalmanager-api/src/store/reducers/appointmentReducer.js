import { CREATE_APPOINTMENT, GET_APPOINTMENTS, GET_APPOINTMENTBYID, GET_APPOINTMENTBYDOCTORID, GET_APPOINTMENTBYPATIENTID, UPDATE_APPOINTMENT, DELETE_APPOINTMENT } from '../types'

const initialState = {
    appointments: []
}

export default function (state = initialState, action) {

    switch (action.type) {

        case CREATE_APPOINTMENT:

            return {
                ...state,
                appointments: state.appointments.concat(action.payload),
            }

        case GET_APPOINTMENTS:

            return {
                ...state,
                appointments: action.payload,
            }

        case GET_APPOINTMENTBYID:

            return {
                ...state,
                appointments: action.payload,
            }

        case GET_APPOINTMENTBYDOCTORID:

            return {
                ...state,
                appointments: action.payload,
            }

        case GET_APPOINTMENTBYPATIENTID:

            return {
                ...state,
                appointments: action.payload,
            }

        case UPDATE_APPOINTMENT:

            let appointment = state.appointments.find(a => a.id === action.payload.id);
            appointment.appointmentDate = action.payload.appointmentDate;
            appointment.appointmentDate = action.payload.appointmentDuration;

            return {
                ...state,
            }

        case DELETE_APPOINTMENT:

            return {
                ...state,
                appointments: state.appointments.filter(({ id }) => id !== action.payload),
            }

        default: return state
    }
}