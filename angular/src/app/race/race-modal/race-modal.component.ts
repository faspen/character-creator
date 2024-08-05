import { Component, EventEmitter, Input, Output, Renderer2, ViewChild } from '@angular/core';
import { RaceAddEditDto } from '../race.model';
import { RaceModalService } from './racer-modal-service.service';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ConstantsService } from '../../constants.service';

@Component({
  selector: 'app-race-modal',
  templateUrl: './race-modal.component.html',
  styleUrl: './race-modal.component.css'
})
export class RaceModalComponent {
  @ViewChild('raceForm') raceForm: NgForm | undefined;
  @Input() raceDto = new RaceAddEditDto();
  @Output() refreshData: EventEmitter<any> = new EventEmitter<any>();
  modalVisible = false;
  subscription!: Subscription;
  backdrop: HTMLElement | null = null;

  constructor(
    private modalService: RaceModalService,
    private renderer: Renderer2,
    private http: HttpClient,
    private constants: ConstantsService
  ) {}

  ngOnInit() {
    this.subscription = this.modalService.modalVisible$.subscribe(visible => {
      this.modalVisible = visible;
      if (visible) {
        this.showBackdrop();
      } else {
        this.hideBackdrop();
      }
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  closeModal() {
    this.raceForm?.resetForm();
    this.modalService.hideModal();
  }

  save() {
    if (this.raceDto.id < 1) {
      this.http.post(this.constants.apiUrl + 'Race', this.raceDto, { responseType: 'text' })
        .subscribe({
          next: res => {
            this.refreshData.emit();
            this.closeModal();
          },
          error: err => {
            console.log(err);
          }
        });
    } else {
      this.http.put(this.constants.apiUrl + 'Race', this.raceDto, { responseType: 'text' })
        .subscribe({
          next: res => {
            this.refreshData.emit();
            this.closeModal();
          },
          error: err => {
            console.log(err);
          }
        });
    }
  }

  showBackdrop() {
    this.backdrop = this.renderer.createElement('div');
    this.renderer.addClass(this.backdrop, 'modal-backdrop');
    this.renderer.addClass(this.backdrop, 'fade');
    this.renderer.addClass(this.backdrop, 'show');
    this.renderer.appendChild(document.body, this.backdrop);
  }

  hideBackdrop() {
    if (this.backdrop) {
      this.renderer.removeChild(document.body, this.backdrop);
      this.backdrop = null;
    }
  }
}
