import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArenalGridComponent } from './arenal-grid.component';

describe('ArenalGridComponent', () => {
  let component: ArenalGridComponent;
  let fixture: ComponentFixture<ArenalGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArenalGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArenalGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
