import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PoblacionesComponent } from './poblaciones.component';

describe('PoblacionesComponent', () => {
  let component: PoblacionesComponent;
  let fixture: ComponentFixture<PoblacionesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PoblacionesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PoblacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
