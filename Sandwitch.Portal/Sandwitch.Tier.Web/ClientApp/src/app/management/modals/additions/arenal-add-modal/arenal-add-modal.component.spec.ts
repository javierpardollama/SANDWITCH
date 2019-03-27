import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArenalAddModalComponent } from './arenal-add-modal.component';

describe('ArenalAddModalComponent', () => {
  let component: ArenalAddModalComponent;
  let fixture: ComponentFixture<ArenalAddModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArenalAddModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArenalAddModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
