import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BanderaGridComponent } from './bandera-grid.component';

describe('BanderaGridComponent', () => {
  let component: BanderaGridComponent;
  let fixture: ComponentFixture<BanderaGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BanderaGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BanderaGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
