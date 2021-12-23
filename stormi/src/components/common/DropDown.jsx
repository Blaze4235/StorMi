import React from 'react';
import { Component } from 'react';
import '../../styles/common/DropDownStyle.css';

export class DropDown extends Component {
  constructor(props) {
    super(props);
    this.props = props;
  }

  render() {
    return (
      <select name="cars" id="cars">
        <option value="volvo">Volvo</option>
        <option value="saab">Saab</option>
        <option value="mercedes">Mercedes</option>
        <option value="audi">Audi</option>
      </select>
    );
  }
}
