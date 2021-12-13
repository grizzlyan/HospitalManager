import React from 'react'
import { connect } from 'react-redux'
import { updatePatient } from '../store/actions/patientsActions';
import './regAuthFormStyle.css'

class editPatientForm extends React.Component {
    constructor(props) {
        super(props);

        this.onFirstNameChange = this.onFirstNameChange.bind(this);
        this.onLastNameChange = this.onLastNameChange.bind(this);
        this.onCityChange = this.onCityChange.bind(this);
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

    onCreate(id) {
        const userDetails = {
            id: id,
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            city: this.state.city,
        }

        this.props.updatePatient(userDetails);
    }


    render() {

        return <div class="bform py-5">
            <div class="row">
                <div class="container">
                    <div class="col-lg-3 mx-auto align-justify-center pr-4 pl-0 contact-form">
                        <div class="">
                            <h2 class="mb-3 font-weight-light">Редактировать пациента</h2>
                            <div class="row">
                                <div class="col-lg-12 mb-3">
                                    <div class="form-group">
                                        <input class="form-control" type="text" placeholder={this.props.location.state.firstName} onChange={this.onFirstNameChange} required />
                                    </div>
                                </div>
                                <div class="col-lg-12 mb-3">
                                    <div class="form-group">
                                        <input class="form-control" type="text" placeholder={this.props.location.state.lastName} onChange={this.onLastNameChange} required />
                                    </div>
                                </div>
                                <div class="col-lg-12 mb-3">
                                    <div class="form-group">
                                        <input class="form-control" type="text" placeholder={this.props.location.state.city} onChange={this.onCityChange} required />
                                    </div>
                                </div>
                                <button type="submit" class="btn btn-md btn-block btn-danger-gradiant text-white border-0" onClick={() => this.onCreate(this.props.location.state.id)} >
                                    <span>Сохранить</span>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    }
}

export default connect(null, { updatePatient })(editPatientForm);