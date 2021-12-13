import React from 'react';
import { Component } from 'react';
// import { Link } from 'react-router-dom'

import '../../styles/admin/AdminCabinetStyle.css';

export class AdminCabinet extends Component{
    constructor(props) {
        super(props);
        this.props = props;
    }
    render(){
        return(
            <div className="ticket ticket--cabinet">
                <div>
                    <h2 id="userName" className="cabinet-info__title user-name">Menu
                    <button className="btnAdminLogOut">Log out</button></h2>
                </div>
                <div className="cabinet-info">
                    <div className="cabinet-info__block">
                </div>
                <div className="cabinet-info__btn-group">
                    <button className="btnAdmin">Update users account</button>
                    <button className="btnAdmin">Delete users account</button>
                    <button className="btnAdmin">Create account to user</button>
                    <button className="btnAdmin">Check info about users accounts</button>
                    <button className="btnAdmin">Recover password to user</button>
                    <button className="btnAdmin">Check recent users</button>
                    <button className="btnAdmin">Choose weather source</button>
                </div>
            </div>
            </div>
        )
    }
}