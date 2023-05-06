import React, { Component } from 'react';
import { Navbar } from './components/Navbar';

import './main.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div>
        <Navbar/>
      </div>

    );
  }
}
