import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CharacterComponent } from './character/character.component';
import { FactionComponent } from './faction/faction.component';
import { LocationComponent } from './location/location.component';

const routes: Routes = [
  { path: 'characters', component: CharacterComponent },
  { path: 'factions', component: FactionComponent },
  { path: 'locations', component: LocationComponent },
  { path: '', redirectTo: '/characters', pathMatch: 'full' },
  { path: '**', redirectTo: '/characters' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
