import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  apiUrl:string ="https://localhost:44318/api/";//contacts

  constructor(private _http: HttpClient) { }

  list(): Observable<any[]> {
    return this._http.get<any[]>(this.apiUrl+"contacts");
  }
  get(id:number): Observable<any> {
    return this._http.get<any>(this.apiUrl+"contacts/"+id);
  }

  create(userData:any): Observable<any> {
    return this._http.post<any>(this.apiUrl+"contacts",userData);
  }

  edit(id:number,userData:any): Observable<any> {
    return this._http.put<any>(this.apiUrl+"contacts/"+id,userData);
  }

  delete(id:number): Observable<number> {
    return this._http.delete<number>(this.apiUrl+"contacts/"+id);
  }

}
