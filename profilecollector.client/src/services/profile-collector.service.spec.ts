import { TestBed } from '@angular/core/testing';

import { ProfileCollectorService } from './profile-collector.service';

describe('ProfileCollectorService', () => {
  let service: ProfileCollectorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProfileCollectorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
