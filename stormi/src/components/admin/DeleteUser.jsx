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

    delete = ()=>{
        let data = {
            userEmail: document.querySelector('#login').value
        };

        fetch('https://localhost:44344/delete', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then(resp => {
            this.setState({ back: true });
        });
     }

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