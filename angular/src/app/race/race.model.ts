import { CharacterDto } from "../character/character.model";

export class RaceDto {
    id: number = 0;
    name: string = '';
    description: string = '';
    characters: CharacterDto[] = [];
}

export class RaceAddEditDto {
    id: number = 0;
    name: string = '';
    description: string = '';
}