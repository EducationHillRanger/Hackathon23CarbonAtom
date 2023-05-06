import React, { Component } from 'react';
import backgroundImage from '../../assets/BackgroundImage.jpg';
import logo from '../../assets/Logo2.png';
import '../../main.css';

export class Main extends Component {
  render() {
    return (
      <div>
        <img class="z-0 h-screen w-screen object-cover object-center absolute" src={backgroundImage} alt='Background'/>
        <div class="flex flex-col justify-center items-center">
          <img class="z-10 mt-44 w-5/12 h-2/6 object-cover" src={logo} alt='Logo'/>
          <div class="z-10 mt-24 text-8xl text-center text-cabbagePoint">
            Shape the Future!
          </div>
          <div class="z-10 text-8xl text-center text-cabbagePoint">
            Lets hit net zero CO2 in 2050
          </div>
          <button class="z-10 w-5/12 mt-16 bg-limeGreen rounded-2xl text-merino h-20 text-6xl ml-4">Lets Get Started</button>
        </div>
      </div>
    );
  }
}