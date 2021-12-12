import React from 'react'
import Doctor from './doctor';
import { connect } from 'react-redux'
import { getDoctors, deleteDoctor } from '../store/actions/doctorsActions'
import './specializationContainer.css'

class doctorsContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getDoctors()
    }

    onDelete(id){
        this.props.deleteDoctor(id)
    }

    render() {
        const { doctors } = this.props.doctors;

        return <div class="flexColumn">
            <div class="flexRow">
                {doctors.map(doctor => <Doctor
                    id = {doctor.id}
                    firstName={doctor.firstName}
                    lastName={doctor.lastName}
                    specialization={doctor.specialization}
                    pathToPhoto={doctor.pathToPhoto}
                    specialization ={doctor.specialization.specializationName}
                    handleDelete = {this.onDelete.bind(this)} />
                    )}
            </div>
        </div>
    }
}

const mapStateToProps = (state) => ({ doctors: state.doctors });

export default connect(mapStateToProps, { getDoctors, deleteDoctor })(doctorsContainer);