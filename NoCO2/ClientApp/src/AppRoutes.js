import { Main } from "./components/Introduction/Main";
import { SignUp } from "./components/AccountActionPage/SignUp/SignUp";
import { Login } from "./components/AccountActionPage/Login/Login";

const AppRoutes = [
  {
    index: true,
    element: <Main />
  },
  {
    path: '/signup',
    element: <SignUp />
  },
  {
    path: '/login',
    element: <Login />
  }
];

export default AppRoutes;
