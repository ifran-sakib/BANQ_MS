import { TestBed } from '@angular/core/testing';

import { BanqProgramAmenityService } from './banq-program-amenity.service';

describe('BanqProgramAmenityService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BanqProgramAmenityService = TestBed.get(BanqProgramAmenityService);
    expect(service).toBeTruthy();
  });
});
