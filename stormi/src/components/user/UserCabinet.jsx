import React from 'react';
import { Component } from 'react';

import {ButtonCustom} from '../common/ButtonCustom';
import {AdminChat} from '../user/ConnectWithAdmin';
import { Navigate } from 'react-router-dom';
import '../../styles/user/UserCabinetStyle.css';

export class UserCabinet extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            redirect: false,
            adminChat: false,
            CityList: false,
            region: false
        }
    }

    componentDidMount(){
        document.querySelector('#CabName').textContent = window.localStorage.getItem('Uname');
        document.querySelector('#CabEmail').textContent = window.localStorage.getItem('Umail');
        document.querySelector('#CabPhone').textContent = window.localStorage.getItem('Uphone');
    }

    logOut = () =>{
        this.setState({ redirect: true });
    }

    startAdminChat = ()=>{
        this.setState({ adminChat: true });
    }
    cityList = () => {
        this.setState({ CityList: true });
    }
    regionInfo = () => {
        this.setState({ region: true });
    }
    render(){
        const { redirect, adminChat, CityList, region } = this.state;
        if (redirect) {
            return <Navigate to="/sign-in"/>;
        }
        if (adminChat) {
            return <Navigate to="/connectWithAdmin"/>;
        }
        if (CityList) {
            return <Navigate to="/CityList"/>;
        }
        if (region) {
            return <Navigate to="/region"/>;
        }
        return(
            <div className="ticket ticket--cab">
                
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
                            <p id="CabPhone" className="cabinet-info__text">+1234567890</p>
                        </div>
                    </div>
                    <div className="cabinet__log-out">
                        <ButtonCustom text="Log out" click={this.logOut} type="primary"></ButtonCustom>
                    </div>
                </div>
                <div className="cabinet-info__btn-group">
                    <ButtonCustom text="City List" click={this.cityList} type="primary"></ButtonCustom>
                    <ButtonCustom text="Connect with Admin" click={this.startAdminChat} type="primary"></ButtonCustom>
                    <ButtonCustom text="View info about region" click={this.regionInfo} type="primary"></ButtonCustom>
                </div>
            </div>
        )
    }
}