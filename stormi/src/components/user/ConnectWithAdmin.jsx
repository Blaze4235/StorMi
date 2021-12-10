import React from 'react';
import { Component } from 'react';
import {FormTextField} from '../common/FormTextField';
import {ButtonCustom} from '../common/ButtonCustom';

import { Link } from 'react-router-dom';
import { Navigate } from 'react-router-dom';

import '../../styles/common/SingInStyle.css';

export class AdminChat extends Component{
    constructor(props) {
        super(props);
        // this.props = props;
        // this.state = {
        //     redirect: false
        // }

    }
    //12345Qq_
    signIn = () => {

    }

    render(){
        return(
            <div>
                <div className="adminChat-back"></div>
                <div className="ticket ticket--adminChat">

                </div>
            </div>
        )
    }
}