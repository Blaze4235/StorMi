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

    render(){
        return(
            <div className="ticket ticket--sign-up">
                <h1 className="logo-name">
                    <span className="logo-name--s">Stor</span>
                    <span className="logo-name--e">Mi</span>
                </h1>
                <div className="ticket__form">
                    <div className="form-fields">
                      <FormTextField inpId="UserEmail" inpW="100" labelText="Email" labelPos="block"></FormTextField>
                      <FormTextField inpId="PhoneNumber" inpW="100" labelText="Phone number" labelPos="block"></FormTextField>
                      <FormTextField inpId="Username" inpW="100" labelText="Username" labelPos="block"></FormTextField>
                      <FormTextField inpId="Password" inpW="100" labelText="Password" labelPos="block"></FormTextField>
                    </div>
                    <ButtonCustom text="SIGN IN" type="primary"></ButtonCustom>
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