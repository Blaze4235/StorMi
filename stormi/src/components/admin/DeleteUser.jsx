import React from 'react';
import { Component } from 'react';
import { Navigate } from 'react-router-dom';

import '../../styles/admin/DeleteUser.css';

export class DeleteUser extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            back: false,
        }
    }

    // weatherSource = ()=>{
    //     let data = {
        
    //     };

    //     fetch('https://localhost:44344/apis',{
    //     method: 'GET',
    //     credentials: 'same-origin',
    //     headers: {
    //     'Content-Type': 'application/json'
    //     },
    //     })
    //     .then((response) => {
    //         return response.json();
    //     })
    //     .then((data) => {
    //         console.log(data);
    //     });
    //  }

    goBack = () => {
        this.setState({back: true });
    }

    render(){
        const {back} = this.state;
        if(back){
            return <Navigate to="/cabinetAdmin"></Navigate>;
        }
        return(
            <div className="ticket ticket--cabinet">
            <div>
                <h2>Delete User
                <button className="btnAdminBack" onClick={this.goBack}>Back</button></h2>
            </div>
            <form className="createAccAdminForm">
                <label>
                    User Login:
                    <input type="text" id="login" className="inputAdmin" />
                </label>
            </form>
            <button className="btnDeleteAcc" onClick={this.delete}>Delete</button>
        </div>
        )
    }
}