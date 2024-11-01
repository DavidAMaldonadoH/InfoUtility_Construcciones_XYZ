import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterEngineerComponent } from './register-engineer.component';

describe('RegisterEngineerComponent', () => {
  let component: RegisterEngineerComponent;
  let fixture: ComponentFixture<RegisterEngineerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegisterEngineerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterEngineerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
