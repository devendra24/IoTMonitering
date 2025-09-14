import { TestBed } from '@angular/core/testing';
import { ResolveFn } from '@angular/router';

import { devicesResolver } from './devices.resolver';

describe('devicesResolver', () => {
  const executeResolver: ResolveFn<any[]> = (...resolverParameters) => 
      TestBed.runInInjectionContext(() => devicesResolver(...resolverParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeResolver).toBeTruthy();
  });
});
