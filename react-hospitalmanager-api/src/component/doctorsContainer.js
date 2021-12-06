import React from 'react'
import Doctor from './doctor';
import { connect } from 'react-redux'
import { getDoctors } from '../store/actions/doctorsActions'

export class doctorsContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getDoctors()
    }

    render() {
        const { doctors } = this.props.doctors;
        const { totalCount } = this.props.totalCount;
        const { pagesCount } = Math.ceil(totalCount / doctors.lenght);
        let { pages } = new Array(pagesCount);
        for (var i = 0; i < pages.length; i++) {
            pages[i] = i + 1;
        }


        return <div class="flexColumn">
            <div class="flexRow">
                {doctors.map(doctor =>
                (<Doctor
                    firstName={doctor.firstName}
                    lastName={doctor.lastName}
                    specialization={doctor.specialization}
                    workExperience={doctor.workExperience}
                    pathToPhoto={doctor.pathToPhoto} />
                ))}
            </div>
            <ul class="pagination">
                <li class="page-item" disabled><a class="page-link" href="#">&lsaquo; Предыдущая</a></li>
                {pages.map(page =>
                    <li class="page-item" active><a class="page-link" href="#">{page}</a></li>
                )}
                <li class="page-item" disabled><a class="page-link" href="#">Следующая &rsaquo;</a></li>
            </ul>
        </div>
    }
}

const mapStateToProps = (state) => ({ doctors: state.doctors });

export default connect(mapStateToProps, { getDoctors })(doctorsContainer);