import React from 'react';
import './App.css';
import MainPage from './component/mainPage';
import RegAuthForm from './component/registrationForm';
import NavigationBar from './component/navigationBar';

import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { AuthorizationForm } from './component/authorizationForm';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <NavigationBar />
        <div>
        <Switch>
          <Route path='/login' component={AuthorizationForm} />
        </Switch>
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;