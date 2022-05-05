import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataCheckerComponent } from './data-checker.component';

describe('DataCheckerComponent', () => {
  let component: DataCheckerComponent;
  let fixture: ComponentFixture<DataCheckerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DataCheckerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DataCheckerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
