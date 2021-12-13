import React from 'react'
import { connect } from 'react-redux'
import { getAppointmentByPatientId, deleteAppointment } from '../store/actions/appointmentsActions';

class appointmentPatientContainer extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            id: this.props.location.state.id,
        }
    }

    componentDidMount() {
        this.props.getAppointmentByPatientId(this.state.id)
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
                <div>ID-{appointment.id}. Дата: {appointment.appointmentDate}. Врач - {appointment.doctor.firstName} {appointment.doctor.lastName}</div>)
        }
        else {
            heading = <h3>Предстоящие приёмы</h3>

            appointmentsList = appointments.filter(p => p.appointmentDate > new Date().toISOString()).map(appointment =>
                <ul>
                    <li>
                    ID-{appointment.id}. Дата: {appointment.appointmentDate}. Врач - {appointment.doctor.firstName} {appointment.doctor.lastName}
                    <br/>
                    <button class="btn btn-danger btn-sm" onClick={()=>this.onDelete(appointment.id)}>Отменить приём</button>
                    </li>
                </ul>)
        }

        return <div class="flexColumn">
            <div>{heading}</div>
            <div>{appointmentsList}</div>
        </div>
    }
}

const mapStateToProps = (state) => ({ appointments: state.appointments });

export default connect(mapStateToProps, { getAppointmentByPatientId, deleteAppointment })(appointmentPatientContainer);