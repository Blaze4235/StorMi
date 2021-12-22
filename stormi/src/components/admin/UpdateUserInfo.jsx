import React from 'react';
import { Component } from 'react';
import { Navigate } from 'react-router-dom';


import '../../styles/admin/UpdateUserInfo.css';

export class UpdateUserInfo extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            back: false,
        }
    }

    update = ()=>{
        let data = {
            'login': document.querySelector('#login').value,
            'Password': document.querySelector('#Password').value,
            'phoneNumber': document.querySelector('#PhoneNumber').value,
            'Email': document.querySelector('#UserEmail').value,
        };

        fetch('https://localhost:44344/register', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        //.then(response => response.json())
        .then(resp => {
            console.log(resp);
            if(resp.status === 200){
                this.setState({ redirect: true });
            }
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
                    <h2>Update User Info
                    <button className="btnAdminBack3" onClick={this.goBack}>Back</button></h2>
                </div>
                <form className="createAccAdminForm">
                    <label>
                        Login:
                        <input type="email" id="login" className="updateUser1" />
                    </label>

                    <label>
                        Password:
                        <input type="password" id="Password" className="updateUser2"/>
                    </label>
                    <label>
                        Phone number:
                        <input type="text" id="PhoneNumber" className="updateUser3"/>
                    </label>
                    <label>
                        Email:
                        <input type="text" id="UserEmail" className="updateUser4"/>
                    </label>
                </form>
                <button className="btnCreateAcc" onClick={this.update}>Update</button>
            </div>
        )
    }
}