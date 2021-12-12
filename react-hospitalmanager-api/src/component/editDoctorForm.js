import React from 'react'
import { updateDoctor } from '../store/actions/doctorsActions';
import { getAllSpecializations } from "../store/actions/specializationsActions";
import { connect } from 'react-redux'
import './regAuthFormStyle.css'

class editDoctorForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            id: this.props.location.state.id,
            specializationId: 1
        };

        this.onFirstNameChange = this.onFirstNameChange.bind(this);
        this.onLastNameChange = this.onLastNameChange.bind(this);
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

    onCreate() {
        const userDetails = {
            id: this.state.id,
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            specializationId: this.state.specializationId,
        }

        this.props.updateDoctor(userDetails);
    }

    render() {

        const { specializations } = this.props.specializations

        return <div class="bform py-5">
            <div class="row">
                <div class="container">
                    <div class="col-lg-3 mx-auto align-justify-center pr-4 pl-0 contact-form">
                        <div class="">
                            <h2 class="mb-3 font-weight-light">Редактировать врача</h2>
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
                                        <select name='option' class="form-control" onChange={this.handleDropdownChange}>
                                            {specializations.map(specialization =>
                                                <option value={specialization.id}>{specialization.specializationName}</option>)}
                                        </select>
                                    </div>
                                </div>
                                <button type="submit" class="btn btn-md btn-block btn-danger-gradiant text-white border-0" onClick={this.onCreate}>
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

const mapStateToProps = (state) => ({ specializations: state.specializations });

export default connect(mapStateToProps, { updateDoctor, getAllSpecializations })(editDoctorForm);