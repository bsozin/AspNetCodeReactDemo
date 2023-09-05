import React, { Component } from 'react';
import PropTypes from 'prop-types';

/* Компонент выбора сущностей идентификатор+имя */
export class SelectNamedId extends Component {
    constructor(props) {
        super(props);
        this.state = {
            options: [], selectedValue: this.props.value };
    }

    async componentDidMount() {
        let response = await fetch(this.props.method);
        let data = await response.json();
        this.setState({ options: data });
    }

    render() {
        return (
            <div className='form-group'>
                <label htmlFor={this.props.name} className='fw-lighter'>{this.props.label}</label>
                <select className='form-control' id={this.props.name} name={this.props.name} value={this.state.selectedValue}
                    onChange={(evt) => this.setState({ selectedValue: evt.target.value })} required>
                    {this.state.options.map(opt => <option key={opt.id} value={opt.id}>{opt.name}</option>)}
                </select>
            </div>
        );
    }
}

SelectNamedId.propTypes = {
    label: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    method: PropTypes.string.isRequired,
    value: PropTypes.number,
};
