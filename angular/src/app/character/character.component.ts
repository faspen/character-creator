import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../constants.service';
import { CharacterDto } from './character.model';

@Component({
  selector: 'app-character',
  templateUrl: './character.component.html',
  styleUrl: './character.component.css'
})
export class CharacterComponent implements OnInit {
  characters: CharacterDto[] = [];

  constructor(private http: HttpClient, private constants: ConstantsService) { }
  
  ngOnInit(): void {
    console.log('Welcome to character screen.');
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

  logCharacters() {
    console.log('CHARACTERS: ', this.characters);
  }
}
