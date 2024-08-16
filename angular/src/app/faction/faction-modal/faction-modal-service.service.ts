import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FactionModalService {
  private modalVisible = new BehaviorSubject<boolean>(false);
  modalVisible$ = this.modalVisible.asObservable();

  showModal() {
    this.modalVisible.next(true);
  }

  hideModal() {
    this.modalVisible.next(false);
  }
}
