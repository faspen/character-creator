import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FactionComponent } from './faction.component';

describe('FactionComponent', () => {
  let component: FactionComponent;
  let fixture: ComponentFixture<FactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FactionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
