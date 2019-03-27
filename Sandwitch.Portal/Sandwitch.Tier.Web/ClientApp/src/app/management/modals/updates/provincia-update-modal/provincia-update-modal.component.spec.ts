import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvinciaUpdateModalComponent } from './provincia-update-modal.component';

describe('ProvinciaUpdateModalComponent', () => {
  let component: ProvinciaUpdateModalComponent;
  let fixture: ComponentFixture<ProvinciaUpdateModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvinciaUpdateModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinciaUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
