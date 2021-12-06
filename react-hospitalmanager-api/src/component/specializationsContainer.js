import React from 'react'
import Specialization from './specialization';
import { connect } from 'react-redux'
import { getSpecializations } from '../store/actions/specializationsActions';

// const spec = [{specializationName: 'a', description: 'a'},
//  {specializationName: 'b', description: 'b'}, 
//  {specializationName: 'c', description: 'c'}, 
//  {specializationName: 'd', description: 'd'}];

//  const kolvo = [1,2]

export class specializationContainer extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.getSpecializations()
    }

    render() {
        const { specializations } = this.props.specializations
        const { totalCount } = this.props.totalCount;
        const { pagesCount } = Math.ceil(totalCount / specializations.lenght);
        let { pages } = new Array(pagesCount);
        for (var i = 0; i < pages.length; i++) {
            pages[i] = i + 1;
        }

        return <div class="flexColumn">
            <div class="flexRow">
                {specializations.map(specialization =>
                (<Specialization
                    specializationName={specialization.specializationName}
                    description={specialization.description} />
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

const mapStateToProps = (state) => ({ specializations: state.specializations });

export default connect(mapStateToProps, { getSpecializations })(specializationContainer);