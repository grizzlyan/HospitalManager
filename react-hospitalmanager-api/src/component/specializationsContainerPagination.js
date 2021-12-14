import React from 'react'
import Specialization from './specialization';
import { connect } from 'react-redux'
import { getSpecializations, deleteSpecialization } from '../store/actions/specializationsActions';
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
            page: 1,
            pageSize: 4
        }

        let sortFilterParametres = {
            sortDirection: 1,
            sortField: 1
        }

        this.props.getSpecializations(pagePagination, sortFilterParametres)
    }


    clickChange(page) {
        this.setState({ page: page }, () => this.onClickChange())
    }

    ascendingSort() {
        this.setState({ sortDirection: 1 }, () => this.onClickChange())
    }
    descendingSort() {
        this.setState({ sortDirection: 2 }, () => this.onClickChange())
    }


    onPageSizeChange(event) {
        let value = event.target.value;
        console.log(value)
        this.setState({ pageSize: value }, () => this.onClickChange());
    }

    onClickChange() {
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
        this.props.deleteSpecialization(id)
    }

    render() {
        const data = this.props.specializations
        console.log(data)
        let specializations = data.data
        console.log(specializations)
        let totalCount = data.totalCount

        let pagesCount = Math.ceil(totalCount / this.state.pageSize)


        let active = this.state.page;
        let items = [];

        for (let number = 1; number <= pagesCount; number++) {
            let a = number;
            items.push(
                <Pagination.Item key={number} active={number === active} onClick={() => this.clickChange(a)} >
                    {number}
                </Pagination.Item >
            );
        }


        return <div class="flexColumn" >
            <div class="flexRow">
                <div class="flexColumn" > Сортировка:
                    <button class="btn btn-info btn-sm" onClick={() => this.ascendingSort()}>А-Я</button>
                    <button class="btn btn-secondary btn-sm" onClick={() => this.descendingSort()}>Я-А</button>
                    <hr />
                </div>
                <div class="flexRow">
                    Количество элементов на странице
                    <div class="col-sm-4 mb-3">
                        <div class="form-group">
                            <select name='option' class="form-control" onChange={(e) => this.onPageSizeChange(e)}>
                                <option value={4}>4</option>
                                <option value={6}>6</option>
                                <option value={8}>8</option>
                                <option value={10}>10</option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>
            <div><Pagination>{items}</Pagination></div>
            <div class="flexRow">
                {specializations.map(specialization =>
                    <Specialization
                        id={specialization.id}
                        specializationName={specialization.specializationName}
                        description={specialization.description}
                        handleDelete={this.onDelete.bind(this)}
                    />
                )}
            </div>
            
            <br />
        </div >
    }
}




const mapStateToProps = (state) => ({ specializations: state.specializations });

export default connect(mapStateToProps, { getSpecializations, deleteSpecialization })(specializationsContainerPagination);