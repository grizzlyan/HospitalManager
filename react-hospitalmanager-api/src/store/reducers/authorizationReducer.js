import { LOGIN, LOGIN_ERROR } from '../types'

const initialState = {
    token: '',
    // login: '',
    // password: ''
}

export default function (state = initialState, action) {

    switch (action.type) {

        case LOGIN:

            return {
                ...state,
                token: action.payload
            }

            case LOGIN_ERROR:
                console.log("LOGIN ERROR");
                return state;

            default: return state
    }
}