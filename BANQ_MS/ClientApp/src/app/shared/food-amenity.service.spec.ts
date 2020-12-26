import { TestBed } from '@angular/core/testing';

import { FoodAmenityService } from './food-amenity.service';

describe('FoodAmenityService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FoodAmenityService = TestBed.get(FoodAmenityService);
    expect(service).toBeTruthy();
  });
});
