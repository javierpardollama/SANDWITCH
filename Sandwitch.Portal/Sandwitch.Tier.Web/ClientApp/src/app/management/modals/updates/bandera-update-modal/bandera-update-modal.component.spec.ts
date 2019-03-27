import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BanderaUpdateModalComponent } from './bandera-update-modal.component';

describe('BanderaUpdateModalComponent', () => {
  let component: BanderaUpdateModalComponent;
  let fixture: ComponentFixture<BanderaUpdateModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BanderaUpdateModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BanderaUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
