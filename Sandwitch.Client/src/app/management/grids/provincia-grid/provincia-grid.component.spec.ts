import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvinciaGridComponent } from './provincia-grid.component';

describe('ProvinciaGridComponent', () => {
  let component: ProvinciaGridComponent;
  let fixture: ComponentFixture<ProvinciaGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvinciaGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinciaGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
