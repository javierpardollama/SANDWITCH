import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvinciaAddModalComponent } from './provincia-add-modal.component';

describe('ProvinciaAddModalComponent', () => {
  let component: ProvinciaAddModalComponent;
  let fixture: ComponentFixture<ProvinciaAddModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvinciaAddModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvinciaAddModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
