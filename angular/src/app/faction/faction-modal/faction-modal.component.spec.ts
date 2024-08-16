import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FactionModalComponent } from './faction-modal.component';

describe('FactionModalComponent', () => {
  let component: FactionModalComponent;
  let fixture: ComponentFixture<FactionModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FactionModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FactionModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
