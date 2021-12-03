import React from 'react'
import { authorization } from '../store/actions/authorizationAction'
import { connect } from 'react-redux'
import './regAuthFormStyle.css'

export class AuthorizationForm extends React.Component {
    constructor(props) {
        super(props);

        this.onUserNameChange = this.onUserNameChange.bind(this);
        this.onPasswordChange = this.onPasswordChange.bind(this);
    }

    onUserNameChange(e) {
        let val = e.target.value;
        this.setState({ userName: val });
    }

    onPasswordChange(e) {
        let val = e.target.value;
        this.setState({ password: val });
    }

    onAuthorization() {
        const credentials = {
            username: this.state.username,
            password: this.state.password,
        }

        this.props.authorization(credentials);
    }

    render() {
        return <div class="bform py-5">
            <div class="column">
                <div class="container">
                    <div class="col-lg-6 mx-auto pr-4 pl-0 contact-form">
                        <div class="">
                            <h2 class="mb-3 font-weight-light">Авторизация</h2>
                            <h6 class="subtitle font-weight-normal">Lorem ipsum dolor sit amet, adipiscing.</h6>
                            <div class="row">
                                <div class="col-lg-12 mb-3">
                                    <div class="form-group">
                                        <input class="form-control" type="text" placeholder="логин" onChange={this.onUserNameChange} required />
                                    </div>
                                </div>
                                <div class="col-lg-12 mb-3">
                                    <div class="form-group">
                                        <input class="form-control" type="password" placeholder="пароль" onChange={this.onPasswordChange} required />
                                    </div>
                                </div>

                                    <button type="submit" class="btn btn-md btn-block btn-danger-gradiant text-white border-0" onClick={() => this.onAuthorization()}>
                                        <span> Вход</span>
                                    </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 right-image pl-3">
                </div>
            </div>
        </div>
    }
}

const mapStateToProps = (state) => ({ AuthorizationForm: state.AuthorizationForm });

export default connect(mapStateToProps, { authorization })(AuthorizationForm);