import React, { Component } from 'react';
import { Table } from './Table';
import { Pagination } from './Pagination';
import { EditForm } from './EditForm';
import { DeleteForm } from './DeleteForm';

/* Основной компонент представляющей постраничную таблицу с поддержкой CRUD-операций */
export class PagedTable extends Component {

    static ROWS_PER_PAGE = 10;

    constructor(props) {
        super(props);
        this.state = { data: [], loading: true, offset: 0 };
        this.onPageChanged = this.onPageChanged.bind(this);
        this.onEditRow = this.onEditRow.bind(this);
        this.onDeleteRow = this.onDeleteRow.bind(this);
        this.onAddRow = this.onAddRow.bind(this);
        this.onEditResult = this.onEditResult.bind(this);
        this.onAddResult = this.onAddResult.bind(this);
        this.onDeleteResult = this.onDeleteResult.bind(this);
        this.paginatorRef = React.createRef();
    }

    async componentDidMount() {
        do {
            let response = await fetch('cars/cars');
            if (response.ok) {
                let data = await response.json();
                this.setState({ data: data, loading: false });
                return;
            } else {
                alert(response.statusText);
            }
        } while(true);
    }

    render() {
        let pageData = this.state.data.slice(this.state.offset, this.state.offset + PagedTable.ROWS_PER_PAGE);
        return this.state.loading ? (<p><em>Loading...</em></p>) :
            (
                <div>
                    <Table rows={pageData} onEdit={this.onEditRow} onDelete={this.onDeleteRow} />
                    <div className='items-in-a-row'>
                        <Pagination ref={this.paginatorRef} totalItems={this.state.data.length} pageSize={PagedTable.ROWS_PER_PAGE} onPageChanged={this.onPageChanged} />
                        <button type='button' className='btn btn-primary' onClick={this.onAddRow}>Добавить</button>
                    </div>
                    {this.state.editingRow === undefined || <EditForm title='Редактирование записи' data={this.state.editingRow} onResult={this.onEditResult} />}
                    {this.state.addingRow === undefined || <EditForm title='Добавление записи' data={this.state.addingRow} onResult={this.onAddResult} />}
                    {this.state.deletingRow === undefined || <DeleteForm data={this.state.deletingRow} onResult={this.onDeleteResult} />}
                </div>
            );
    }

    onPageChanged(offset) {
        // Тут мы можем оказаться в процессе других установок стейта так что простой setState не сработает
        this.setState(prevState => { return { ...prevState, offset: offset }; });
    }

    onAddRow() {
        this.setState({ ...this.state, addingRow: {} });
    }

    onAddResult(row) {
        if (row) {
            let newItems = [...this.state.data, row];
            this.setState({ ...this.state, data: newItems, addingRow: undefined });
            this.paginatorRef.current.ensureItemVisible(newItems.length - 1);
            this.delayedAlert("Запись добавлена");
            return;
        }
        this.setState({ ...this.state, addingRow: undefined });
    }

    onEditRow(row) {
        let index = this.state.data.indexOf(row);
        if (index >= 0) {
            this.setState({ ...this.state, editingRow: this.state.data[index] });
        }
    }

    onEditResult(row) {
        if (row) {
            let index = this.state.data.indexOf(this.state.editingRow);
            if (index >= 0) {
                let updatedData = [...this.state.data];
                updatedData[index] = row;
                this.setState({ ...this.state, data: updatedData, editingRow: undefined });
                this.delayedAlert("Запись обновлена");
                return;
            }
        }
        this.setState({ ...this.state, editingRow: undefined });
    }

    onDeleteRow(row) {
        let index = this.state.data.indexOf(row);
        if (index >= 0) {
            this.setState({ ...this.state, deletingRow: this.state.data[index] });
        }
    }

    onDeleteResult(row) {
        if (row) {
            let index = this.state.data.indexOf(this.state.deletingRow);
            if (index >= 0) {
                let updatedData = [...this.state.data];
                updatedData.splice(index, 1);
                this.setState({ ...this.state, data: updatedData, deletingRow: undefined });
                this.delayedAlert("Запись удалена");
                return;
            }
        }
        this.setState({ ...this.state, deletingRow: undefined });
    }

    delayedAlert(text) {
        setTimeout((txt) => alert(txt), 50, text);
    }

}
