export interface CreateCustomerRequest {
    name: string;
    age?: number;
    cpfcnpj: string;
    ie?: string;
    ieIsento: boolean;
    telephone: string;
    email: string;
    cep: string;
    address: string;
    number: number;
    district: string;
    city: string;
    state: string;
}

export interface CreateCustomerResponse {
    name: string;
    age?: number;
    cpfcnpj: string;
    ie?: string;
    ieIsento: boolean;
    telephone: string;
    email: string;
    cep: string;
    address: string;
    number: number;
    district: string;
    city: string;
    state: string;
    id: string;
}