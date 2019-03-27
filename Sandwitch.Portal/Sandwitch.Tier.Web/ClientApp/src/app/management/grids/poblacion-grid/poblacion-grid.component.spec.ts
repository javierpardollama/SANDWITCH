import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PoblacionGridComponent } from './poblacion-grid.component';

describe('PoblacionGridComponent', () => {
  let component: PoblacionGridComponent;
  let fixture: ComponentFixture<PoblacionGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PoblacionGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PoblacionGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
