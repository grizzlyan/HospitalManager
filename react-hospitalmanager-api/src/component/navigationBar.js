import React from 'react'
import { connect } from 'react-redux'

export class NavigationBar extends React.Component {
    render() {
        return             <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <a class="navbar-brand" href="#">Navbar</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="#">Главная</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Отделения</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Наши врачи</a>
                        </li>
                    </ul>
                </div>

                <div>
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Регистрация</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/login">Войти</a>
                        </li>
                    </ul>
                </div>
            </nav>

    }
}

const mapStateToProps = (state) => ({ NavigationBar: state.NavigationBar });

export default connect(mapStateToProps)(NavigationBar);