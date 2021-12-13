import React from 'react'
import Specialization from './specialization';
import { connect } from 'react-redux'
import { getSpecializations } from '../store/actions/specializationsActions';
import './specializationContainer.css'
import { Pagination } from 'react-bootstrap';

class specializationsContainerPagination extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            page: 1,
            pageSize: 4,
            sortDirection: 1,
            sortField: 1
        }
    }

    componentDidMount() {
        let pagePagination = {
            page: this.state.page,
            pageSize: this.state.pageSize
        }

        let sortFilterParametres = {
            sortDirection: this.state.sortDirection,
            sortField: this.state.sortField
        }

        this.props.getSpecializations(pagePagination, sortFilterParametres)
    }

    onClickChange(page) {

        console.log(page)
        this.setState({ page: page })

        let pagePagination = {
            page: this.state.page,
            pageSize: this.state.pageSize
        }

        let sortFilterParametres = {
            sortDirection: this.state.sortDirection,
            sortField: this.state.sortField
        }

        this.props.getSpecializations(pagePagination, sortFilterParametres)
    }

    onDelete(id) {
        this.props.deletePatient(id)
    }

    render() {
        const data = this.props.specializations
        let specializations = data.data
        let totalCount = data.totalCount
        let actPage = data.page
        console.log(actPage)
        let pagesCount = Math.ceil(totalCount / this.state.pageSize)


        let active = this.state.page;
        let items = [];

        for (let number = 1; number <= pagesCount; number++) {
            let a = number;
            items.push(
                <Pagination.Item key={number} active={number === active} onClick={() => this.onClickChange(a)}>
                    {number}
                </Pagination.Item>,
            );
        }


        // let pages = new Array(pagesCount);
        // for (var i = 0; i < pages.length; i++) {
        //     pages[i] = i + 1;
        // }

        // console.log(pages)


        return <div class="flexColumn">
            <div class="flexRow">
                {specializations.map(specialization =>
                    <Specialization
                        id={specialization.id}
                        specializationName={specialization.specializationName}
                        description={specialization.description}
                    />
                )}
            </div>
            <Pagination>{items}</Pagination>
            <br />
            {/* <ul class="pagination">
                <li class="page-item" disabled><a class="page-link" href="#">&lsaquo; Предыдущая</a></li>
                {pages.map(page =>
                    <li class="page-item" active><a class="page-link" onClick={() => this.onClickChange(page)} >{page}</a></li>
                )}
                <li class="page-item" disabled><a class="page-link" href="#">Следующая &rsaquo;</a></li>
            </ul> */}
        </div>
    }
}


const mapStateToProps = (state) => ({ specializations: state.specializations });

export default connect(mapStateToProps, { getSpecializations })(specializationsContainerPagination);