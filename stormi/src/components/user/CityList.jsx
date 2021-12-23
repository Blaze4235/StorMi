import React from 'react';
import { Component } from 'react';
import {FormTextField} from '../common/FormTextField';
import {ButtonCustom} from '../common/ButtonCustom';

import { Link } from 'react-router-dom';
import { Navigate } from 'react-router-dom';

import snow from '../../assets/snow.png';
import rain from '../../assets/rain.png';
import cloudy from '../../assets/cloudy.png';

import '../../styles/user/CityList.css';

export class CityList extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            back: false,
            city: 'Dnipro',
            listItems: '',
            cities: "",
            userCities: []
        }
        this.listItems = "";
    }
    componentDidMount(){
        this.getCities();
        this.getUserCities();
    }
    //12345Qq_
    back = () => {
        this.setState({ back: true });
    }

    getWether = async (city)=>{
        let res = await fetch(`https://localhost:44344/weather/week?city=${city!== undefined ?city : this.state.city}`,{
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
                let srcIc = /snow/g.test(city.overallCondition)? snow: 
                    /rain/g.test(city.overallCondition)? rain : cloudy;

                    return <li key={index}>
                        <div className="wether-icon">
                            <img className="wether-ic" src={srcIc} alt="icon" />
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

    getUserCities = async () =>{
        let res = await fetch(`https://localhost:44344/api/cities/userCities?userId=${window.localStorage.getItem('Uid')}`,{
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
    }

    addCity = async ()=>{
        // let res = await fetch('https://localhost:44344/api/cities/newUser', {
        //     method: 'POST',
        //     headers: {
        //       'Content-Type': 'application/json'
        //     },
        //     body: JSON.stringify({
        //         'cityName': document.querySelector('select').value,
        //         'userId': window.localStorage.getItem('Uid')
        //     })
        // })
        // .then(response => {
        //     return response.json()
        // });
        if(!this.state.userCities.find(el => el === document.querySelector('select').value)){
            this.setState({userCities: [...this.state.userCities, document.querySelector('select').value]});
        }
    }

    deleteCity = () => {
        let index = this.state.userCities.indexOf(document.querySelector('select').value);
        this.goNext();
        this.state.userCities.splice(index, 1);
    }

    goNext = () => {
        //debugger
        if(this.state.userCities.length == 1){
            return;
        }
        let index = this.state.userCities.indexOf(document.querySelector('.curCity').textContent);
        if(index == this.state.userCities.length - 1){
            index = 0;
            document.querySelector('.curCity').textContent = 
            this.state.userCities[index];
            this.getWether(this.state.userCities[index]);
            return;
        }
        document.querySelector('.curCity').textContent = 
        this.state.userCities[index+1];
        this.getWether(this.state.userCities[index+1]);
    }

    goBack = () => {
        //debugger
        if(this.state.userCities.length == 1){
            return;
        }
        let index = this.state.userCities.indexOf(document.querySelector('.curCity').textContent);
        if(index == 0){
            index = this.state.userCities.length - 1;
            document.querySelector('.curCity').textContent = 
            this.state.userCities[index];
            this.getWether(this.state.userCities[index]);
            return;
        }
        document.querySelector('.curCity').textContent = 
        this.state.userCities[index-1];
        this.getWether(this.state.userCities[index-1]);
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
                        <button className="carousel-btn carousel-btn--left" onClick={this.goNext}></button>
                        <h3 className="curCity">{this.state.userCities.length == 0 ? 'Dnipro': this.state.userCities[0]}</h3>
                        <button className="carousel-btn carousel-btn--right" onClick={this.goBack}></button>
                    </div>
                    <div className="city-list-back">
                        <ButtonCustom  text="Back to cabinet" click={this.back} type="primary"></ButtonCustom>
                    </div>
                </div>
                <div className="city-list_btns">
                    <ButtonCustom  text="Add" click={this.addCity} type="primary"></ButtonCustom>
                    <ButtonCustom  text="Delete" click={this.deleteCity} type="primary"></ButtonCustom>
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