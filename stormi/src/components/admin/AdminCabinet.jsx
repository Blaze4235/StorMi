import React from 'react';
import { Component } from 'react';
import { Navigate } from 'react-router-dom';

import '../../styles/admin/AdminCabinetStyle.css';

export class AdminCabinet extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            create: false,
            logout: false,
            weather:false,
            deleteuser:false
        }

    }
    logOut=()=>{
        this.setState({logout: true });
    }
    createAcc = () => {
        this.setState({create: true });
    }
    chooseWather=()=>{
        this.setState({weather: true });
    }
    deleteUser=()=>{
        this.setState({deleteuser: true });
    }
    render(){
        const {create, logout, weather, deleteuser} = this.state;
        if(create){
            return <Navigate to="/createAccAdmin"></Navigate>;
        }
        else if(logout){
            return <Navigate to="/sign-in"></Navigate>;
        } else if(weather){
            return <Navigate to="/weather"></Navigate>;
        } else if(deleteuser){
            return <Navigate to="/deleteUser"></Navigate>;
        }
        return(
            <div className="ticket ticket--cabinet">
                <div>
                    <h2 id="userName" className="cabinet-info__title user-name">Menu
                    <button className="btnAdminLogOut" onClick={this.logOut}>Log out</button></h2>
                </div>
                <div className="cabinet-info">
                    <div className="cabinet-info__block">
                </div>
                <div className="cabinet-info__btn-group">
                    <button className="btnAdmin">Update users account</button>
                    <button className="btnAdmin" onClick={this.deleteUser}>Delete users account</button>
                    <button className="btnAdmin" onClick={this.createAcc}>Create account to user</button>
                    <button className="btnAdmin">Check info about users accounts</button>
                    <button className="btnAdmin">Recover password to user</button>
                    <button className="btnAdmin">Check recent users</button>
                    <button className="btnAdmin" onClick={this.chooseWather}>Choose weather source</button>
                </div>
            </div>
            </div>
        )
    }
}
