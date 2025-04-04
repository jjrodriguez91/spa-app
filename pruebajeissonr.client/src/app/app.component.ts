import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './services/employee/employee.service';
import { Employee } from './models';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  employees: Employee[] = [];
  isLoadingData: boolean = true;

  constructor(private employeeService: EmployeeService) {}

  ngOnInit() {
    this.getEmployees('');
  }

  getEmployees(search: string) : void {
    this.isLoadingData = true;
    this.employees = [];
    if(search == ''){
      this.employeeService.getEmployees()
      .pipe(
        finalize(() => this.isLoadingData = false)
      )
      .subscribe({
        next: (employees) => {
          this.employees = employees;
          console.log('employees loaded', employees);
        },
        error: (err) => {
          console.error('Error loading employees', err);
        }
      });
    }else{
      console.log('search', search);
      this.employeeService.getEmployee(search)
      .pipe(
        finalize(() => this.isLoadingData = false)
      )
      .subscribe({
        next: (employee) => {
          this.employees =[];
          this.employees.push(employee);
          console.log('employee loaded', employee);
        },
        error: (err) => {
          console.error('Error loading employee', err);
        }
      });
    }
  }

  handleSearch(query: string) {
    this.getEmployees(query);
  }



  title = 'pruebajeissonr.client';
}
