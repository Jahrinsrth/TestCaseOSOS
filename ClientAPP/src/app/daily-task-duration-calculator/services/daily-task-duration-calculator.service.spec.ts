import { TestBed } from '@angular/core/testing';

import { DailyTaskDurationCalculatorService } from './daily-task-duration-calculator.service';

describe('DailyTaskDurationCalculatorService', () => {
  let service: DailyTaskDurationCalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DailyTaskDurationCalculatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
