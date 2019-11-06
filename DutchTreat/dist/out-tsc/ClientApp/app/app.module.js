import { __decorate } from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ProductList } from './shop/productList.component';
import { DataService } from './shared/dataService';
import { HttpClientModule } from '@angular/common/http';
import { Cart } from './shop/cart.component';
import { Shop } from './shop/shop.component';
import { Checkout } from './checkout/checkout.component';
let routes = [
    { path: "", component: Shop },
    { path: "checkout", component: Checkout }
];
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            ProductList,
            Cart,
            Shop,
            Checkout
        ],
        imports: [
            BrowserModule,
            HttpClientModule,
            RouterModule.forRoot(routes, {
                useHash: true,
                enableTracing: false
            })
        ],
        providers: [DataService],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map