import { TestBed } from '@angular/core/testing';

import { BanqInfoService } from './banq-info.service';

describe('BanqInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BanqInfoService = TestBed.get(BanqInfoService);
    expect(service).toBeTruthy();
  });
});
