import React from 'react';
import { Component } from 'react';
import '../../styles/common/FormTextFieldStyle.css';

export class FormTextField extends Component{
    constructor(props) {
        super(props);
        this.props = props;
    }

    render(){
        return(
            <div className="form-input-text">
                <label className={"form-input-label form-input-label-" + this.props.labelPos} htmlFor={this.props.inpId}>
                    {this.props.labelText}
                </label>
                <input className="form-input" type={this.props.type} id={this.props.inpId} style={{width: this.props.inpW + '%'}}/>
            </div>
        )
    }
}