import { TestBed } from '@angular/core/testing';

import { DiccionaryApiService } from './diccionary-api.service';

describe('DiccionaryApiService', () => {
  let service: DiccionaryApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DiccionaryApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
