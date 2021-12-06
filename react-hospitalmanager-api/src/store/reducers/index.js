import { combineReducers } from 'redux'
import patientReducer from './patientReducer'
import appointmentReducer from './appointmentReducer';
import authorizationReducer from './authorizationReducer';
import doctorReducer from './doctorReducer';
import specializationReducer from './specializationReducer';

export default combineReducers({

   appointments: appointmentReducer,
   authorizations: authorizationReducer,
   doctors: doctorReducer,
   patients: patientReducer,
   specializations: specializationReducer
  })