import { Component, EventEmitter, Input, OnDestroy, OnInit, Output, Renderer2, ViewChild } from '@angular/core';
import { CharacterModalService } from './character-modal-service.service';
import { Subscription } from 'rxjs';
import { CharacterAddEditDto, CharacterDto, RelationshipAddEditDto, RelationshipType, Sex } from '../character.model';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../../constants.service';
import { NgForm } from '@angular/forms';
import { RaceDto } from '../../race/race.model';
import { LocationDto } from '../../location/location.model';
import { FactionDto } from '../../faction/faction.model';

class SexOption {
  name: string = '';
  value: Sex = 0;
  disabled: boolean = false;
}

class RelationshipOption {
  name: string = '';
  value: RelationshipType = 1;
}

@Component({
  selector: 'app-character-modal',
  templateUrl: './character-modal.component.html',
  styleUrl: './character-modal.component.css'
})
export class CharacterModalComponent implements OnInit, OnDestroy {
  @ViewChild('characterForm') characterForm: NgForm | undefined;
  @Input() characterDto = new CharacterAddEditDto();
  @Input() characterData: CharacterDto[] = [];
  @Output() refreshData: EventEmitter<any> = new EventEmitter<any>();
  races: RaceDto[] = [];
  locations: LocationDto[] = [];
  factions: FactionDto[] = [];
  modalVisible = false;
  defaultRace: RaceDto = { id: 0, name: 'Select race', description: '', characters: [] };
  defaultLocation: LocationDto = { id: 0, name: 'Select location', description: '', characters: [] };
  defaultFaction: FactionDto = { id: 0, name: 'Select faction', description: '', characters: [] };
  subscription!: Subscription;
  backdrop: HTMLElement | null = null;
  sexOptions: SexOption[] = [
    { name: 'Select sex', value: 0, disabled: true },
    { name: 'Male', value: 1, disabled: false },
    { name: 'Female', value: 2, disabled: false }
  ];
  relationshipOptions: RelationshipOption[] = [
    { name: 'Acquaintance', value: RelationshipType.Acquaintance },
    { name: 'Ally', value: RelationshipType.Ally },
    { name: 'Friend', value: RelationshipType.Friend },
    { name: 'Lover', value: RelationshipType.Lover },
    { name: 'Spouse', value: RelationshipType.Spouse },
    { name: 'Rival', value: RelationshipType.Rival },
    { name: 'Enemy', value: RelationshipType.Enemy },
    { name: 'Sibling', value: RelationshipType.Sibling }
  ];

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
    this.getRaces();
    this.getLocations();
    this.getFactions();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  getRaces() {
    this.http.get(this.constants.apiUrl + 'Race')
      .subscribe({
        next: res => {
          this.races = res as RaceDto[];
          this.races = [this.defaultRace].concat(this.races);
        },
        error: err => console.log(err)
      });
  }

  getLocations() {
    this.http.get(this.constants.apiUrl + 'Location')
      .subscribe({
        next: res => {
          this.locations = res as LocationDto[];
          this.locations = [this.defaultLocation].concat(this.locations);
        },
        error: err => console.log(err)
      });
  }

  getFactions() {
    this.http.get(this.constants.apiUrl + 'Faction')
      .subscribe({
        next: res => {
          this.factions = res as RaceDto[];
          this.factions = [this.defaultFaction].concat(this.factions);
        },
        error: err => console.log(err)
      });
  }

  addRelationship() {
    this.characterDto.relationshipsAsFirst.push({
      id: 0,
      firstCharacterId: this.characterDto.id,
      secondCharacterId: 0,
      relationshipType: 1
    });
  }

  closeModal() {
    this.characterForm?.resetForm();
    this.modalService.hideModal();
  }

  save() {
    this.characterDto.sex = Number(this.characterDto.sex);
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
