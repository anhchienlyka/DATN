import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalecodeComponent } from './salecode.component';

describe('SalecodeComponent', () => {
  let component: SalecodeComponent;
  let fixture: ComponentFixture<SalecodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SalecodeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SalecodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
