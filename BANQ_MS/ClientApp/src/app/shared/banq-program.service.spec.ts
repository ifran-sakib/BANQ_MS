import { TestBed } from '@angular/core/testing';

import { BanqProgramService } from './banq-program.service';

describe('BanqProgramService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BanqProgramService = TestBed.get(BanqProgramService);
    expect(service).toBeTruthy();
  });
});
