export interface UpdateCustomerRequest {
    name: string;
    age: number;
    cpfcnpj: string;
    ie?: any;
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

export interface UpdateCustomerResponse {
    name: string;
    age: number;
    cpfcnpj: string;
    ie?: any;
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