import { combineReducers } from 'redux'
import patientReducer from './patientReducer'
import { routerReducer } from 'react-router-redux';

export default combineReducers({
   routing: routerReducer,
   patients: patientReducer
  })