import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BanqProgramComponent } from './banq-program.component';

describe('BanqProgramComponent', () => {
  let component: BanqProgramComponent;
  let fixture: ComponentFixture<BanqProgramComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BanqProgramComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BanqProgramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
