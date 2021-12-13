import React from 'react'
import { connect } from 'react-redux'
import { getAppointments, deleteAppointment } from '../store/actions/appointmentsActions';


class appointmentsContainer extends React.Component {
    constructor(props) {
        super(props)
    }

    componentDidMount() {
        this.props.getAppointments()
    }

    onDelete(id) {
        this.props.deleteAppointment(id)
    }

    render() {
        const { appointments } = this.props.appointments;

        let heading;
        let appointmentsList;
        let isHistory = this.props.location.state.isHistory;

        if (isHistory === true) {

            heading = <h3>История приёмов</h3>

            appointmentsList = appointments.filter(p => p.appointmentDate < new Date().toISOString()).map(appointment =>
                <div>ID-{appointment.id}. Дата: {appointment.appointmentDate}. Врач - {appointment.doctor.firstName} {appointment.doctor.lastName}. Пациент - {appointment.patient.firstName} {appointment.patient.lastName}.</div>)
        }
        else {
            heading = <h3>Предстоящие приёмы</h3>

            appointmentsList = appointments.filter(p => p.appointmentDate > new Date().toISOString()).map(appointment =>
                <ul class='appCont'>
                    <li class='appCont'>
                        ID-{appointment.id}. Дата: {appointment.appointmentDate}. Врач - {appointment.doctor.firstName} {appointment.doctor.lastName}. Пациент - {appointment.patient.firstName} {appointment.patient.lastName}
                        <br />
                        <button class="btn btn-danger" onClick={() => this.onDelete(appointment.id)}>Отменить приём</button>
                        <hr />
                    </li>

                </ul>)
        }

        return <div class="flexColumn">
            <div>{heading}</div>
            <div>{appointmentsList}</div>
            {/* {appointments.map(appointment =>
                <div>ID-{appointment.id}. Дата: {appointment.appointmentDate}. Врач - {appointment.doctor.firstName} {appointment.doctor.lastName}. Пациент - {appointment.patient.firstName} {appointment.patient.lastName}</div>)} */}
        </div>
    }
}

const mapStateToProps = (state) => ({ appointments: state.appointments });

export default connect(mapStateToProps, { getAppointments, deleteAppointment })(appointmentsContainer);