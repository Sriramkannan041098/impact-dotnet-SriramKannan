import { apiClient } from "./apiClient";
export type EnrollmentSummary = { id: number; courseCode: string; courseTitle: string; teacherName?: string; totalStudents: number; activeEnrollments: number; snapshotUtc: string };
export async function getEnrollmentSummaries(): Promise<EnrollmentSummary[]> {
  try { return (await apiClient.get<EnrollmentSummary[]>("/reporting/enrollment-summaries")).data; }
  catch (error) { console.error("get reports failed", error); throw error; }
}
