import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BanqProgramsComponent } from './banq-programs.component';

describe('BanqProgramsComponent', () => {
  let component: BanqProgramsComponent;
  let fixture: ComponentFixture<BanqProgramsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BanqProgramsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BanqProgramsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
