import React from 'react';
import { Component } from 'react';

import '../../styles/admin/CreateAccAdmin.css';

export class CreateAccAdmin extends Component{
    constructor(props) {
        super(props);
        this.props = props;
    }
    render(){
        return(
            <div className="ticket ticket--cabinet">
                <div>
                    <h2>Create Account to user
                    <button className="btnAdminBack">Back</button></h2>
                </div>
                <form className="createAccAdminForm">
                    <label>
                        Login:
                        <input type="text" />
                    </label>
                    <label>
                        Password:
                        <input type="password" />
                    </label>
                    <label>
                        Email:
                        <input type="email" />
                    </label>
                </form>
                <button className="btnAdminBack">Create</button>
            </div>
        )
    }
}