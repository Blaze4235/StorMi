import React from 'react';
import { Component } from 'react';
import '../../styles/common/ButtonCustomStyle.css';

export class ButtonCustom extends Component{
    constructor(props) {
        super(props);
        this.props = props;

        this.click = this.click.bind(this);
    }
    click(){
        typeof this.props.click === 'function' ? this.props.click() : console.log('No handlers.');
    }
    render(){
        return(
            <button className={"btn btn-" + this.props.type} onClick={this.click}>{this.props.text}</button>
        )
    }
}