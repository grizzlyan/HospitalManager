import React from 'react'

export default class Doctor extends React.Component {

    render() {
        return <div class="card" style="width:500px">
            <img class="card-img-top" src={this.props.pathToPhoto} alt="Card image" />
            <div class="card-img-overlay">
                <h4 class="card-title">{this.props.firstName} {this.props.lastName}</h4>
                <p class="card-text">{this.props.specialization}</p>
                <a href="#" class="btn btn-primary">See Profile</a>
            </div>
        </div>


        {/* <div class="doctor">
            <img class="doctorPhoto" src = {this.props.pathToPhoto}/>
            <h2>{this.props.firstName} {this.props.lastName}</h2>
            <h4>{this.props.specialization}</h4>
            <h5>{this.props.workExperience}</h5>
        </div> */}
    }
}