import React from 'react'
import Specialization from './specialization';
import { connect } from 'react-redux'
import { getAllSpecializations, deleteSpecialization } from '../store/actions/specializationsActions';

import './specializationContainer.css'
import Link from 'react-router-dom/Link';

class specializationContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getAllSpecializations()
    }

    onDelete(id) {
        this.props.deleteSpecialization(id)
    }

    render() {
        const { specializations } = this.props.specializations

        return <div>
            <Link type="button" class="btn btn-dark" to='/pagSpec'>Постранично</Link>
            <div class="flexRow">
                {specializations.map(specialization =>
                    <Specialization
                        id={specialization.id}
                        specializationName={specialization.specializationName}
                        description={specialization.description}
                        handleDelete={this.onDelete.bind(this)} />
                )}</div>
        </div>
    }
}

const mapStateToProps = (state) => ({ specializations: state.specializations });

export default connect(mapStateToProps, { getAllSpecializations, deleteSpecialization })(specializationContainer);