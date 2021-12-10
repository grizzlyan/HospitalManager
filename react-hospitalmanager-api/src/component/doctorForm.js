import React from 'react'
import { createDoctor } from '../store/actions/doctorsActions';
import { getAllSpecializations } from "../store/actions/specializationsActions";
import { connect } from 'react-redux'
import './regAuthFormStyle.css'

class doctorForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            specializationId: 1
        };

        this.onFirstNameChange = this.onFirstNameChange.bind(this);
        this.onLastNameChange = this.onLastNameChange.bind(this);
        this.onEmailChange = this.onEmailChange.bind(this);
        this.onPasswordChange = this.onPasswordChange.bind(this);
        this.onImageChange = this.onImageChange.bind(this);
        this.handleDropdownChange = this.handleDropdownChange.bind(this);
        this.onCreate = this.onCreate.bind(this);
    }

    componentDidMount() {
        this.props.getAllSpecializations();
    }

    handleDropdownChange(e) {
        this.setState({ specializationId: e.target.value });
    }

    onFirstNameChange(e) {
        let val = e.target.value;
        this.setState({ firstName: val });
    }

    onLastNameChange(e) {
        let val = e.target.value;
        this.setState({ lastName: val });
    }

    onEmailChange(e) {
        let val = e.target.value;
        this.setState({ email: val });
    }

    onPasswordChange(e) {
        let val = e.target.value;
        this.setState({ password: val });
    }

    onImageChange(e) {
        if (e.target.files && e.target.files[0]) {
            let img = e.target.files[0];
            this.setState({
                image: img
            });

        }
    }

    onCreate() {
        const userDetails = {
            userName: this.state.email,
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            specializationId: this.state.specializationId,
            email: this.state.email,
            password: this.state.password,
            image: this.state.image
        }

        this.props.createDoctor(userDetails);
    }

    render() {

        const { specializations } = this.props.specializations

        return <div class="bform py-5">
            <div class="row">
                <div class="container">
                    <div class="col-lg-3 mx-auto align-justify-center pr-4 pl-0 contact-form">
                        <div class="">
                            <h2 class="mb-3 font-weight-light">Добавить врача</h2>
                            <div class="row">
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
                                        <select name='option' class="form-control" onChange={this.handleDropdownChange}>
                                            {specializations.map(specialization =>
                                                <option value={specialization.id}>{specialization.specializationName}</option>)}
                                        </select>
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
                                <div class="custom-file">
                                    <input type="file" class="custom-file-input" id="customFile" onChange={this.onImageChange} />
                                    <label class="custom-file-label" for="customFile" />
                                </div>
                                <button type="submit" class="btn btn-md btn-block btn-danger-gradiant text-white border-0" onClick={this.onCreate}>
                                    <span>Добавить</span>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 right-image pl-3">

                </div>
            </div>
        </div>
    }
}

const mapStateToProps = (state) => ({ doctors: state.doctors, specializations: state.specializations });

export default connect(mapStateToProps, { createDoctor, getAllSpecializations })(doctorForm);