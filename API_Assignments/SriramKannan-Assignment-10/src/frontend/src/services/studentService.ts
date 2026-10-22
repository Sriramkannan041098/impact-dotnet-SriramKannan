import { apiClient } from "./apiClient";
export type Student = { id: number; studentNumber: string; fullName: string; email: string; dateOfBirth?: string | null; isActive: boolean };
export type CreateStudent = { studentNumber: string; fullName: string; email: string; dateOfBirth?: string | null };
export async function getStudents(): Promise<Student[]> {
  try { return (await apiClient.get<Student[]>("/academics/students")).data; }
  catch (error) { console.error("get students failed", error); throw error; }
}
export async function createStudent(payload: CreateStudent): Promise<Student> {
  try { return (await apiClient.post<Student>("/academics/students", payload)).data; }
  catch (error) { console.error("create student failed", error); throw error; }
}
export async function updateStudent(id: number, payload: Omit<Student, "id" | "studentNumber">): Promise<void> {
  try { await apiClient.put(`/academics/students/${id}`, payload); }
  catch (error) { console.error("update student failed", error); throw error; }
}
export async function deleteStudent(id: number): Promise<void> {
  try { await apiClient.delete(`/academics/students/${id}`); }
  catch (error) { console.error("delete student failed", error); throw error; }
}
