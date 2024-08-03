import { Component, EventEmitter, Input, OnDestroy, OnInit, Output, Renderer2, ViewChild } from '@angular/core';
import { CharacterModalService } from './character-modal-service.service';
import { Subscription } from 'rxjs';
import { CharacterAddEditDto } from '../character.model';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../../constants.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-character-modal',
  templateUrl: './character-modal.component.html',
  styleUrl: './character-modal.component.css'
})
export class CharacterModalComponent implements OnInit, OnDestroy {
  @ViewChild('characterForm') characterForm: NgForm | undefined;
  @Input() characterDto = new CharacterAddEditDto();
  @Output() refreshData: EventEmitter<any> = new EventEmitter<any>();
  modalVisible = false;
  subscription!: Subscription;
  backdrop: HTMLElement | null = null;

  constructor(
    private modalService: CharacterModalService,
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
    this.characterForm?.resetForm();
    this.modalService.hideModal();
  }

  save() {
    if (this.characterDto.id < 1) {
      this.http.post(this.constants.apiUrl + 'Character', this.characterDto, { responseType: 'text' })
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
      this.http.put(this.constants.apiUrl + 'Character', this.characterDto, { responseType: 'text' })
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