import React from 'react'
import Specialization from './specialization';

class SpecializationContainer extends React.Component {
    render() {
        const { specializationContainer } = this.props.specializationContainer

        return <div class="flexColumn">
            <div class="flexRow">
                {specializationContainer.map(specialization => 
                (<Specialization 
                    specializationName = {specialization.specializationName}/>
                ))}
            </div>
        </div>
    }
}