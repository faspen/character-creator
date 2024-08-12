import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { RaceAddEditDto, RaceDto } from './race.model';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../constants.service';
import { RaceModalService } from './race-modal/racer-modal-service.service';

@Component({
  selector: 'app-race',
  templateUrl: './race.component.html',
  styleUrl: './race.component.css'
})
export class RaceComponent implements OnInit {
  @ViewChild('characterModal') characterModal: ElementRef | undefined;
  races: RaceDto[] = [];
  raceToUpdate = new RaceAddEditDto();
  deletionWarningShow = false;

  constructor(private http: HttpClient, private constants: ConstantsService, private modalService: RaceModalService) { }
  
  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.http.get(this.constants.apiUrl + 'Race')
      .subscribe({
        next: res => {
          this.races = res as RaceDto[];
        },
        error: err => console.log(err)
      });
  }

  openModal() {
    this.modalService.showModal();
    this.raceToUpdate = new RaceAddEditDto();
  }

  openForEdit(character: RaceDto) {
    this.openModal();
    this.raceToUpdate = { ...character };
  }

  delete(race: RaceDto) {
    if (race.characters.length > 0) {
      this.deletionWarningShow = true;
      setTimeout(() => {
        this.deletionWarningShow = false;
      }, 5000);

      return;
    }
    this.http.delete(this.constants.apiUrl + 'Race/' + race.id)
      .subscribe({
        next: res => {
          this.getData();
        },
        error: err => console.log(err)
      });
  }
}
