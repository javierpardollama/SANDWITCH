import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PoblacionUpdateModalComponent } from './poblacion-update-modal.component';

describe('PoblacionUpdateModalComponent', () => {
  let component: PoblacionUpdateModalComponent;
  let fixture: ComponentFixture<PoblacionUpdateModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PoblacionUpdateModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PoblacionUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
