import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudTComponent } from './crud-t.component';

describe('CrudTComponent', () => {
  let component: CrudTComponent;
  let fixture: ComponentFixture<CrudTComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrudTComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudTComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
