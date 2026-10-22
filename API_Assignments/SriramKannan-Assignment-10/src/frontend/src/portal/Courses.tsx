import { useEffect,useState } from "react";
import { Course,getCourses,createCourse } from "../services/courseService";
export default function Courses(){
 const [rows,setRows]=useState<Course[]>([]); const [courseCode,setCode]=useState(""); const [title,setTitle]=useState(""); const [error,setError]=useState("");
 async function load(){try{setRows(await getCourses());setError("");}catch{setError("Courses are currently unavailable.");}}
 useEffect(()=>{void load();},[]);
 async function submit(e:React.FormEvent){e.preventDefault();try{await createCourse({courseCode,title,description:null,teacherId:null});setCode("");setTitle("");await load();}catch{setError("Could not create course. Teacher role is required.");}}
 return <main className="page"><h1>Courses</h1>{error&&<p role="alert" className="error">{error}</p>}<form className="panel" onSubmit={submit}><label>Course code<input value={courseCode} onChange={e=>setCode(e.target.value)} required/></label><label>Title<input value={title} onChange={e=>setTitle(e.target.value)} required/></label><button>Create course</button></form><ul>{rows.map(x=><li key={x.id}>{x.courseCode} — {x.title}</li>)}</ul></main>;
}
