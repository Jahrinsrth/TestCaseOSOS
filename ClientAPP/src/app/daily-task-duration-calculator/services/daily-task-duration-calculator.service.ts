import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DailyTaskDurationCalculatorService {

  url = "https://localhost:7052/api/DailyTaskCalculation";

  constructor(private http: HttpClient) { }

  getTaskEndDate(obj: any): Observable<any> {
    return this.http.post<any>(this.url, obj);
  }
}
