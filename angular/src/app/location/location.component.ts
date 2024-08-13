import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { LocationAddEditDto, LocationDto } from './location.model';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../constants.service';
import { LocationModalService } from './location-modal/location-modal-service.service';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrl: './location.component.css'
})
export class LocationComponent implements OnInit {
  @ViewChild('locationModal') locationModal: ElementRef | undefined;
  locations: LocationDto[] = [];
  locationToUpdate = new LocationAddEditDto();
  deletionWarningShow = false;

  constructor(private http: HttpClient, private constants: ConstantsService, private modalService: LocationModalService) {}

  ngOnInit(): void {
      this.getData();
  }

  getData() {
    this.http.get(this.constants.apiUrl + 'Location')
      .subscribe({
        next: res => {
          this.locations = res as LocationDto[];
        },
        error: err => console.log(err)
      });
  }

  openModal() {
    this.modalService.showModal();
    this.locationToUpdate = new LocationAddEditDto();
  }

  openForEdit(location: LocationDto) {
    this.openModal();
    this.locationToUpdate = { ...location };
  }

  delete(location: LocationDto) {
    // if (race.characters.length > 0) {
    //   this.deletionWarningShow = true;
    //   setTimeout(() => {
    //     this.deletionWarningShow = false;
    //   }, 5000);

    //   return;
    // }
    this.http.delete(this.constants.apiUrl + 'Location/' + location.id)
      .subscribe({
        next: res => {
          this.getData();
        },
        error: err => console.log(err)
      });
  }
}
