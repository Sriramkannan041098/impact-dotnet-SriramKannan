import { FormEvent, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { register } from "../services/identityService";
import { setToken } from "../utils/auth";
export default function Signup() {
  const [email,setEmail]=useState(""); const [name,setName]=useState(""); const [password,setPassword]=useState(""); const [error,setError]=useState("");
  const navigate=useNavigate();
  async function submit(e:FormEvent){ e.preventDefault(); setError(""); try { const result=await register(email,name,password); setToken(result.accessToken); navigate("/"); } catch { setError("Registration failed. The email may already be registered."); } }
  return <main className="auth"><form onSubmit={submit} className="panel"><h1>Create account</h1>
    <label>Display name<input value={name} onChange={e=>setName(e.target.value)} required /></label>
    <label>Email<input type="email" value={email} onChange={e=>setEmail(e.target.value)} required /></label>
    <label>Password (10+ characters)<input type="password" minLength={10} value={password} onChange={e=>setPassword(e.target.value)} required /></label>
    {error && <p role="alert" className="error">{error}</p>}<button>Create account</button><p><Link to="/login">Back to login</Link></p>
  </form></main>;
}
