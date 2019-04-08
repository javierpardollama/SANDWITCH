import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricoAddModalComponent } from './historico-add-modal.component';

describe('HistoricoAddModalComponent', () => {
  let component: HistoricoAddModalComponent;
  let fixture: ComponentFixture<HistoricoAddModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistoricoAddModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoricoAddModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
