import React from 'react'
import Link from 'react-router-dom/Link';
import './specializationContainer.css'

export default class Specialization extends React.Component {
  constructor(props) {
    super(props)
  }


  render() {

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
        <Link class="btn btn-warning" to={{ pathname: '/cabinet/editSpetialization', state: {
          id: this.props.id, specializationName: this.props.specializationName, description: this.props.description }}}>Редактировать</Link>
        <button class="btn btn-danger" onClick={() => this.props.handleDelete(this.props.id)} >Удалить</button>
      </div>
    }

    else {
      footerButtons = <div class="footer">
        <button class="btn btn-primary">Информация</button>
        
      </div>
    }

    return <div class="card text-center" style={{ width: '18rem' }}>
      <div class="card-body">
        <h5 class="card-title">{this.props.specializationName}</h5>
        <p class="card-text">{this.props.description}</p>
      </div>
      <div class="footer">
        {footerButtons}
      </div>
    </div>
  }
}