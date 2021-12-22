import React from 'react';
import { Component } from 'react';
import {FormTextField} from '../common/FormTextField';
import {ButtonCustom} from '../common/ButtonCustom';

import { Link } from 'react-router-dom';
import { Navigate } from 'react-router-dom';

import snow from '../../assets/snow.png';

import '../../styles/user/CityList.css';

export class CityList extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            back: false,
            city: 'Dnipro',
            listItems: '',
            cities: ""
        }
        this.listItems = "";
    }
    componentDidMount(){
        this.getCities();
    }
    //12345Qq_
    back = () => {
        this.setState({ back: true });
    }

    getWether = async ()=>{
        let res = await fetch(`https://localhost:44344/weather/week?city=${this.state.city}`,{
            method: 'GET',
            credentials: 'same-origin',
            headers: {
            'Content-Type': 'application/json'
            },
            })
            .then((response) => {
                return response.json();
            });

            console.log(res);
            let lis = res.map((city, index) =>{
                let srcIc = city.overallCondition === ""
                    return <li key={index}>
                        <div className="wether-icon">
                            <img className="wether-ic" src={snow} alt="icon" />
                        </div>
                        <div className="wether-text">
                            Avg temperature: <strong>{city.avgTemp}</strong>
                        </div>
                        <div className="wether-text">
                            Chance of rain: <strong>{city.chanceOfRain}</strong>%
                        </div>
                        <div className="wether-text">
                            Chance of snow: <strong>{city.chanceOfSnow}</strong>%
                        </div>
                        <div className="wether-text">
                            Min temperature: <strong>{city.temperatureMin}</strong>
                        </div>
                        <div className="wether-text">
                            Max temperature: <strong>{city.temperatureMax}</strong>
                        </div>
                        <div className="wether-text">
                            Wind speed: <strong>{city.windSpeed}</strong>
                        </div>
                        <div className="wether-text">
                            Avg humidity: <strong>{city.avgHumidity}</strong>%
                        </div>
                    </li>
                }        
            );
            this.setState({ listItems: lis });
    }

    getCities = async ()=>{
            let res = await fetch(`https://localhost:44344/api/cities`,{
                method: 'GET',
                credentials: 'same-origin',
                headers: {
                'Content-Type': 'application/json'
                },
                })
                .then((response) => {
                    return response.json();
                });
    
                console.log(res);
                let options = res.map((city) =>{
                        return <option value={city.name}>{city.name}</option>
                    }        
                );
                this.setState({ cities: options });
                this.getWether();
        
    }

    render(){
        const {back} = this.state;
        if(back){
            return <Navigate to="/cabinet"></Navigate>;
        }
        return(
            <div className="ticket ticket--cityList">
                <div className="city-list-fields">
                    <div>
                        <label htmlFor="cities">Add city to list</label>
                        <select className="city-list_select" name="cities" id="cities">
                            {this.state.cities}
                        </select>
                    </div>
                    <div className="carousel">
                        <button className="carousel-btn carousel-btn--left"></button>
                        <h3 className="curCity"></h3>
                        <button className="carousel-btn carousel-btn--right"></button>
                    </div>
                    <div className="city-list-back">
                        <ButtonCustom  text="Back to cabinet" click={this.back} type="primary"></ButtonCustom>
                    </div>
                </div>
                <div className="city-list_btns">
                    <ButtonCustom  text="Add" click={this.sendMes} type="primary"></ButtonCustom>
                    <ButtonCustom  text="Delete" click={this.sendMes} type="primary"></ButtonCustom>
                </div>
                
                <div className="weather">
                    <ul className="weather-list">
                        {this.state.listItems}
                    </ul>
                </div>
            </div>
        )
    }
}