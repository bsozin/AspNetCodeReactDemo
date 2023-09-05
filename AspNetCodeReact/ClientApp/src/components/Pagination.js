import React, { Component, Fragment } from 'react';
import PropTypes from 'prop-types';

/* Компонент постраничной навигации */
export class Pagination extends Component {
    constructor(props) {
        super(props);
        let totalPages = Math.ceil(props.totalItems / props.pageSize);
        this.state = { totalPages: totalPages, currentPage: 0, };
    }

    static getDerivedStateFromProps(props, state) {
        let totalPages = Math.ceil(props.totalItems / props.pageSize);
        if (state.totalPages !== totalPages) {
            let newState = { ...state, totalPages: totalPages };
            if (state.currentPage >= totalPages) {
                let newCurrent = totalPages - 1;
                newState.currentPage = newCurrent > 0 ? newCurrent : 0;
                props.onPageChanged(newCurrent * props.pageSize);
            }
            return newState;
        }
        return null;
    }

    render() {
        let leftStyle = this.state.currentPage > 0 ? "page-link" : "page-link disabled";
        let rightStyle = this.state.currentPage < this.state.totalPages - 1 ? "page-link" : "page-link disabled";
        return (
            <Fragment>
                <nav aria-label='Countries Pagination'>
                    <ul className='pagination'>
                        <li className='page-item'>
                            <a className={leftStyle} href='#' aria-label='Previous' onClick={() => this.handlePageChange(this.state.currentPage - 1)}>Назад</a>
                        </li>
                        <li className='page-item'>
                            <a className='page-link disabled' href='#' >Страница {this.state.currentPage + 1} из {this.state.totalPages === 0 ? 1 : this.state.totalPages}</a>
                        </li>
                        <li className='page-item' >
                            <a className={rightStyle} href='#' aria-label='Next' onClick={() => this.handlePageChange(this.state.currentPage + 1)}>Вперёд</a>
                        </li>
                    </ul>
                </nav>
            </Fragment>
        );
    }

    handlePageChange(newIndex) {
        if (newIndex >= 0 && newIndex < this.state.totalPages)
            this.setState({ ...this.state, currentPage: newIndex }, this.props.onPageChanged(newIndex * this.props.pageSize));
    }

    ensureItemVisible(itemIdx) {
        let requiredPage = Math.floor(itemIdx / this.props.pageSize);
        if (requiredPage !== this.state.currentPage) {
            this.setState({ ...this.state, currentPage: requiredPage }, this.props.onPageChanged(requiredPage * this.props.pageSize));
        }
    }
}

Pagination.propTypes = {
    totalItems: PropTypes.number.isRequired,
    pageSize: PropTypes.number.isRequired,
    onPageChanged: PropTypes.func.isRequired
};
