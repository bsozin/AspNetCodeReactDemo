import React, { Component } from 'react';
import PropTypes from 'prop-types';

/* Одна страница представления табдичных данных */
export class Table extends Component {

    constructor(props) {
        super(props);
        this.state = { rows: props.rows };
    }

    static getDerivedStateFromProps(props, state) {
        return { rows: props.rows };
    }

    render() {
        return (
            <table className='table table-striped' aria-labelledby='tabelLabel'>
                <thead>
                    <tr>
                        <th>Модель</th>
                        <th>Бренд</th>
                        <th>Кузов</th>
                        <th>Мест</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.rows.map(row =>
                        <tr key={row.id}>
                            <td>{row.name}</td>
                            <td>{row.brand.name}</td>
                            <td>{row.bodyType.name}</td>
                            <td>{row.seatsCount}</td>
                            <td><button type='button' className='btn btn-primary btn-sm' onClick={() => this.props.onEdit(row)}>Редактировать</button></td>
                            <td><button type='button' className='btn btn-danger btn-sm' onClick={() => this.props.onDelete(row)}>Удалить</button></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}

Table.propTypes = {
    rows: PropTypes.array.isRequired,
    onEdit: PropTypes.func.isRequired,
    onDelete: PropTypes.func.isRequired
};
