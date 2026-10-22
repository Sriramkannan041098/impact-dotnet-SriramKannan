import { FormEvent, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { login } from "../services/identityService";
import { setToken } from "../utils/auth";
import '../styles/auth.scss';

import {
  Box, Card,  Stack, Modal, Paper, Grid,
  Button,  TextField, Typography, MenuItem, Menu, Drawer, Autocomplete,
  TableBody, TableCell, TableContainer, TableHead, TableRow, Table,
  IconButton, Radio, Tooltip,
  ListItemIcon
} from "@mui/material";


export default function Login() {

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  async function submit(e: FormEvent) {
    e.preventDefault(); 
    setError("");
    try {
      const result = await login(email, password);
      setToken(result.accessToken);
      navigate("/");
    }
    catch {
      setError("Login failed. Check your credentials and try again.");
    }
  }
  return (
    <div className="auth h-full bg-linear-to-r from-slate-100 to-slate-400">
      <form onSubmit={submit} className="panel w-1/3 loginPage">
        <h1>EduSphere Login</h1>

        <TextField label='Email' fullWidth type="email" value={email} onChange={e => setEmail(e.target.value)} />

        <TextField label='Password' fullWidth type="password" value={password} onChange={e => setPassword(e.target.value)} />
        {error && <p role="alert" className="error">{error}</p>}

        <button>Login</button>
        <p>New here? <Link to="/signup">Create account</Link></p>
      </form>
    </div>
  );
}
