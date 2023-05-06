import React, { Component, useState } from 'react';
import { Link } from 'react-router-dom';
import backgroundImage from '../../assets/BackgroundImage.jpg';
import '../../main.css';

export class SignUp extends Component {
  render() {
    return (
      <div>
        <img class="z-0 h-screen w-screen object-cover object-center absolute" src={backgroundImage} alt='Background'/>
        <div class="h-screen w-screen flex justify-center items-center">
          <div class="z-10 bg-cloudy/90 w-2/5 h-3/4 rounded-2xl p-4 flex items-center justify-center">
            <div class="z-10 bg-white w-full h-full rounded-2xl p-8">
              <div class="text-3xl font-bold pb-4">Sign Up</div>
              <div>
                <form class="flex flex-col">
                  <label>
                    <div class="text-2xl mb-1">Email</div>
                    <input
                      class="border border-black h-20 w-full rounded-2xl text-5xl"
                      name="email"
                      type='text'
                    />
                  </label>
                  <label class="mt-4">
                    <div class="text-2xl mb-1">Password</div>
                    <input
                      class="border border-black h-20 w-full rounded-2xl text-5xl"
                      name="password"
                      type='password'
                    />
                  </label>
                  <button
                    class="mt-4 h-20 w-full rounded-2xl bg-matrix text-merino text-3xl font-bold"
                    type="submit"
                  >
                    SIGN UP
                  </button>
                </form>
                <hr class="z-10 w-full mt-4 border-black" />
                <div class="text-2xl mb-1">
                  Already have an account: <Link to="/">Login</Link>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>
    );
  }
}