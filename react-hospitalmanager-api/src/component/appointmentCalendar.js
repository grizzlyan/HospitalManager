import React from 'react'
import ReactDatePicker from 'react-datepicker';
import { connect } from 'react-redux'
import { getAppointmentByDoctorId, createAppointment} from '../store/actions/appointmentsActions';
import './regAuthFormStyle.css'

 class appointmentCalendar extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      doctorId: this.props.location.state.doctorId,
      doctorFirstName: this.props.location.state.doctorFirstName,
      doctorLastName: this.props.location.state.doctorLastName,
      doctorSpecialization: this.props.location.state.doctorSpecialization,
      patientId: this.props.location.state.patientId,
      timeAppointment: 8
    }

    this.onCreate = this.onCreate.bind(this)
  }

  onDateChange(event){
    let value = event.target.value;
    console.log(value)
    this.setState({dateAppointment: value})
  }

  onTimeChange(event) {
    let value = event.target.value;
    console.log(value)
    this.setState({ timeAppointment: value });
  }

  onCreate() {

    let date = new Date(this.state.dateAppointment).setHours(this.state.timeAppointment, 0, 0);
    console.log(date)
    let ne = new Date(date);
    console.log(ne)

    const appointmentDetails = {
        appointmentDate: ne,
        doctorId: this.state.doctorId,
        patientId: this.state.patientId
    }

    this.props.createAppointment(appointmentDetails);
}

  // componentDidMount() {
  //   this.props.getAppointments()
  // }

  render() {
    //const { appointments } = this.props.appointment;


    return <div class="bform py-5">
      <div class="row">
        <div class="container">
          <div class="col-lg-3 mx-auto align-justify-center pr-4 pl-0 contact-form">
            <div class="">
              <h5 class="mb-3 font-weight-light">Врач: {this.state.doctorFirstName} {this.state.doctorLastName}.<br/>Отделение: {this.state.doctorSpecialization}</h5>
              <h3 class="mb-3 font-weight-light">Введите дату:</h3>
              <div class="row">
                <div class="col-lg-12 mb-3">
                  <div class="form-group">
                    <input type="date" name='option' class="form-control" min={new Date(new Date().setDate(new Date().getDate() + 1)).toISOString().split("T")[0]}
                      max={new Date(new Date().setDate(new Date().getDate() + 30)).toISOString().split("T")[0]} onChange={(e) => this.onDateChange(e)} required />
                  </div>
                </div>
                <h3 class="mb-3 font-weight-light">Время приёма:</h3>
                <div class="col-lg-12 mb-3">
                  <div class="form-group">
                    <select name='option' class="form-control" onChange={(e) => this.onTimeChange(e)}>
                      <option value={8}>8:00</option>
                      <option value={9}>9:00</option>
                      <option value={10}>10:00</option>
                      <option value={11}>11:00</option>
                      <option value={13}>13:00</option>
                      <option value={14}>14:00</option>
                      <option value={15}>15:00</option>
                      <option value={16}>16:00</option>
                    </select>
                  </div>
                </div>
                <button type="submit" class="btn btn-md btn-block btn-danger-gradiant text-white border-0" onClick={this.onCreate}>
                  <span>Записаться</span>
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  }
}

const mapStateToProps = (state) => ({ appointments: state.appointments });

export default connect(mapStateToProps, { getAppointmentByDoctorId, createAppointment })(appointmentCalendar);