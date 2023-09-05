import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { SelectNamedId } from './SelectNamedId';

/* Форма редактирования записи (существующей или новой) */
export class EditForm extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    render() {
        return (
            <div className='modal show' tabIndex='-1' role='dialog' style={{ display: 'block' }}>
                <div className='modal-dialog' role='document'>
                    <div className='modal-content'>
                        <div className='modal-header'>
                            <h5 className='modal-title'>{this.props.title}</h5>
                        </div>
                        <div className='modal-body'>
                            <form id='form1' onSubmit={this.handleSubmit}>
                                <div className='form-group'>
                                    <label htmlFor='name' className='fw-lighter'>Модель</label>
                                    <input type='text' className='form-control' id='name' name='name' defaultValue={this.props.data.name}
                                        required maxLength='1000'
                                    />
                                </div>
                                <SelectNamedId label='Бренд' method='cars/brands' value={this.props.data.brand?.id} name='brand' />
                                <SelectNamedId label='Тип кузова' method='cars/bodytypes' value={this.props.data.bodyType?.id} name='bodyType' />
                                <div className='form-group'>
                                    <label htmlFor='seatsCount' className='fw-lighter'>Количество мест</label>
                                    <input type='number' className='form-control' id='exampleFormControlInput1' name='seatsCount' defaultValue={this.props.data.seatsCount}
                                        required min='1' max='12'
                                    />
                                </div>
                                <div className='form-group'>
                                    <label htmlFor='dealerUrl' className='fw-lighter'>Url дилера</label>
                                    <input type='test' className='form-control' id='dealerUrl' name='dealerUrl' defaultValue={this.props.data.dealerUrl}
                                        pattern='(http:\/\/|https:\/\/)?[\w\-\.]*ru(\/[\w\-\.]*)*'
                                    />
                                </div>
                            </form>
                        </div>
                        <div className='modal-footer'>
                            <button type='submit' form='form1' className='btn btn-primary' >Сохранить</button>
                            <button type='button' className='btn btn-secondary' onClick={() => this.props.onResult(undefined)} >Отменить</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    async handleSubmit(event) {
        event.preventDefault();

        let updateRequest = {
            id: this.props.data.id,
            brandId: event.target.brand.value,
            bodyTypeId: event.target.bodyType.value,
            name: event.target.name.value,
            seatsCount: event.target.seatsCount.value,
            dealerUrl: event.target.dealerUrl.value
        }

        let response = await fetch("cars/update", {
            method: "POST",
            body: JSON.stringify(updateRequest),
            headers: { "Content-type": "application/json; charset=UTF-8" }
        });

        if (response.ok) {
            let responseObject = await response.json();
            this.props.onResult(responseObject);
        } else {
            alert(response.statusText);
        }
    }
}

EditForm.propTypes = {
    title: PropTypes.string.isRequired,
    data: PropTypes.object.isRequired,
    onResult: PropTypes.func.isRequired,
};
