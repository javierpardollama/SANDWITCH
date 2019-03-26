import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvinciasComponent } from './provincias.component';

describe('ProvinciasComponent', () => {
  let component: ProvinciasComponent;
  let fixture: ComponentFixture<ProvinciasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvinciasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinciasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
