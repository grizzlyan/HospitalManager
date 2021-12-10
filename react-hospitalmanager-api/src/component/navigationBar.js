import React from 'react'
import { connect } from 'react-redux'
import { Link } from 'react-router-dom';

export class NavigationBar extends React.Component {

    constructor(props) {
        super(props);

        this.onLogOut = this.onLogOut.bind(this);
    }

    onLogOut() {
        localStorage.removeItem('userData')
    }


    render() {

        let code;
        let userData;
        let isLoggedIn;

        const retrievedStoreStr = localStorage.getItem('userData')

        if(retrievedStoreStr) {
        userData = JSON.parse(retrievedStoreStr)
        isLoggedIn = userData.isLoggedIn;
        }


        if (isLoggedIn){
            code = <ul class="navbar-nav ml-auto">
                <li class="nav-item">
                    <Link class="nav-link" to="/cabinet">Личный кабинет</Link>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="/" onClick={this.onLogOut}>Выйти</a>
                </li>
            </ul>
        }
        else {
            code = <ul class="navbar-nav ml-auto">
            <li class="nav-item">
                <Link class="nav-link" to="/registration">Регистрация</Link>
            </li>
            <li class="nav-item">
                <Link class="nav-link" to="/login">Войти</Link>
            </li>
        </ul>
        }

        


        return <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="/"><img src="https://i1.wp.com/studfiles.net/html/2706/977/html_ZWKQtCn5__.5HLr/img-U6Igej.png" width="50" height="50" alt=""/></a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <Link class="nav-link" to="/">Главная</Link>
                    </li>
                    <li class="nav-item">
                        <Link class="nav-link" to="/specializations">Отделения</Link>
                    </li>
                    <li class="nav-item">
                        <Link class="nav-link" to="/doctors">Наши врачи</Link>
                    </li>
                </ul>
            </div>

            <div>
                {code}
            </div>
        </nav>

    }
}

const mapStateToProps = (state) => ({ navigationBar: state.navigationBar });

export default connect(mapStateToProps)(NavigationBar);