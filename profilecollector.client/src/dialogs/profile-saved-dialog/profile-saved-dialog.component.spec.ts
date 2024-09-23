import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileSavedDialogComponent } from './profile-saved-dialog.component';

describe('ProfileSavedDialogComponent', () => {
  let component: ProfileSavedDialogComponent;
  let fixture: ComponentFixture<ProfileSavedDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileSavedDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfileSavedDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
