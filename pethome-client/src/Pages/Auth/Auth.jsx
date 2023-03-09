import SignUpView from "./SignUp/SignUpView";
import SignInView from "./SignIn/SignInView";
import LogOutView from "./LogOut/LogOutView";
import RefreshView from "./Refresh/RefreshView"

export default function Auth() {
  return <div>
    <SignUpView />
    <SignInView />
    <LogOutView />
    <RefreshView />
  </div>
}