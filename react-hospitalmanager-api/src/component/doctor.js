import React from 'react'
import './specializationContainer.css'
import editDoctorForm from './editDoctorForm';
import Link from 'react-router-dom/Link';

export default class Doctor extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            id: this.props.id,
            firstName: this.props.firstName,
            lastName: this.props.lastName,
            specialization: this.props.specialization
        }
    }

    render() {

        const pathToPhoto = `https://localhost:44333/${this.props.pathToPhoto}`

        let footerButtons;
        let userData;
        let role = '';

        const retrievedStoreStr = localStorage.getItem('userData')

        if (retrievedStoreStr) {
            userData = JSON.parse(retrievedStoreStr)
            role = userData.role;
        }

        if (role == 'Manager') {
            footerButtons = <div class="footer">
                <Link class="btn btn-warning" to={{ pathname: '/cabinet/editDoctor', state: { id: this.props.id, firstName: this.props.firstName, lastName: this.props.lastName } }}>Редактировать</Link>
                <button class="btn btn-danger" onClick={() => this.props.handleDelete(this.props.id)} >Удалить</button>
            </div>
        }

        else if (role == 'Patient') {

            let patientId = userData.id;

            footerButtons = <div class="footer">
                <button class="btn btn-primary">Информация</button>
                <Link class="btn btn-success" to={{
                    pathname: '/cabinet/p-createAppointment',
                    state: {
                        doctorId: this.state.id,
                        doctorFirstName: this.props.firstName,
                        doctorLastName: this.props.lastName,
                        doctorSpecialization: this.props.specialization,
                        patientId: patientId
                    }
                }} >Записаться</Link>
            </div>
        }

        else {
            footerButtons = <div class="footer">
                <button class="btn btn-primary">Информация</button>
            </div>
        }

        return <div class="card" style={{ width: '18rem' }}>
            <img src={pathToPhoto} class="card-img-top" />
            <div class="footer">
                <div class="card-body">
                    <h5 class="card-title">{this.props.firstName} {this.props.lastName}</h5>
                    <p class="card-text">{this.props.specialization}</p>
                </div>
                {footerButtons}
            </div>
        </div>
    }
}