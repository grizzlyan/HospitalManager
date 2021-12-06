import React from 'react';
import './App.css';

import NavigationBar from './component/navigationBar';

import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { authorizationForm } from './component/authorizationForm';
import { registrationForm} from './component/registrationForm';
import { doctorsContainer } from './component/doctorsContainer';
import { specializationContainer } from './component/specializationsContainer';
import { cabinet } from './component/cabinet';
import Specialization from './component/specialization';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavigationBar />
        <specializationContainer/>
        <div>
        <Switch>
          <Route path='/login' component={authorizationForm} />
          <Route path='/registration' component={registrationForm} />
          <Route path='/doctors' component={doctorsContainer}/>
          <Route path='/specializations' component={specializationContainer}/>
          <Route path='/cabinet' component={cabinet}/>
        </Switch>
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;