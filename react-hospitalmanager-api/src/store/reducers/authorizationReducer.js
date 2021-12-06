import { LOGIN, LOGIN_ERROR } from '../types'

const initialState = {
    userData:{
    token: '',
    userName: '',
    roles: []
    }
}

export default function (state = initialState, action) {

    switch (action.type) {

        case LOGIN:

        localStorage.setItem('userData', JSON.stringify(action.payload))

            return {
                ...state,
                userData: action.payload
            }

            case LOGIN_ERROR:
                console.log("LOGIN ERROR");
                return state;

            default: return state
    }
}