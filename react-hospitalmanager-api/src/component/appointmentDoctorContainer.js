import React from 'react'
import { connect } from 'react-redux'
import { getAppointmentByDoctorId } from '../store/actions/appointmentsActions';

export class appointmentsContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getAppointments()
    }

    render() {
        const { appointments } = this.props.appointment;

        let appointmentsList;
        let isHistory;

        if (isHistory === true) {
            appointmentsList = appointments.filter(p=>p.appointmentDate < new Date().getDate()).map(appointment =>
                <div>ID {appointment.id} {appointment.appointmentDate} {appointment.appointmentDuration} Врач - {appointment.doctorId} Пациент - {appointment.patientId}</div>)
        }
        else {
            appointmentsList = appointments.filter(p=>p.appointmentDate > new Date().getDate()).map(appointment =>
                <div>ID {appointment.id} {appointment.appointmentDate} {appointment.appointmentDuration} Врач - {appointment.doctorId} Пациент - {appointment.patientId}</div>)
        }

        return <div class="flexColumn">
            {appointmentsList}
        </div>
    }
}

const mapStateToProps = (state) => ({ appointments: state.appointments });

export default connect(mapStateToProps, { getAppointmentByDoctorId })(appointmentsContainer);