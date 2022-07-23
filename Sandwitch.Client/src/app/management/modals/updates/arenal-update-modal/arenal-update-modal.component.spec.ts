import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArenalUpdateModalComponent } from './arenal-update-modal.component';

describe('ArenalUpdateModalComponent', () => {
  let component: ArenalUpdateModalComponent;
  let fixture: ComponentFixture<ArenalUpdateModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArenalUpdateModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArenalUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
