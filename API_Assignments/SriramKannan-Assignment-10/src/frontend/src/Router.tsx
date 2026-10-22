import { Navigate, Route, Routes } from "react-router-dom";
import Login from "./auth/Login";
import Signup from "./auth/Signup";
import Dashboard from "./portal/Dashboard";
import Students from "./portal/Students";
import Reports from "./portal/Reports";
import Courses from "./portal/Courses";
import { isAuthenticated } from "./utils/auth";

function Protected({ children }: { children: React.ReactNode }) {
  return isAuthenticated() ? <>{children}</> : <Navigate to="/login" replace />;
}


const Router = () => {
  return (
    <Routes>
      <Route path="/login"    element={<Login />} />
      <Route path="/signup"   element={<Signup />} />
      <Route path="/"         element={ <Dashboard /> } />
      <Route path="/students" element={ <Students /> } />
      <Route path="/reports"  element={ <Reports /> } />
      <Route path="/courses"  element={ <Courses />} />
      
      {/* <Route path="/" element={
        <Protected>
          <Dashboard />
        </Protected>
      } />

      <Route path="/students" element={
        <Protected>
          <Students />
        </Protected>
      } />

      <Route path="/reports" element={
        <Protected>
          <Reports />
        </Protected>        
      } />

      <Route path="/courses" element={
        <Protected>
          <Courses />
        </Protected>
      } /> */}

      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  )
}

export default Router