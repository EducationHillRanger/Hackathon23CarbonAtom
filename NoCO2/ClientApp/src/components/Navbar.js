import React, { Component } from 'react';
import '.././main.css';

export class Navbar extends Component {
  render() {
    return (
      <header class="w-screen p-3 bg-cabbagePoint fixed">
        <div class="flex md:flex-grow h-12">
          <div class="ml-auto">
            <button class="bg-cloudy h-11 rounded-md text-merino w-32 text-2xl">Sign Up</button>
            <button class="bg-cloudy h-11 rounded-md text-merino w-32 text-2xl ml-4">Login</button>
          </div>
        </div>
      </header>
    );
  }
}