import React from 'react'

export default class Specialization extends React.Component {

    render() {
        return <div class="specialization">
            <h2>{this.props.specializationName}</h2>
        </div>
    }
}