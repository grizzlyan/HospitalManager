import React from 'react'
import Specialization from './specialization';
import Doctor from './doctor';
import { connect } from 'react-redux'
import { getPaginDoctors } from '../store/actions/doctorsActions';
import { getAllSpecializations } from '../store/actions/specializationsActions';
import './specializationContainer.css'
import { Pagination } from 'react-bootstrap';

class doctorsContainerPagination extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            page: 1,
            pageSize: 10,
            sortDirection: 1,
            sortField: 1,
            filterDoctorField: 1,
            specializationId: 1
        }

        this.handleDropdownChange = this.handleDropdownChange.bind(this);
    }

    componentDidMount() {

        let pagePagination = {
            page: 1,
            pageSize: 10
        }

        let sortFilterParametres = {
            sortDirection: 1,
            sortField: 1
        }

        let doctorFilterFieldsParametres = {
            filterDoctorField: 1,
            specializationId: 1
        }

        this.props.getPaginDoctors(pagePagination, sortFilterParametres, doctorFilterFieldsParametres);
        this.props.getAllSpecializations();
    }

    handleDropdownChange(e) {
        this.setState({ specializationId: e.target.value }, () => this.onClickChange());
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

        let doctorFilterFieldsParametres = {
            filterDoctorField: this.state.filterDoctorField,
            specializationId: this.state.specializationId
        }

        this.props.getPaginDoctors(pagePagination, sortFilterParametres, doctorFilterFieldsParametres)
    }

    onDelete(id) {
        this.props.deletePatient(id)
    }

    render() {
        const data = this.props.doctors
        let doctors = data.data
        let totalCount = data.totalCount
        let pagesCount = Math.ceil(totalCount / doctors.lenght)


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

        const { specializations } = this.props.specializations

        return <div class="flexColumn" >
            <div class="flexRow">
                <div class="flexColumn" > Сортировка:
                    <button class="btn btn-info btn-sm" onClick={() => this.ascendingSort()}>А-Я</button>
                    <button class="btn btn-secondary btn-sm" onClick={() => this.descendingSort()}>Я-А</button>
                    <hr />
                </div>
                {/* <div class="flexRow">
                    Количество элементов на странице
                    <div class="col-sm-4 mb-3">
                        <div class="form-group">
                            <select name='option' class="form-control" onChange={(e) => this.onPageSizeChange(e)}>
                                <option value={2}>2</option>
                                <option value={3}>3</option>
                                <option value={4}>4</option>
                                <option value={5}>5</option>
                            </select>
                        </div>
                    </div>
                </div> */}
                <div class="flexRow">
                    Отделение
                    <div class="col-lg-12 mb-3">
                        <div class="form-group">
                            <select name='option' class="form-control" onChange={this.handleDropdownChange}>
                                {specializations.map(specialization =>
                                    <option value={specialization.id}>{specialization.specializationName}</option>)}
                            </select>
                        </div>
                    </div>
                </div>
            </div>
            <div><Pagination>{items}</Pagination></div>
            <div class="flexRow">
                {doctors.map(doctor =>
                    <Doctor
                        id={doctor.id}
                        firstName={doctor.firstName}
                        lastName={doctor.lastName}
                        specialization={doctor.specialization}
                        pathToPhoto={doctor.pathToPhoto}
                        specialization={doctor.specialization.specializationName}
                        handleDelete={this.onDelete.bind(this)}
                    />
                )}
            </div>
            <br />
        </div >
    }
}




const mapStateToProps = (state) => ({ doctors: state.doctors, specializations: state.specializations });

export default connect(mapStateToProps, { getPaginDoctors, getAllSpecializations })(doctorsContainerPagination);