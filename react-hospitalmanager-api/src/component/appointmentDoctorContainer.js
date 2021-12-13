import React from 'react'
import { connect } from 'react-redux'
import { getAppointmentByDoctorId } from '../store/actions/appointmentsActions';

 class appointmentDoctorContainer extends React.Component {
    constructor(props) {
        super(props);

        this.state={
            id : this.props.location.state.id,
        }
    }

    componentDidMount() {
        this.props.getAppointmentByDoctorId(this.state.id)
    }

    render() {
        const { appointments } = this.props.appointments;

        let heading;
        let appointmentsList;
        let isHistory = this.props.location.state.isHistory;

        if (isHistory === true) {

            heading = <h3>История приёмов</h3>

            appointmentsList = appointments.filter(p=>p.appointmentDate < new Date().toISOString()).map(appointment =>
                <div>ID-{appointment.id}. Дата: {appointment.appointmentDate}. Пациент - {appointment.patient.firstName} {appointment.patient.lastName}</div>)
        }
        else {
            heading = <h3>Предстоящие приёмы</h3>

            appointmentsList = appointments.filter(p=>p.appointmentDate > new Date().toISOString()).map(appointment =>
                <div>ID-{appointment.id}. Дата: {appointment.appointmentDate}. Пациент - {appointment.patient.firstName} {appointment.patient.lastName}</div>)
        }

        return <div class="flexColumn">
            <div>{heading}</div>
            <div>{appointmentsList}</div>
        </div>
    }
}

const mapStateToProps = (state) => ({ appointments: state.appointments });

export default connect(mapStateToProps, { getAppointmentByDoctorId })(appointmentDoctorContainer);