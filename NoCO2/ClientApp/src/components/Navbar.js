import React from 'react';
import { Link, useLocation } from 'react-router-dom';
import '.././main.css';

function Navbar() {
  const location = useLocation();
  console.log(location.pathname);

  return (
    <header class="z-10 w-screen p-3 bg-cabbagePoint fixed">
      <div class="flex md:flex-grow h-12">
        <div class="ml-auto">
          <Link to="/signup">
            <button class="bg-cloudy h-11 rounded-xl text-merino w-32 text-2xl">Sign Up</button>
          </Link>
          <button class="bg-cloudy h-11 rounded-xl text-merino w-32 text-2xl ml-4">Login</button>
        </div>
      </div>
    </header>
  );
}

export default Navbar;