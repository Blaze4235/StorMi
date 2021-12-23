import React from 'react';
import { Component } from 'react';
import { Navigate } from 'react-router-dom';
import { Link } from 'react-router-dom';


import '../../styles/admin/CreateAccAdmin.css';

export class CreateAccAdmin extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            back: false,
        }
    }

    signUp = ()=>{
        let data = {
            'Name': document.querySelector('#Username').value,
            'Email': document.querySelector('#UserEmail').value,
            'phoneNumber': document.querySelector('#PhoneNumber').value,
            'Password': document.querySelector('#Password').value,
            'ConfirmPassword': document.querySelector('#RepPassword').value,
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
                    <h2>Create Account to user
                    <button className="btnAdminBack2" onClick={this.goBack}>Back</button></h2>
                </div>
                <form className="createAccAdminForm">
                    <label>
                        Email:
                        <input type="email" id="UserEmail" className="inputAdmin1" />
                    </label>
                    <label>
                        Phone number:
                        <input type="text" id="PhoneNumber" className="inputAdmin2"/>
                    </label>
                    <label>
                        Username:
                        <input type="text" id="Username" className="inputAdmin3"/>
                    </label>
                    <label>
                        Password:
                        <input type="password" id="Password" className="inputAdmin4"/>
                    </label>
                    <label>
                        Confirm password:
                        <input type="password" id="RepPassword" className="inputAdmin5"/>
                    </label>
                </form>
                <button className="btnCreateAcc" onClick={this.signUp}>Create</button>
            </div>
        )
    }
}