import { __decorate } from "tslib";
import { Component } from '@angular/core';
let Login = class Login {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.errorMessage = "";
        this.creds = {
            username: "",
            password: ""
        };
    }
    onLogin() {
        this.data.login(this.creds).subscribe(success => {
            if (success) {
                console.log("SUCCESS");
                if (this.data.order.items.length == 0) {
                    console.log("NOT FOUND ITEMS SO GO BACK TO SHOP");
                    this.router.navigate([""]);
                }
                else {
                    console.log("FOUND ITEMS SO GO BACK TO CHECKOUT");
                    console.log(this.data.order.items);
                    this.router.navigate(["checkout"]);
                }
            }
        }, err => this.errorMessage = "Failed to login!");
    }
};
Login = __decorate([
    Component({
        selector: "login",
        templateUrl: "login.component.html"
    })
], Login);
export { Login };
//# sourceMappingURL=login.component.js.map