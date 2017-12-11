import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { ProductService } from'../service/product.service';
import { Product } from "../../model/product";


@Component({
    selector: 'product',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class ProductComponent {

    products: Product[];

    constructor( private productService: ProductService) {

       

    }


 ngOnInit() {
       this.productService.getProduct().subscribe(x=>this.products=x);
    }
}
