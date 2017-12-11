import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { SaveProduct } from '../../model/product';


@Injectable()
export class ProductService {
   Url :string;
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.Url = baseUrl;
    }
    getProduct() {
        return this.http.get(this.Url + '/api/products/')
            .map(res => res.json());

    }


}