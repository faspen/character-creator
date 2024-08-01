import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ConstantsService {
  readonly apiUrl: string = 'http://localhost:5058/api/'; // Replace with your actual API URL

  constructor() { }
}
