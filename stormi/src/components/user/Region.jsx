import React from 'react';
import { Component } from 'react';

import { Link } from 'react-router-dom';

import '../../styles/user/RegionStyle.css';

export class Region extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            inf: 0,
            died: 0,
            active: 0
        }
        
    }
    //12345Qq_
    componentDidMount(){
        this.covid();
    }
    covid = () => {
        fetch('https://localhost:44344/weather/covid', {
            method: 'GET',
            credentials: 'same-origin',
            headers: {
              'Content-Type': 'application/json'
            },
        })
        .then(response => {
            return response.json();
        })
        .then(data => {
            console.log(data)
            this.setState({ inf: data.confirmed });
            this.setState({ died: data.deaths });
            this.setState({ active: data.active });
        });
    }

    render(){
        return(
            <div className="ticket ticket--region">
                <div className="region-back"><Link to="/cabinet">Back to cabinet</Link></div>
                <h1>COVID Information in Ukraine</h1>
                <div>
                    <ul className="region-list">
                        <li>Infected: <span className="region-nums">{this.state.inf}</span></li>
                        <li>Died: <span className="region-nums">{this.state.died}</span></li>
                        <li>Active: <span className="region-nums">{this.state.active}</span></li>
                    </ul>
                </div>
            </div>
        )
    }
}