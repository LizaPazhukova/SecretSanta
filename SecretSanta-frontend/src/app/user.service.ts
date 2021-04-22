import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { User } from './user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) { }
  addUser(user: User) {
    return this.http.post<User>(this.baseUrl + "users", user);
  }
  getUsers() {
    return this.http.get<User[]>(this.baseUrl + "users");
  }
}
