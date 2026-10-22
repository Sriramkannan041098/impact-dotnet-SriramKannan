import { apiClient } from "./apiClient";
export type AuthResponse = { accessToken: string; expiresUtc: string; displayName: string; role: string };
export async function login(email: string, password: string): Promise<AuthResponse> {
  try { const { data } = await apiClient.post<AuthResponse>("/identity/login", { email, password }); return data; }
  catch (error) { console.error("login failed", error); throw error; }
}
export async function register(email: string, displayName: string, password: string): Promise<AuthResponse> {
  try { const { data } = await apiClient.post<AuthResponse>("/identity/register", { email, displayName, password }); return data; }
  catch (error) { console.error("registration failed", error); throw error; }
}
