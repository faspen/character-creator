import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { ConstantsService } from '../constants.service';
import { FactionAddEditDto, FactionDto } from './faction.model';
import { FactionModalService } from './faction-modal/faction-modal-service.service';

@Component({
  selector: 'app-faction',
  templateUrl: './faction.component.html',
  styleUrl: './faction.component.css'
})
export class FactionComponent {
  @ViewChild('factionModal') factionModal: ElementRef | undefined;
  factions: FactionDto[] = [];
  factionToUpdate = new FactionAddEditDto();
  deletionWarningShow = false;

  constructor(private http: HttpClient, private constants: ConstantsService, private modalService: FactionModalService) {}

  ngOnInit(): void {
      this.getData();
  }

  getData() {
    this.http.get(this.constants.apiUrl + 'faction')
      .subscribe({
        next: res => {
          this.factions = res as FactionDto[];
        },
        error: err => console.log(err)
      });
  }

  openModal() {
    this.modalService.showModal();
    this.factionToUpdate = new FactionAddEditDto();
  }

  openForEdit(faction: FactionDto) {
    this.openModal();
    this.factionToUpdate = { ...faction };
  }

  delete(faction: FactionDto) {
    // if (race.characters.length > 0) {
    //   this.deletionWarningShow = true;
    //   setTimeout(() => {
    //     this.deletionWarningShow = false;
    //   }, 5000);

    //   return;
    // }
    this.http.delete(this.constants.apiUrl + 'faction/' + faction.id)
      .subscribe({
        next: res => {
          this.getData();
        },
        error: err => console.log(err)
      });
  }
}
