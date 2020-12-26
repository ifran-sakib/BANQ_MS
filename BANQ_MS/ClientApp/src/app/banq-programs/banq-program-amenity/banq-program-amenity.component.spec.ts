import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BanqProgramAmenityComponent } from './banq-program-amenity.component';

describe('BanqProgramAmenityComponent', () => {
  let component: BanqProgramAmenityComponent;
  let fixture: ComponentFixture<BanqProgramAmenityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BanqProgramAmenityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BanqProgramAmenityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
