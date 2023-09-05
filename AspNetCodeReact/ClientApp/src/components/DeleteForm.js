import React, { Component } from 'react';
import PropTypes from 'prop-types';

/* Форма подтверждения удаления записи */
export class DeleteForm extends Component {
    constructor(props) {
        super(props);
        this.handleDelete = this.handleDelete.bind(this);
    }

    render() {
        return (
            <div className='modal show' tabIndex='-1' role='dialog' style={{ display: 'block' }}>
                <div className='modal-dialog' role='document'>
                    <div className='modal-content'>
                        <div className='modal-header'>
                            <h5 className='modal-title'>Подтверждение удаления записи</h5>
                        </div>
                        <div className='modal-body'>
                            <form>
                                <div className='form-group row'>
                                    <label htmlFor='name' className='col col-form-label fw-lighter'>Модель</label>
                                    <input type='text' readOnly className='col form-control-plaintext' id='name' value={this.props.data.name} />
                                </div>
                                <div className='form-group row'>
                                    <label htmlFor='brand' className='col col-form-label fw-lighter'>Бренд</label>
                                    <input type='text' readOnly className='col form-control-plaintext' id='brand' value={this.props.data.brand.name} />
                                </div>
                                <div className='form-group row'>
                                    <label htmlFor='bodyType' className='col col-form-label fw-lighter'>Тип кузова</label>
                                    <input type='text' readOnly className='col form-control-plaintext' id='bodyType' value={this.props.data.bodyType.name} />
                                </div>
                                <div className='form-group row'>
                                    <label htmlFor='seatsCount' className='col col-form-label fw-lighter'>Количество мест</label>
                                    <input type='text' readOnly className='col form-control-plaintext' id='seatsCount' value={this.props.data.seatsCount} />
                                </div>
                                <div className='form-group row'>
                                    <label htmlFor='dealerUrl' className='col col-form-label fw-lighter'>Url дилера</label>
                                    <input type='text' readOnly className='col form-control-plaintext' id='dealerUrl' value={this.props.data.dealerUrl ?? undefined} />
                                </div>
                            </form>
                        </div>
                        <div className='modal-footer'>
                            <button type='button' className='btn btn-danger' onClick={this.handleDelete}>Удалить</button>
                            <button type='button' className='btn btn-secondary' onClick={() => this.props.onResult(undefined)} >Отменить</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    async handleDelete() {
        let query = "cars/delete?" + new URLSearchParams({ id: this.props.data.id }).toString();
        let response = await fetch(query, { method: "DELETE" });

        if (response.ok) {
            this.props.onResult(this.props.data);
        } else {
            alert(response.statusText);
        }
    }
}

DeleteForm.propTypes = {
    data: PropTypes.object.isRequired,
    onResult: PropTypes.func.isRequired,
};