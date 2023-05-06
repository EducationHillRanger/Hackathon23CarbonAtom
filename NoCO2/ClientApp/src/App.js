import React, { Component } from 'react';
import { Navbar } from './components/Navbar';
import { Main } from './components/Introduction/Main';

import './main.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div>
        <Navbar/>
        <Main/>
      </div>

    );
  }
}
