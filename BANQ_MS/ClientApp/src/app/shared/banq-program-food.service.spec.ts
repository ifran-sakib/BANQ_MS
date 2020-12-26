import { TestBed } from '@angular/core/testing';

import { BanqProgramFoodService } from './banq-program-food.service';

describe('BanqProgramFoodService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BanqProgramFoodService = TestBed.get(BanqProgramFoodService);
    expect(service).toBeTruthy();
  });
});
