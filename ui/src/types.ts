export interface Field {
    name: string;
    fieldTypeId: number;
}

export interface Schema {
    name: string;
    fields: Field[];
}