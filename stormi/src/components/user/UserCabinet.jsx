import React from 'react';
import { Component } from 'react';

import {ButtonCustom} from '../common/ButtonCustom';
import '../../styles/user/UserCabinetStyle.css';

export class UserCabinet extends Component{
    constructor(props) {
        super(props);
        this.props = props;
    }
    componentDidMount(){
        document.querySelector('#CabName').textContent = window.localStorage.getItem('Uname');
        document.querySelector('#CabEmail').textContent = window.localStorage.getItem('Umail');
    }
    render(){
        return(
            <div className="ticket ticket--cabinet">
                <div className="cabinet-info">
                    <div className="cabinet-info__block">
                        <div>
                            <h2 id="userName" className="cabinet-info__title user-name">User name</h2>
                            <p id="CabName" className="cabinet-info__text">UserNameExample</p>
                        </div>
                        <div>
                            <h2 id="userEmail" className="cabinet-info__title user-email">Email</h2>
                            <p id="CabEmail" className="cabinet-info__text">UserNameExample@pidory.gdeBack?</p>
                        </div>
                        <div>
                            <h2 id="userName" className="cabinet-info__title user-name">Phone number</h2>
                            <p className="cabinet-info__text">+1234567890</p>
                        </div>
                    </div>
                    <div className="cabinet__log-out">
                        <ButtonCustom text="Log out" type="primary"></ButtonCustom>
                    </div>
                </div>
                <div className="cabinet-info__btn-group">
                    <ButtonCustom text="City List" type="primary"></ButtonCustom>
                    <ButtonCustom text="Connect with Admin" type="primary"></ButtonCustom>
                    <ButtonCustom text="View info about region" type="primary"></ButtonCustom>
                </div>
            </div>
        )
    }
}