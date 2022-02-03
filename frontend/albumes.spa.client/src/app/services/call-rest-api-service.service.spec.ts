import { TestBed } from '@angular/core/testing';

import { CallRestApiServiceService } from './call-rest-api-service.service';

describe('CallRestApiServiceService', () => {
  let service: CallRestApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CallRestApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
