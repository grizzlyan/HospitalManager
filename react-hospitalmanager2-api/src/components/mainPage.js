import React from "react";
import './mainPageStyle.css';
import regAuthForm from "./regAuthForm";
import {connect} from 'react-redux'
import {createDoctor} from '../store/actions/doctorsAction'

class MainPage extends React.Component {
    render() {
        return <div className="App">
            <regAuthForm/>
      </div>
   
    }
}

const mapStateToProps  = (state) => ({MainPage:state.MainPage});

export default connect(mapStateToProps)(MainPage);