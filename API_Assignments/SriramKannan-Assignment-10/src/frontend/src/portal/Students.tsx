import { useEffect, useState } from "react";
import { createStudent, getStudents, Student } from "../services/studentService";
export default function Students() {
  const [rows,setRows]=useState<Student[]>([]); const [error,setError]=useState(""); const [busy,setBusy]=useState(false);
  const [studentNumber,setNumber]=useState(""); const [fullName,setName]=useState(""); const [email,setEmail]=useState("");
  async function load(){ try { setRows(await getStudents()); setError(""); } catch { setError("Could not load students. Check the API and your role."); } }
  useEffect(()=>{ void load(); },[]);
  async function submit(e:React.FormEvent){ e.preventDefault(); setBusy(true); try { await createStudent({studentNumber,fullName,email}); setNumber("");setName("");setEmail("");await load(); } catch { setError("Create failed. Only Teacher accounts can write."); } finally { setBusy(false); } }
  return <main className="page"><h1>Students</h1>{error&&<p role="alert" className="error">{error}</p>}
    <form onSubmit={submit} className="panel"><h2>Add student (Teacher only)</h2>
      <label>Student number<input value={studentNumber} onChange={e=>setNumber(e.target.value)} required /></label>
      <label>Full name<input value={fullName} onChange={e=>setName(e.target.value)} required /></label>
      <label>Email<input type="email" value={email} onChange={e=>setEmail(e.target.value)} required /></label>
      <button disabled={busy}>{busy?"Saving...":"Add student"}</button>
    </form>
    <h2>Student list</h2><ul>{rows.map(s=><li key={s.id}>{s.studentNumber} — {s.fullName} ({s.email})</li>)}</ul>
  </main>;
}
