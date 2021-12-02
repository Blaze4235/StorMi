import React from 'react';
import { Component } from 'react';
import {FormTextField} from './FormTextField';
import {ButtonCustom} from './ButtonCustom';

import { Link } from 'react-router-dom';

import '../../styles/common/SingInStyle.css';

export class SingIn extends Component{
    constructor(props) {
        super(props);
        this.props = props;
    }

    render(){
        return(
            <div className="ticket ticket--sign-in">
                <h1 className="logo-name">
                    <span className="logo-name--s">Stor</span>
                    <span className="logo-name--e">Mi</span>
                </h1>
                <div className="ticket__form">
                    <FormTextField inpId="Username" inpW="100" labelText="Username" labelPos="block"></FormTextField>
                    <FormTextField inpId="Password" inpW="100" labelText="Password" labelPos="block"></FormTextField>
                    <div className="ticket__form--sub signIn-sub">
                        <span>
                            <input type="checkbox" name="RememberMe" id="RememberMe" />
                            <label for="RememberMe">Remember Me</label>
                        </span>
                        <Link to="/recover-password">Forgot Login Details?</Link>
                    </div>
                    <ButtonCustom text="SIGN IN" type="primary"></ButtonCustom>
                    <div className="ticket__form--sub ticket__form--sub-end signIn-sub--end">
                        <span className="signIn-sub-spanP">
                            Dont't have an account?
                        </span>
                        <Link to="/sing-up">Forgot Login Details?</Link>
                    </div>
                </div>
            </div>
        )
    }
}