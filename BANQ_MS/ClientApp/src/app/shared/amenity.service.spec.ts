import { TestBed } from '@angular/core/testing';

import { AmenityService } from './amenity.service';

describe('AmenityService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AmenityService = TestBed.get(AmenityService);
    expect(service).toBeTruthy();
  });
});
