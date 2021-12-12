import React, { useState } from 'react'
import { connect } from 'react-redux'
import './cabinetStyle.css'
import { Link, Switch, Route } from 'react-router-dom';
import SpecializationForm from './specializationForm';
import SpecializationContainer  from './specializationsContainer';
import DoctorForm  from './doctorForm';
import  DoctorsContainer  from './doctorsContainer';
import { patientsContainer } from './patientsContainer';
import { appointmentsContainer } from './appointmentsContainer';
import { appointmentCalendar } from './appointmentCalendar';
import EditDoctorForm from './editDoctorForm';
import EditSpecializationForm from './editSpecializationForm';


export class cabinet extends React.Component {
    render() {

        let greetings;
        let nameForGreeting;

        let cabinetBar;
        let routes;
        


        let userData;

        let role = '';


        const retrievedStoreStr = localStorage.getItem('userData')

        if (retrievedStoreStr) {
            userData = JSON.parse(retrievedStoreStr)
            role = userData.role;
        }

        if (role === "Manager") {

            nameForGreeting = userData.userName;

            greetings = <h1 class="navbar-brand" >Привет, {nameForGreeting}!</h1>

            cabinetBar = <ul class="navbar-nav">

                <span class="navbar-brand" >Отделения</span>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/createSpecialization">Добавить отделение</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/specializations">Список отделений</Link>
                </li>
                <hr />

                <span class="navbar-brand" >Врачи</span>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/createDoctor">Добавить врача</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/doctors">Список врачей</Link>
                </li>
                <hr />

                <span class="navbar-brand" >Пациенты</span>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/patients">Список пациентов</Link>
                </li>
                <hr />

                <span class="navbar-brand" >Приёмы</span>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/appointments">Список приёмов</Link>
                </li>
                <hr />
            </ul>

            routes = <Switch>
                <Route path='/cabinet/createSpecialization' component={SpecializationForm} />
                <Route exact path='/cabinet/specializations' component={SpecializationContainer} />
                <Route path='/cabinet/createDoctor' component={DoctorForm} />
                <Route exact path='/cabinet/doctors' component={DoctorsContainer} />
                <Route exact path='/cabinet/patients' component={patientsContainer} />
                <Route exact path='/cabinet/appointments' component={appointmentsContainer} />
                <Route path='/cabinet/editDoctor' component={EditDoctorForm} />
                <Route path={'/cabinet/editSpetialization'} component={EditSpecializationForm}/>
            </Switch>
        }

        else if (role === "Doctor") {

            nameForGreeting = userData.fullName;

            greetings = <h1 class="navbar-brand" >Привет, {nameForGreeting}!</h1>

            cabinetBar = <ul class="navbar-nav">
                <li class="nav-item">
                    <Link class="nav-link" to="/d-upcoming">Предстоящие приёмы</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/d-history">История приёмов</Link>
                </li>
            </ul>

            routes = <Switch>
                <Route exact path='/cabinet/p-upcoming' component={appointmentCalendar} />
                <Route exact path='/cabinet/p-history' component={appointmentCalendar} />
            </Switch>
        }

        else if (role === "Patient") {

            nameForGreeting = userData.fullName;

            greetings = <h1 class="navbar-brand" >Привет, {nameForGreeting}!</h1>

            cabinetBar = <ul class="navbar-nav">
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/p-createAppointment">Записаться</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/p-upcoming">Предстоящие приёмы</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/p-history">История приёмов</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/p-edit">Редактировать информацию о себе</Link>
                </li>
            </ul>

            routes = <Switch>
                <Route exact path='/cabinet/p-createAppointment' component={appointmentCalendar} />
                <Route exact path='/cabinet/p-upcoming' component={appointmentCalendar} />
                <Route exact path='/cabinet/p-history' component={appointmentCalendar} />
                <Route exact path='/cabinet/p-edit' component={appointmentCalendar} />
            </Switch>

        }

        return <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 col-lg-3 navbar-container bg-light">

                    <nav class="navbar navbar-expand-md navbar-light">

                        {greetings}
                        
                        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar"
                            aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbar">

                            {cabinetBar}

                        </div>
                    </nav>
                </div>
                <div class="col-md-8 col-lg-9 content-container" >
                    {routes}
                </div>
            </div>
        </div>
    }
}