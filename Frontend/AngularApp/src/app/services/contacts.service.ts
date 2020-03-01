import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';
@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  apiUrl:string ="https://localhost:44318/api/";//contacts

  constructor(private _http: HttpClient) { }

  list(): Observable<any[]> {
    return this._http.get<any[]>(this.apiUrl+"contacts");
  }

  create(userData:any): Observable<any> {
    return this._http.post<any>(this.apiUrl+"contacts",userData);
  }


}
