import { Component, OnInit } from '@angular/core';
import { DailyTaskDurationCalculatorService } from './services/daily-task-duration-calculator.service';

@Component({
  selector: 'app-daily-task-duration-calculator',
  templateUrl: './daily-task-duration-calculator.component.html',
  styleUrls: ['./daily-task-duration-calculator.component.css']
})
export class DailyTaskDurationCalculatorComponent implements OnInit {

  numberOfDaysForCompletion: number;
  startDate: Date;
  endDate: Date;

  constructor(private dailyTaskDurationCalculatorService: DailyTaskDurationCalculatorService) {}

  ngOnInit(): void {}

  onSubmit(formData: any) {
    this.dailyTaskDurationCalculatorService.getTaskEndDate(formData.value).subscribe(res => {
      this.endDate = res.endDate
      formData.reset();
    })
  }
}
