import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BanqProgramFoodComponent } from './banq-program-food.component';

describe('BanqProgramFoodComponent', () => {
  let component: BanqProgramFoodComponent;
  let fixture: ComponentFixture<BanqProgramFoodComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BanqProgramFoodComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BanqProgramFoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
