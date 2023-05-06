import { useState } from "react";
import { Link } from "react-router-dom";

function LoginPannel() {
  const [loginInput, setLoginInput] = useState({
    email: "",
    password: ""
  });

  const onSubmitForm = e => {
    e.preventDefault();
    alert(JSON.stringify(loginInput, null, 2));
  }

  const onFormUpdate = e => {
    const nextFormState = {
      ...loginInput,
      [e.target.name]: e.target.value,
    };
    setLoginInput(nextFormState);
  }

  return (
    <div class="h-screen w-screen flex justify-center items-center">
    <div class="z-10 bg-cloudy/90 w-2/5 h-3/4 rounded-2xl p-4 flex items-center justify-center">
      <div class="z-10 bg-white w-full h-full rounded-2xl p-8">
        <div class="text-3xl font-bold pb-4">Login</div>
        <div>
          <form class="flex flex-col" onSubmit={onSubmitForm}>
            <label>
              <div class="text-2xl mb-1">Email</div>
              <input
                class="border border-black h-20 w-full rounded-2xl text-3xl"
                name="email"
                type='text'
                value={loginInput.email}
                onChange={onFormUpdate}
              />
            </label>
            <label class="mt-4">
              <div class="text-2xl mb-1">Password</div>
              <input
                class="border border-black h-20 w-full rounded-2xl text-3xl"
                name="password"
                type='password'
                value={loginInput.password}
                onChange={onFormUpdate}
              />
            </label>
            <button
              class="mt-4 h-20 w-full rounded-2xl bg-matrix text-merino text-3xl font-bold"
              type="submit"
            >
              LOGIN
            </button>
          </form>
          <hr class="z-10 w-full mt-4 border-black" />
          <div class="text-2xl mb-1">
            Don't have an account: <Link to="/signup">Sign Up</Link>
          </div>
        </div>
      </div>
    </div>
  </div>
  );
}

export default LoginPannel