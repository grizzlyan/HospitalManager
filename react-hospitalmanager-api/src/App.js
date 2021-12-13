import React from 'react';
import './App.css';
import { BrowserRouter, Route, Switch, Router } from 'react-router-dom';
import NavigationBar from './component/navigationBar';
import AuthorizationForm from './component/authorizationForm';
import RegistrationForm from './component/registrationForm';
import DoctorsContainer from './component/doctorsContainer';
import SpecializationContainer from './component/specializationsContainer';
import { cabinet } from './component/cabinet';
import MainPage from './component/mainPage';
import {
  registrationResultSuccess,
  registrationResultError,
  addSpecializationResultSuccess,
  addSpecializationResultError,
  editComponentSuccess,
  editComponentError,
  appointmentSuccess,
  appointmentError
} from './component/registrationResult';
import SpecializationsContainerPagination from './component/specializationsContainerPagination';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavigationBar />
        <div>
          <Switch>
            <Route exact path='/' component={MainPage} />
            <Route path='/login' component={AuthorizationForm} />
            <Route path='/registration' component={RegistrationForm} />
            <Route path='/doctors' component={DoctorsContainer} />
            <Route path='/specializations' component={SpecializationContainer} />
            <Route path='/cabinet' component={cabinet} />
            <Route path='/regResultSuccess' component={registrationResultSuccess} />
            <Route path='/regResultError' component={registrationResultError} />
            <Route path='/addSpecializationResultSuccess' component={addSpecializationResultSuccess} />
            <Route path='/addSpecializationResultError' component={addSpecializationResultError} />
            <Route path='/editSuccess' component={editComponentSuccess} />
            <Route path='/editError' component={editComponentError} />
            <Route path='/appointmentSuccess' component={appointmentSuccess} />
            <Route path='/appointmentError' component={appointmentError} />
            <Route path='/test' component={SpecializationsContainerPagination}/>
          </Switch>
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;