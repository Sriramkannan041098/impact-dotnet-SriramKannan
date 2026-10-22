import { apiClient } from "./apiClient";
export type Teacher = { id:number; fullName:string; email:string };
export async function getTeachers():Promise<Teacher[]> { try { return (await apiClient.get<Teacher[]>("/academics/teachers")).data; } catch(error) { console.error("get teachers failed",error); throw error; } }
export async function createTeacher(payload:{fullName:string;email:string;userId?:number|null}):Promise<Teacher> { try { return (await apiClient.post<Teacher>("/academics/teachers",payload)).data; } catch(error) { console.error("create teacher failed",error); throw error; } }
