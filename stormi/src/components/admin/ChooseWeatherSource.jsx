import React from 'react';
import { Component } from 'react';
import { Navigate } from 'react-router-dom';

import '../../styles/admin/ChooseWeatherSource.css';

export class ChooseWeatherSource extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            back: false,
        }
    }

    // weatherSource = ()=>{
    //     let data = {
        
    //     };

    //     fetch('https://localhost:44344/apis',{
    //     method: 'GET',
    //     credentials: 'same-origin',
    //     headers: {
    //     'Content-Type': 'application/json'
    //     },
    //     })
    //     .then((response) => {
    //         return response.json();
    //     })
    //     .then((data) => {
    //         console.log(data);
    //     });
    //  }

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
                    <h2>Choose Weather Source(API)
                    <button className="btnAdminBack1" onClick={this.goBack}>Back</button>
                    </h2>
                </div>
                <form className="createAccAdminForm">
                    <select className="form-control" >
                        <option value="1" id="firstApi">1</option>
                        <option value="2" id="secondApi">2</option>
                    </select>
                </form>
                <button className="btnCreateAcc" onClick={this.weatherSource}>Confirm</button>
            </div>
        )
    }
}