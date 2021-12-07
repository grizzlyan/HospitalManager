import React from 'react'
import { connect } from 'react-redux'
import { getAppointmentByDoctorId } from '../store/actions/appointmentsActions';

export class appointmentCalendar extends React.Component {
  constructor(props) {
    super(props);
  }

  // componentDidMount() {
  //   this.props.getAppointments()
  // }

  render() {
    //const { appointments } = this.props.appointment;


    return <div class="flexColumn">

      <div>
        <label for="party">Введите дату::</label>
        <input type="date" id="party" name="party" min={new Date(new Date().setDate(new Date().getDate() + 1)).toISOString().split("T")[0]}
          max={new Date(new Date().setDate(new Date().getDate() + 30)).toISOString().split("T")[0]} required />
        <span class="validity"></span>
        <br />
      </div>

      <label for="from">Время приёма: </label>
      <select name="from" id="from">
        <option value="1">8:00</option>
        <option value="2">9:00</option>
        <option value="3">10:00</option>
        <option value="4">11:00</option>
        <option value="5">13:00</option>
        <option value="1">14:00</option>
        <option value="2">15:00</option>
        <option value="3">16:00</option>
      </select>
      <hr />
      <div>
        <input type="button" value="Submit form" />
      </div>
    </div>
  }
}

const mapStateToProps = (state) => ({ appointments: state.appointments });

export default connect(mapStateToProps, { getAppointmentByDoctorId })(appointmentCalendar);