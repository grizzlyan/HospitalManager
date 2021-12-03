import React from 'react'
import Doctor from './doctor';

class DoctorsContainer extends React.Component {
    render() {
        const { doctorsContainer } = this.props.doctorsContainer

        return <div class="flexColumn">
            <div class="flexRow">
                {doctorsContainer.map(doctor => 
                (<Doctor 
                    firstName = {doctor.firstName}
                    lastName = {doctor.lastName}
                    specialization = {doctor.specialization}
                    workExperience = {doctor.workExperience}
                    pathToPhoto = {doctor.pathToPhoto}/>
                ))}
            </div>
        </div>
    }
}