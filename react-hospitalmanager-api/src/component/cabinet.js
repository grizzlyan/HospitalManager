import React, { useState } from 'react'
import { connect } from 'react-redux'
import './cabinetStyle.css'
import { Link, Switch, Route } from 'react-router-dom';
import { specializationForm } from './specializationForm';
import { specializationContainer } from './specializationsContainer';
import { doctorForm } from './doctorForm';
import { doctorsContainer } from './doctorsContainer';
import { patientsContainer } from './patientsContainer';
import { appointmentsContainer } from './appointmentsContainer';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css'
import Calendar from './appointmentCalendar';


export class cabinet extends React.Component {
    render() {



        let code;
        let userData;
        let role = 'Manager';

        const retrievedStoreStr = localStorage.getItem('userData')

        if (retrievedStoreStr) {
            userData = JSON.parse(retrievedStoreStr)
            role = userData.roles[0];
        }

        if (role === "Manager") {
            code = <ul class="navbar-nav">

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
                    <Link class="nav-link" to="/cabinet/doctors">Список пациентов</Link>
                </li>
                <hr />

                <span class="navbar-brand" >Приёмы</span>
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet/appointments">Список приёмов</Link>
                </li>
                <hr />
            </ul>
        }

        else if (role === "Doctor") {
            code = <ul class="navbar-nav">
                <li class="nav-item">
                    <Link class="nav-link" to="/edit">Создать прём</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/upcoming">Предстоящие приёмы</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/history">История приёмов</Link>
                </li>
            </ul>
        }

        else if (role === "Patient") {
            code = <ul class="navbar-nav">
                <li class="nav-item">
                    <Link class="nav-link" to="/createAppointment">Записаться</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/upcoming">Предстоящие приёмы</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/history">История приёмов</Link>
                </li>
                <li class="nav-item">
                    <Link class="nav-link" to="/edit">Редактировать информацию о себе</Link>
                </li>
            </ul>

        }

        return <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 col-lg-3 navbar-container bg-light">

                    <nav class="navbar navbar-expand-md navbar-light">
                        <h1 class="navbar-brand" >Привет, !</h1>
                        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbar" 
                        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbar">

                            {code}

                        </div>
                    </nav>
                </div>
                <div class="col-md-8 col-lg-9 content-container" >

                    <form>
                        <div>
                            <label for="party">Введите дату::</label>
                            <input type="date" id="party" name="party" min={new Date(new Date().setDate(new Date().getDate() + 1)).toISOString().split("T")[0]}
                                max={new Date(new Date().setDate(new Date().getDate() + 30)).toISOString().split("T")[0]} required />
                            <span class="validity"></span>
                            <br />

                        </div>
                        <div>
                            <input type="submit" value="Submit form" />
                        </div>
                    </form>
                    <label for="from">Время приёма: </label>
                    <select name="from" id="from">
                        <option value="1">8:00</option>
                        <option value="2">9:00</option>
                        <option value="3">10:00</option>
                        <option value="4">11:00</option>
                        <option value="5">13:00</option>
                        <option value="1">14:00</option>
                        <option value="2">15:00</option>
                        <option value="3">16:00</option>
                    </select>

                    <Switch>
                        <Route path='/cabinet/createSpecialization' component={specializationForm} />
                        <Route exact path='/cabinet/specializations' component={specializationContainer} />
                        <Route path='/cabinet/createDoctor' component={doctorForm} />
                        <Route exact path='/cabinet/doctors' component={doctorsContainer} />
                        <Route exact path='/cabinet/doctors' component={patientsContainer} />
                        <Route exact path='/cabinet/appointments' component={appointmentsContainer} />
                    </Switch>
                </div>
            </div>
        </div>
    }
}