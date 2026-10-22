import { useEffect, useState } from "react";
import { EnrollmentSummary, getEnrollmentSummaries } from "../services/reportingService";
export default function Reports() {
  const [rows,setRows]=useState<EnrollmentSummary[]>([]); const [error,setError]=useState("");
  useEffect(()=>{ getEnrollmentSummaries().then(setRows).catch(()=>setError("Reporting is temporarily unavailable. You can still use the rest of the portal.")); },[]);
  return <main className="page"><h1>Enrollment reports</h1>{error&&<p role="status">{error}</p>}
    <table><thead><tr><th>Course</th><th>Teacher</th><th>Students</th><th>Active enrollments</th></tr></thead>
      <tbody>{rows.map(r=><tr key={r.id}><td>{r.courseCode} — {r.courseTitle}</td><td>{r.teacherName??"—"}</td><td>{r.totalStudents}</td><td>{r.activeEnrollments}</td></tr>)}</tbody>
    </table>
  </main>;
}
