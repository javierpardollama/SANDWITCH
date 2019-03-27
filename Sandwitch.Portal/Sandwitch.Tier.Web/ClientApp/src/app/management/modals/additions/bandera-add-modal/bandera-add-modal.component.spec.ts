import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BanderaAddModalComponent } from './bandera-add-modal.component';

describe('BanderaAddModalComponent', () => {
  let component: BanderaAddModalComponent;
  let fixture: ComponentFixture<BanderaAddModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BanderaAddModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BanderaAddModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
