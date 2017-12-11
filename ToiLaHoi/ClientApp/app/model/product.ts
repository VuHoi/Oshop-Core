


export interface Product {
    Id: number;
    Categories: Categories;

    Price: number;
    ImageUrl:string;
    Title: string;

}

export interface SaveProduct {
    Id: number;
    CategoriesId: string;

    Price: number;
    ImageUrl: string;
    Title: string;

}


export interface Categories {
    Name: string;
    Detail: string;
    Native: string;
    Id:number;
}



