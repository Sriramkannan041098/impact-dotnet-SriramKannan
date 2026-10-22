import { apiClient } from "./apiClient";
export type Course = { id:number; courseCode:string; title:string; description?:string|null; teacherId?:number|null };
export async function getCourses():Promise<Course[]> { try { return (await apiClient.get<Course[]>("/academics/courses")).data; } catch(error) { console.error("get courses failed",error); throw error; } }
export async function createCourse(payload:Omit<Course,"id">):Promise<Course> { try { return (await apiClient.post<Course>("/academics/courses",payload)).data; } catch(error) { console.error("create course failed",error); throw error; } }
export async function updateCourse(id:number,payload:Omit<Course,"id"|"courseCode">):Promise<void> { try { await apiClient.put(`/academics/courses/${id}`,payload); } catch(error) { console.error("update course failed",error); throw error; } }
export async function deleteCourse(id:number):Promise<void> { try { await apiClient.delete(`/academics/courses/${id}`); } catch(error) { console.error("delete course failed",error); throw error; } }
