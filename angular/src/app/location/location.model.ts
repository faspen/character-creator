import { CharacterDto } from "../character/character.model";

export class LocationDto {
    id: number = 0;
    name: string = '';
    description: string = '';
    characters: CharacterDto[] = [];
}

export class LocationAddEditDto {
    id: number = 0;
    name: string = '';
    description: string = '';
}
