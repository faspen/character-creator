import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../constants.service';
import { CharacterAddEditDto, CharacterDto, Sex } from './character.model';
import { CharacterModalService } from './character-modal/character-modal-service.service';

@Component({
  selector: 'app-character',
  templateUrl: './character.component.html',
  styleUrl: './character.component.css'
})
export class CharacterComponent implements OnInit {
  @ViewChild('characterModal') characterModal: ElementRef | undefined;
  characters: CharacterDto[] = [];
  sexes = Sex;
  characterToUpdate = new CharacterAddEditDto();

  constructor(private http: HttpClient, private constants: ConstantsService, private modalService: CharacterModalService) { }
  
  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.http.get(this.constants.apiUrl + 'Character')
      .subscribe({
        next: res => {
          console.log(res);
          this.characters = res as CharacterDto[];
        },
        error: err => console.log(err)
      });
  }

  openModal() {
    this.modalService.showModal();
    this.characterToUpdate = new CharacterAddEditDto();
  }

  openForEdit(character: CharacterDto) {
    this.openModal();
    this.characterToUpdate = { ...character };
  }

  delete(id: number) {
    this.http.delete(this.constants.apiUrl + 'Character/' + id)
      .subscribe({
        next: res => {
          this.getData();
        },
        error: err => console.log(err)
      });
  }
}
