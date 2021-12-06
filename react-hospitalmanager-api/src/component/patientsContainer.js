import React from 'react'
import { connect } from 'react-redux'
import { getPatients } from '../store/actions/patientsActions';

export class patientsContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getPatients()
    }

    render() {
        const { patients } = this.props.patients;


        return <div class="flexColumn">

            {patients.map(patient =>
                <div>ID {patient.id} {patient.firstName} {patient.lastName} {patient.city}</div>)}
        </div>
    }
}

const mapStateToProps = (state) => ({ patients: state.patients });

export default connect(mapStateToProps, { getPatients })(patientsContainer);