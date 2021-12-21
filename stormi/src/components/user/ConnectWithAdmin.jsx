import React from 'react';
import { Component } from 'react';
import {FormTextField} from '../common/FormTextField';
import {ButtonCustom} from '../common/ButtonCustom';

import { Link } from 'react-router-dom';
import { Navigate } from 'react-router-dom';

import '../../styles/user/ConnectWithAdmin.css';

export class AdminChat extends Component{
    constructor(props) {
        super(props);
        // this.props = props;
        // this.state = {
        //     redirect: false
        // }

    }
    //12345Qq_
    sendMes = () => {

    }

    render(){
        return(
            <div className="ticket ticket--adminChat">
                <h2 className="admChat-title">Admin Chat</h2>
                <FormTextField inpId="MesToAdmin" inpW="100" type="text" labelText="Your problem:" labelPos="block"></FormTextField>
                <div className="adminChat-btn">
                    <ButtonCustom  text="Send Message" click={this.sendMes} type="primary"></ButtonCustom>
                </div>
            </div>
        )
    }
}