import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../../models';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  getForecasts(): Observable<Employee[]> {
    return this.http.get<Employee[]>('http://localhost:7049/WeatherForecast');
  };

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(environment.apiUrl + '/Employees/GetEmployees');
  }

  getEmployee(search: string): Observable<Employee> {
    return this.http.get<Employee>(environment.apiUrl+'/Employees/GetEmployee?id='+search);
  }

}
