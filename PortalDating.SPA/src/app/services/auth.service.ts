import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

apiUrl = 'http://localhost:5000/api/';

constructor(private http: HttpClient) { }

login(model: any) {
  this.http.post(this.apiUrl + 'login', model).pipe(map(
    (response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token)
      }
    }
  ));
}
}
