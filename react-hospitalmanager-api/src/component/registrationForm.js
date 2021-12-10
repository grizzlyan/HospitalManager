import React from 'react'
import './regAuthFormStyle.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import { createPatient } from '../store/actions/patientsActions'
import { connect } from 'react-redux'
import { Link } from 'react-router-dom';

class registrationForm extends React.Component {
    constructor(props) {
        super(props);

        this.onUserNameChange = this.onUserNameChange.bind(this);
        this.onFirstNameChange = this.onFirstNameChange.bind(this);
        this.onLastNameChange = this.onLastNameChange.bind(this);
        this.onCityChange = this.onCityChange.bind(this);
        this.onEmailChange = this.onEmailChange.bind(this);
        this.onPasswordChange = this.onPasswordChange.bind(this);
    }

    onUserNameChange(e) {
        let val = e.target.value;
        this.setState({ userName: val });
    }
    onFirstNameChange(e) {
        let val = e.target.value;
        this.setState({ firstName: val });
    }
    onLastNameChange(e) {
        let val = e.target.value;
        this.setState({ lastName: val });
    }
    onCityChange(e) {
        let val = e.target.value;
        this.setState({ city: val });
    }
    onEmailChange(e) {
        let val = e.target.value;
        this.setState({ email: val });
    }
    onPasswordChange(e) {
        let val = e.target.value;
        this.setState({ password: val });
    }

    onCreateAccount() {

        const userDetails = {
            username: this.state.userName,
            password: this.state.password,
            email: this.state.email,
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            city: this.state.city
        }

        this.props.createPatient(userDetails);
    }

    render() {
        return <div class="bform py-5">
            <div class="row">
                <div class="container">
                    <div class="col-lg-3 mx-auto align-justify-center pr-4 pl-0 contact-form">
                        <h2 class="mb-3 font-weight-light">Регистрация</h2>
                        <h6 class="subtitle font-weight-normal">Lorem ipsum dolor sit amet, adipiscing.</h6>
                        <div class="row">
                            <div class="col-lg-12 mb-3">
                                <div class="form-group">
                                    <input class="form-control" type="text" placeholder="логин" onChange={this.onUserNameChange} required />
                                </div>
                            </div>
                            <div class="col-lg-12 mb-3">
                                <div class="form-group">
                                    <input class="form-control" type="text" placeholder="имя" onChange={this.onFirstNameChange} required />
                                </div>
                            </div>
                            <div class="col-lg-12 mb-3">
                                <div class="form-group">
                                    <input class="form-control" type="text" placeholder="фамилия" onChange={this.onLastNameChange} required />
                                </div>
                            </div>
                            <div class="col-lg-12 mb-3">
                                <div class="form-group">
                                    <input class="form-control" type="text" placeholder="город" onChange={this.onCityChange} required />
                                </div>
                            </div>
                            <div class="col-lg-12 mb-3">
                                <div class="form-group">
                                    <input class="form-control" type="email" placeholder="email" onChange={this.onEmailChange} required />
                                </div>
                            </div>
                            <div class="col-lg-12 mb-3">
                                <div class="form-group">
                                    <input class="form-control" type="password" placeholder="пароль" onChange={this.onPasswordChange} required />
                                </div>
                            </div>
                            <button type="button" class="btn btn-md btn-block btn-danger-gradiant text-white border-0" href ="/" onClick={() => this.onCreateAccount()}>
                                <span> Создать аккаунт</span>
                            </button>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 text-center mt-4">
                                <h6 class="subtitle font-weight-normal">Войти через соцсети</h6>
                                <div class="row">
                                    <a href="#" class="btn btn-sm btn-block bg-facebook text-white mt-3">Facebook</a>
                                    <a href="#" class="btn btn-sm  btn-block bg-twitter text-white mt-3">Twitter</a>
                                </div>
                            </div>
                            <div class="col-lg-12 text-center mt-4">
                                Уже есть аккаунт? <Link to="/login" class="text-danger">Войти</Link>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div >
    }
}

const mapStateToProps = (state) => ({ registrationForm: state.registrationForm });

export default connect(mapStateToProps, { createPatient })(registrationForm);