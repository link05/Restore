export interface BacksetItem {
    productId:  number;
    name:       string;
    price:      number;
    pictureUrl: string;
    brand:      string;
    type:       string;
    quantity:   number;
}
export interface Basket {
    id:      number;
    buyerId: string;
    items:   BacksetItem[];
}

