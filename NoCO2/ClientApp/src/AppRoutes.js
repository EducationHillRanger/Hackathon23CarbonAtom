import { Main } from "./components/Introduction/Main";
import { SignUp } from "./components/AccountActionPage/SignUp";

const AppRoutes = [
  {
    index: true,
    element: <Main />
  },
  {
    path: '/signup',
    element: <SignUp />
  },
];

export default AppRoutes;
