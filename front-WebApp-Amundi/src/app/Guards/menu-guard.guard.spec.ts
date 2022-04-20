import { TestBed } from '@angular/core/testing';

import { MenuGuardGuard } from './menu-guard.guard';

describe('MenuGuardGuard', () => {
  let guard: MenuGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(MenuGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
