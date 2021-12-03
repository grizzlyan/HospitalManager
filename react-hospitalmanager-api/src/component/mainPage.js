// import React, { Component } from 'react'
// import { connect } from 'react-redux'
// import { BrowserRouter, Routes, Router, Route, hashHistory} from 'react-router-dom';
// import { AuthorizationForm } from './authorizationForm';
// import NavigationBar from './navigationBar';
// import RegistrationForm from './registrationForm';
// import './wardsContStyle.css'

// //import { Router, Route, hashHistory } from 'react-router'
// import { Provider } from 'react-redux'
// import { syncHistoryWithStore } from 'react-router-redux'
// import store from '../store/store';

// const history = syncHistoryWithStore(hashHistory, store)

// class MainPage extends React.Component {
//     constructor(props) {
//         super(props);

//     }

//     render() {
//         return <Provider store={store}>
//             <Router history={history}>
//                 <div id="outside">
//                     <NavigationBar />
//                 </div>
//                     <Route exact path="/login" component={AuthorizationForm} />
//             </Router>
//         </Provider>
//     }
// }

// const mapStateToProps = (state) => ({ wardsContainer: state.wardsContainer });

// export default connect(mapStateToProps)(MainPage);