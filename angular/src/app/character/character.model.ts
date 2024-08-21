import { FactionDto } from "../faction/faction.model";
import { LocationDto } from "../location/location.model";
import { RaceDto } from "../race/race.model";

export class CharacterDto {
    id: number = 0;
    firstName: string = '';
    lastName: string = '';
    age: number = 0;
    sex: Sex = 0;
    height: number = 0;
    hairColor: string = '';
    eyeColor: string = '';
    raceId: number = 0;
    race: RaceDto = new RaceDto();
    factionId: number = 0;
    faction: FactionDto = new FactionDto();
    locationId: number = 0;
    location: LocationDto = new LocationDto();
}

export class CharacterAddEditDto {
    id: number = 0;
    firstName: string = '';
    lastName: string = '';
    age: number = 0;
    sex: Sex = 0;
    height: number = 0;
    hairColor: string = '';
    eyeColor: string = '';
    raceId: number = 0;
    factionId: number = 0;
    locationId: number = 0;
}

export enum Sex {
    NotSelected = 0,
    Male,
    Female
}