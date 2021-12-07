import React from 'react'
import { connect } from 'react-redux'
import { getAppointments } from '../store/actions/appointmentsActions';

export class appointmentsContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getAppointments()
    }

    render() {
        const { appointments } = this.props.appointment;

        return <div class="flexColumn">

            {appointments.map(appointment =>
                <div>ID {appointment.id} {appointment.appointmentDate} {appointment.appointmentDuration} Врач - {appointment.doctorId} Пациент - {appointment.patientId}</div>)}
        </div>
    }
}

const mapStateToProps = (state) => ({ appointments: state.appointments });

export default connect(mapStateToProps, { getAppointments })(appointmentsContainer);