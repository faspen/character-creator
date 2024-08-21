import { CharacterDto } from "../character/character.model";

export class FactionDto {
    id: number = 0;
    name: string = '';
    description: string = '';
    characters: CharacterDto[] = [];
}

export class FactionAddEditDto {
    id: number = 0;
    name: string = '';
    description: string = '';
}
