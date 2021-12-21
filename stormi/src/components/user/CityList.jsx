import React from 'react';
import { Component } from 'react';
import {FormTextField} from '../common/FormTextField';
import {ButtonCustom} from '../common/ButtonCustom';

import { Link } from 'react-router-dom';
import { Navigate } from 'react-router-dom';

import '../../styles/user/CityList.css';

export class CityList extends Component{
    constructor(props) {
        super(props);
        this.props = props;
        this.state = {
            back: false
        }

    }
    //12345Qq_
    back = () => {
        this.setState({ back: true });
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
                            <option value="volvo">Volvo</option>
                            <option value="saab">Saab</option>
                            <option value="mercedes">Mercedes</option>
                            <option value="audi">Audi</option>
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
                
                <div className="adminChat-btn">
                    
                </div>
            </div>
        )
    }
}