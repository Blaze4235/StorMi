import React from 'react';
import { Component } from 'react';

import {ButtonCustom} from '../common/ButtonCustom';
import '../../styles/user/UserCabinetStyle.css';

export class AdminCabinet extends Component{
    constructor(props) {
        super(props);
        this.props = props;
    }
    // componentDidMount(){
    //     document.querySelector('#CabName').textContent = window.localStorage.getItem('Uname');
    //     document.querySelector('#CabEmail').textContent = window.localStorage.getItem('Umail');
    //     document.querySelector('#CabPhone').textContent = window.localStorage.getItem('Uphone');
    // }
    render(){
        return(
            <div className="ticket ticket--cabinet">
                <div>
                    <h2 id="userName" className="cabinet-info__title user-name">Menu</h2>
                </div>
                <div className="cabinet-info">
                    <div className="cabinet-info__block">
                </div>
                <div className="cabinet-info__btn-group">
                    <ButtonCustom text="Update users account" type="primary"></ButtonCustom>
                    <ButtonCustom text="Delete users account" type="primary"></ButtonCustom>
                    <ButtonCustom text="Create account to user" type="primary"></ButtonCustom>
                    <ButtonCustom text="Check info about users accounts" type="primary"></ButtonCustom>
                    <ButtonCustom text="Recover password to user" type="primary"></ButtonCustom>
                </div>
            </div>
            </div>
        )
    }
}