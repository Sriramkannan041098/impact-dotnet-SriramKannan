import { Link, useNavigate } from "react-router-dom";
import { clearToken } from "../utils/auth";
export default function Dashboard() {
  const navigate=useNavigate();
  return <main className="page"><header><h1>EduSphere Dashboard</h1><button onClick={()=>{clearToken();navigate("/login");}}>Logout</button></header>
    <p>Welcome to the Student Management & Academic Intelligence Platform.</p>
    <nav className="links"><Link to="/students">Students</Link><Link to="/courses">Courses</Link><Link to="/reports">Enrollment reports</Link></nav>
  </main>;
}
