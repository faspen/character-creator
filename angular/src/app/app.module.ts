import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CharacterComponent } from './character/character.component';
import { FactionComponent } from './faction/faction.component';
import { LocationComponent } from './location/location.component';
import { HttpClientModule } from '@angular/common/http';
import { CharacterModalComponent } from './character/character-modal/character-modal.component';
import { FormsModule } from '@angular/forms';
import { RaceComponent } from './race/race.component';
import { RaceModalComponent } from './race/race-modal/race-modal.component';
import { LocationModalComponent } from './location/location-modal/location-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    CharacterComponent,
    FactionComponent,
    LocationComponent,
    CharacterModalComponent,
    RaceComponent,
    RaceModalComponent,
    LocationModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
