import React from 'react'
import { createSpecialization } from '../store/actions/specializationsActions';
import { connect } from 'react-redux'
import './regAuthFormStyle.css'

class specializationForm extends React.Component {
    constructor(props) {
        super(props);

        this.onUserNameChange = this.onSpecializationNameChange.bind(this);
        this.onPasswordChange = this.onDescriptionChange.bind(this);
    }

    onSpecializationNameChange(e) {
        let val = e.target.value;
        this.setState({ userName: val });
    }

    onDescriptionChange(e) {
        let val = e.target.value;
        this.setState({ password: val });
    }

    onCreate() {
        const credentials = {
            specializationName: this.state.specializationName,
            description: this.state.description,
        }

        this.props.createSpecialization(credentials);
    }

    render() {
        return <div class="bform py-5">
            <div class="row">
                <div class="container">
                    <div class="col-lg-3 mx-auto align-justify-center pr-4 pl-0 contact-form">
                        <div class="">
                            <h2 class="mb-3 font-weight-light">Новое отделение</h2>
                            <div class="row">
                                <div class="col-lg-12 mb-3">
                                    <div class="form-group">
                                        <input class="form-control" type="text" placeholder="название отделения" onChange={this.onSpecializationNameChange} required />
                                    </div>
                                </div>
                                <div class="col-lg-12 mb-3">
                                    <div class="form-group">
                                    <input class="form-control" type="text" placeholder="описание" onChange={this.onDescriptionChange} required />
                                    </div>
                                </div>
                                <button type="submit" class="btn btn-md btn-block btn-danger-gradiant text-white border-0" onClick={() => this.onCreate()}>
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

const mapStateToProps = (state) => ({ specializations: state.specializations });

export default connect(mapStateToProps, { createSpecialization })(specializationForm);