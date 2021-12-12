import React from 'react'
import { updateSpecialization } from '../store/actions/specializationsActions';
import { connect } from 'react-redux'
import './regAuthFormStyle.css'

class editSpecializationForm extends React.Component {
    constructor(props) {
        super(props);

        this.state={
            id: this.props.location.state.id,
            specializationName: this.props.location.state.specializationName,
            description: this.props.location.state.description
        }

        this.onSpecializationNameChange = this.onSpecializationNameChange.bind(this);
        this.onDescriptionChange = this.onDescriptionChange.bind(this);
    }

    onSpecializationNameChange(e) {
        let val = e.target.value;
        this.setState({ specializationName: val });
    }

    onDescriptionChange(e) {
        let val = e.target.value;
        this.setState({ description: val });
    }

    onCreate() {
        const credentials = {
            id: this.state.id,
            specializationName: this.state.specializationName,
            description: this.state.description,
        }

        this.props.updateSpecialization(credentials);
    }

    render() {
        return <div class="bform py-5">
            <div class="row">
                <div class="container">
                    <div class="col-lg-3 mx-auto align-justify-center pr-4 pl-0 contact-form">
                        <div class="">
                            <h2 class="mb-3 font-weight-light">Редактировать отделение</h2>
                            <div class="row">
                                <div class="col-lg-12 mb-3">
                                    <div class="form-group">
                                        <input class="form-control" type="text" value={this.state.specializationName} onChange={this.onSpecializationNameChange} required />
                                    </div>
                                </div>
                                <div class="col-lg-12 mb-3">
                                    <div class="form-group">
                                        <input class="form-control" type="text" value={this.state.description} onChange={this.onDescriptionChange} required />
                                    </div>
                                </div>
                                <button type="submit" class="btn btn-md btn-block btn-danger-gradiant text-white border-0" onClick={() => this.onCreate()}>
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

export default connect(mapStateToProps, { updateSpecialization })(editSpecializationForm);