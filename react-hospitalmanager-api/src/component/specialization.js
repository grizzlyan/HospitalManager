import React from 'react'

export default class Specialization extends React.Component {

    render() {
        return <div class="card text-center" style={{width: '18rem'}}>
        <div class="card-body">
          <h5 class="card-title">{this.props.specializationName}</h5>
          <p class="card-text">{this.props.description}</p>
          <a href="#" class="btn btn-primary">Переход куда-нибудь</a>
        </div>
      </div>
    }
}