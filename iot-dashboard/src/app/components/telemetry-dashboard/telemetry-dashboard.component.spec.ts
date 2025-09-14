import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TelemetryDashboardComponent } from './telemetry-dashboard.component';

describe('TelemetryDashboardComponent', () => {
  let component: TelemetryDashboardComponent;
  let fixture: ComponentFixture<TelemetryDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TelemetryDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TelemetryDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
