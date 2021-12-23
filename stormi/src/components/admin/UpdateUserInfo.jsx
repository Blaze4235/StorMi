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
            'userId': document.querySelector('#login').value,
            'name': document.querySelector('#Uname').value,
            'Email': document.querySelector('#UserEmail').value,
        };

        fetch('https://localhost:44344/edit', {
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
                    <h2>Update User Info
                    <button className="btnAdminBack3" onClick={this.goBack}>Back</button></h2>
                </div>
                <form className="createAccAdminForm">
                    <label>
                        User id:
                        <input type="email" id="login" className="updateUser1" />
                    </label>
                    <label>
                        Name:
                        <input type="text" id="Uname" className="updateUser2" />
                    </label>
                    <label>
                        Email:
                        <input type="text" id="UserEmail" className="updateUser3"/>
                    </label>
                </form>
                <button className="btnCreateAcc" onClick={this.update}>Update</button>
            </div>
        )
    }
}