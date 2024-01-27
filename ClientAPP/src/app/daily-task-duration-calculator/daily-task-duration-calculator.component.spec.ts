import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyTaskDurationCalculatorComponent } from './daily-task-duration-calculator.component';

describe('DailyTaskDurationCalculatorComponent', () => {
  let component: DailyTaskDurationCalculatorComponent;
  let fixture: ComponentFixture<DailyTaskDurationCalculatorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DailyTaskDurationCalculatorComponent]
    });
    fixture = TestBed.createComponent(DailyTaskDurationCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
