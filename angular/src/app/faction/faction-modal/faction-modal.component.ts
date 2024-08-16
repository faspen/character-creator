import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output, Renderer2, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ConstantsService } from '../../constants.service';
import { FactionAddEditDto } from '../faction.model';
import { FactionModalService } from './faction-modal-service.service';

@Component({
  selector: 'app-faction-modal',
  templateUrl: './faction-modal.component.html',
  styleUrl: './faction-modal.component.css'
})
export class FactionModalComponent {
  @ViewChild('factionForm') factionForm: NgForm | undefined;
  @Input() factionDto = new FactionAddEditDto();
  @Output() refreshData: EventEmitter<any> = new EventEmitter<any>();
  modalVisible = false;
  subscription!: Subscription;
  backdrop: HTMLElement | null = null;

  constructor(
    private modalService: FactionModalService,
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
    this.factionForm?.resetForm();
    this.modalService.hideModal();
  }

  save() {
    if (this.factionDto.id < 1) {
      this.http.post(this.constants.apiUrl + 'faction', this.factionDto, { responseType: 'text' })
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
      this.http.put(this.constants.apiUrl + 'faction', this.factionDto, { responseType: 'text' })
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
