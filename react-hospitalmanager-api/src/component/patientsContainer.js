import React from 'react'
import { connect } from 'react-redux'
import Link from 'react-router-dom/Link';
import { getPatients, deletePatient } from '../store/actions/patientsActions';

class patientsContainer extends React.Component {
    constructor(props) {
        super(props);

    }

    onDelete(id){
        this.props.deletePatient(id)
    }

    componentDidMount() {
        this.props.getPatients()
    }

    render() {
        const { patients } = this.props.patients;


        return <div class="flexColumn">
            {patients.map(patient =>
                <div>ID-{patient.id}. {patient.firstName} {patient.lastName}. Город - {patient.city}
                    <br />
                    <Link class="btn btn-warning btn-sm" to={{ pathname: '/cabinet/editPatient', state: {
                        id: patient.id,
                        firstName: patient.firstName,
                        lastName: patient.lastName,
                        city: patient.city }}} >Редактировать пациента</Link>
                    <button class="btn btn-danger btn-sm" onClick={() => this.onDelete(patient.id)}>Удалить пациента</button>
                    <hr />
                </div>)}
        </div>
    }
}

const mapStateToProps = (state) => ({ patients: state.patients });

export default connect(mapStateToProps, { getPatients, deletePatient })(patientsContainer);