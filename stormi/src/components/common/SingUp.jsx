import React from 'react';
import { Component } from 'react';
import {FormTextField} from './FormTextField';
import {ButtonCustom} from './ButtonCustom';

import { Link } from 'react-router-dom';

//import '../../styles/common/SingInStyle.css';
import '../../styles/common/SingUpStyle.css';

export class SingUp extends Component{
    constructor(props) {
        super(props);
        this.props = props;
    }

    signUp(){
        let data = {
            'Name': document.querySelector('#Username').value,
            'Email': document.querySelector('#UserEmail').value,
            //Name: document.querySelector('#UserEmail').value,
            'Password': document.querySelector('#Password').value,
            'ConfirmPassword': document.querySelector('#RepPassword').value,
        };

        fetch('https://localhost:44344/register', {
            method: 'POST',
            //mode: 'no-cors', // no-cors, *cors, same-origin
            // cache: 'no-cache', 
            // credentials: 'same-origin',
            headers: {
              'Content-Type': 'application/json'
              // 'Content-Type': 'application/x-www-form-urlencoded',
            },
            body: JSON.stringify(data)
        })
        .then(response => response.json())
        .then(resp => {
            console.log(resp);//JSON.parse()
            console.log(data);
        });
    }
    //12345Qq_
    render(){
        return(
            <div className="ticket ticket--sign-up">
                <h1 className="logo-name">
                    <span className="logo-name--s">Stor</span>
                    <span className="logo-name--e">Mi</span>
                </h1>
                <div className="ticket__form">
                    <div className="form-fields">
                      <FormTextField inpId="UserEmail" inpW="100" labelText="Email:" labelPos="block"></FormTextField>
                      <FormTextField inpId="PhoneNumber" inpW="100" labelText="Phone number:" labelPos="block"></FormTextField>
                      <FormTextField inpId="Username" inpW="100" labelText="Username:" labelPos="block"></FormTextField>
                      <FormTextField inpId="Password" inpW="100" labelText="Password:" labelPos="block"></FormTextField>
                      <FormTextField inpId="RepPassword" inpW="100" labelText="Repeat password:" labelPos="block"></FormTextField>
                    </div>
                    <ButtonCustom text="SIGN UP" type="primary" click={this.signUp}></ButtonCustom>
                    <div className="ticket__form--sub ticket__form--sub-end signIn-sub--end">
                        <span className="signIn-sub-spanP">
                            Have an account?
                        </span>
                        <Link to="/sing-in">Log in</Link>
                    </div>
                </div>
            </div>
        )
    }
}