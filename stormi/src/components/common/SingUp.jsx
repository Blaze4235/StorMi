import React from 'react';
import { Component } from 'react';
import {FormTextField} from './FormTextField';
import {ButtonCustom} from './ButtonCustom';

import { Link } from 'react-router-dom';
import { Navigate } from 'react-router-dom';

//import '../../styles/common/SingInStyle.css';
import '../../styles/common/SingUpStyle.css';

export class SingUp extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            redirect: false
        }

        //this.singUp = this.singUp.bind(this);
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
    //12345Qq_
    render(){
        const { redirect } = this.state;
        if (redirect) {
            return <Navigate to="/sign-in"/>;
        }
        return(
            <div className="ticket ticket--sign-up">
                <h1 className="logo-name">
                    <span className="logo-name--s">Stor</span>
                    <span className="logo-name--e">Mi</span>
                </h1>
                <div className="ticket__form">
                    <div className="form-fields">
                      <FormTextField inpId="UserEmail" inpW="100" type="email" labelText="Email:" labelPos="block"></FormTextField>
                      <FormTextField inpId="PhoneNumber" inpW="100" type="text" labelText="Phone number:" labelPos="block"></FormTextField>
                      <FormTextField inpId="Username" inpW="100" type="text" labelText="Username:" labelPos="block"></FormTextField>
                      <FormTextField inpId="Password" inpW="100" type="password" labelText="Password:" labelPos="block"></FormTextField>
                      <FormTextField inpId="RepPassword" inpW="100" type="password" labelText="Confirm password:" labelPos="block"></FormTextField>
                    </div>
                    <ButtonCustom text="SIGN UP" type="primary" click={this.signUp}></ButtonCustom>
                    <div className="ticket__form--sub ticket__form--sub-end signIn-sub--end">
                        <span className="signIn-sub-spanP">
                            Have an account?
                        </span>
                        <Link to="/sign-in">Log in</Link>
                    </div>
                </div>
            </div>
        )
    }
}