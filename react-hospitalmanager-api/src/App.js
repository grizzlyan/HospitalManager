import React from 'react';
import './App.css';
import { BrowserRouter, Route, Switch, Router } from 'react-router-dom';
import NavigationBar from './component/navigationBar';
import  AuthorizationForm  from './component/authorizationForm';
import RegistrationForm from './component/registrationForm';
import  DoctorsContainer  from './component/doctorsContainer';
import SpecializationContainer  from './component/specializationsContainer';
import {cabinet} from './component/cabinet';
import Specialization from './component/specialization';
import RegistrationResult from './component/registrationResult';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavigationBar />
        <div>
        <Switch>
          <Route path='/login' component={AuthorizationForm} />
          <Route path='/registration' component={RegistrationForm} />
          <Route path='/regResult' component={RegistrationResult} />
          <Route path='/doctors' component={DoctorsContainer}/>
          <Route path='/specializations' component={SpecializationContainer}/>
          <Route path='/cabinet' component={cabinet}/>
        </Switch>
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;