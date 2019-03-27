import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PoblacionAddModalComponent } from './poblacion-add-modal.component';

describe('PoblacionAddModalComponent', () => {
  let component: PoblacionAddModalComponent;
  let fixture: ComponentFixture<PoblacionAddModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PoblacionAddModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PoblacionAddModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
