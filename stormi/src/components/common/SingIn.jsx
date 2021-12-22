import React from 'react';
import { Component } from 'react';
import {FormTextField} from './FormTextField';
import {ButtonCustom} from './ButtonCustom';

import { Link } from 'react-router-dom';
import { Navigate } from 'react-router-dom';

import '../../styles/common/SingInStyle.css';

export class SingIn extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            redirect: false
        }

    }
    //12345Qq_
    signIn = () => {
        let data = {
            'email': document.querySelector('#UserEmail').value,
            'password': document.querySelector('#Password').value,
            'rememberMe': document.querySelector('#RememberMe').checked,
            'returnUrl': '',
        };

        fetch('https://localhost:44344/login', {
            method: 'POST',
            credentials: 'same-origin',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        //.then(response => response.json())
        .then(response => {
            console.log(response.cookie)
            if(response.status === 200){
                response.json()
                .then(user => {
                    console.log(user);
                    window.localStorage.setItem('Uname', user.userName);
                    window.localStorage.setItem('Umail', user.email);
                    window.localStorage.setItem('Uphone', user.phoneNumber);
                    this.setState({ redirect: true });
                });     
            }
        });
        /*fetch('https://localhost:44344/api/cities',{
        method: 'GET',
        credentials: 'same-origin',
        headers: {
        'Content-Type': 'application/json'
        },
        })
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            console.log(data);
        });*/
    }

    render(){
        const { redirect } = this.state;
        if (redirect) {
            return <Navigate to="/cabinet"/>;
        }
        return(
            <div className="ticket ticket--sign-in">
                <h1 className="logo-name">
                    <span className="logo-name--s">Stor</span>
                    <span className="logo-name--e">Mi</span>
                </h1>
                <div className="ticket__form">
                    <FormTextField inpId="UserEmail" inpW="100" type="email" labelText="Email:" labelPos="block"></FormTextField>
                    <FormTextField inpId="Password" inpW="100" type="password" labelText="Password:" labelPos="block"></FormTextField>
                    <div className="ticket__form--sub signIn-sub">
                        <span>
                            <input type="checkbox" name="RememberMe" id="RememberMe" />
                            <label htmlFor="RememberMe">Remember Me</label>
                        </span>
                        <Link to="/recover-password">Forgot Login Details?</Link>
                    </div>
                    <ButtonCustom text="SIGN IN" click={this.signIn} type="primary"></ButtonCustom>
                    <div className="ticket__form--sub ticket__form--sub-end signIn-sub--end">
                        <span className="signIn-sub-spanP">
                            Don't have an account?
                        </span>
                        <Link to="/sign-up">Sign Up</Link>
                    </div>
                </div>
            </div>
        )
    }
}