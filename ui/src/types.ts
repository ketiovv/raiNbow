export interface Field {
    id: string;
    name: string;
    fieldType: string;
}

export interface Schema {
    id: string;
    name: string;
    fields: Field[];
}