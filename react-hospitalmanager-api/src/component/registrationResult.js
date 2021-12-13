import React from 'react'
import './registrationResultStyle.css'

export class registrationResultSuccess extends React.Component {

    render() {

        return (
            <div class="one">
               <h1>Успешная регистрация!</h1>
            </div>
        )
    }
}

export class registrationResultError extends React.Component {

    render() {

        return (
            <div class="oneError">
                <h1>Ошибка регистрации!</h1>
            </div>
        )
    }
}

export class addSpecializationResultSuccess extends React.Component {

    render() {

        return (
            <div class="one">
                <h1>Новое отделение успешно добавлено!</h1>
            </div>
        )
    }
}

export class addSpecializationResultError extends React.Component {

    render() {

        return (
            <div class="oneError">
                <h1>Ошибка добавления нового отделения!</h1>
            </div>
        )
    }
}

export class editComponentSuccess extends React.Component {

    render() {

        return (
            <div class="one">
                <h1>Успешно отредактировано!</h1>
            </div>
        )
    }
}

export class editComponentError extends React.Component {

    render() {

        return (
            <div class="oneError">
                <h1>Ошибка редактирования!</h1>
            </div>
        )
    }
}

export class appointmentSuccess extends React.Component {

    render() {

        return (
            <div class="one">
                <h1>Вы записаны!</h1>
            </div>
        )
    }
}

export class appointmentError extends React.Component {

    render() {

        return (
            <div class="oneError">
                <h1>Ошибка записи!</h1>
            </div>
        )
    }
}
