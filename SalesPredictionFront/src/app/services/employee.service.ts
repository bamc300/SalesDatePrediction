import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private _http: HttpClient) {}

  addEmployee(data: any): Observable<any> {
    return this._http.post('http://localhost:5038/​api​/AddNewOrder​/Guardar', data);
    
  }

  updateEmployee(id: number, data: any): Observable<any> {
    return this._http.put(`http://localhost:5038/api/DatePrediction/Lista/${id}`, data);
  }

  getEmployeeList(): Observable<any> {
    return this._http.get('http://localhost:5038/api/DatePrediction/Lista');
  }
  getUserList(id: any): Observable<any> {
    return this._http.get(`http://localhost:5038/api/ClientOrders/Obtener/${id}`);
    
  }


  ClientOrders(id: number): Observable<any> {
    return this._http.delete(`http://localhost:5038/api/DatePrediction/Lista/${id}`);
  }
}
