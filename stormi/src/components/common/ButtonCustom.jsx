import React from 'react';
import { Component } from 'react';
import '../../styles/common/ButtonCustomStyle.css';

export class ButtonCustom extends Component{
    constructor(props) {
        super(props);
        this.props = props;
    }

    render(){
        return(
            <button className={"btn btn-" + this.props.type}>{this.props.text}</button>
        )
    }
}