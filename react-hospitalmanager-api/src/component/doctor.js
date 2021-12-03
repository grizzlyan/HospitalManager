import React from 'react'

export default class Doctor extends React.Component {

    render() {
        return <div class="doctor">
            <img class="doctorPhoto" src = {this.props.pathToPhoto}/>
            <h2>{this.props.firstName} {this.props.lastName}</h2>
            <h4>{this.props.specialization}</h4>
            <h5>{this.props.workExperience}</h5>
        </div>
    }
}