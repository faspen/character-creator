import { Component, ElementRef, ViewChild } from '@angular/core';
import { RaceAddEditDto, RaceDto } from './race.model';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../constants.service';
import { RaceModalService } from './race-modal/racer-modal-service.service';

@Component({
  selector: 'app-race',
  templateUrl: './race.component.html',
  styleUrl: './race.component.css'
})
export class RaceComponent {
  @ViewChild('characterModal') characterModal: ElementRef | undefined;
  races: RaceDto[] = [];
  raceToUpdate = new RaceAddEditDto();

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

  delete(id: number) {
    this.http.delete(this.constants.apiUrl + 'Race/' + id)
      .subscribe({
        next: res => {
          this.getData();
        },
        error: err => console.log(err)
      });
  }
}
