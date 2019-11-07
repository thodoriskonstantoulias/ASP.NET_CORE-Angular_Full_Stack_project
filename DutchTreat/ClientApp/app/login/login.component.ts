import { Component } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';

@Component({
	selector: "login",
	templateUrl : "login.component.html"
})

export class Login {
	constructor(private data: DataService, private router: Router) {
	}
	errorMessage: string = "";
	public creds = {
		username : "",
		password : ""
	};

	onLogin() {
		this.data.login(this.creds).subscribe(success => {
			if (success) {
				console.log("SUCCESS");
				if (this.data.order.items.length == 0) {
					console.log("NOT FOUND ITEMS SO GO BACK TO SHOP");
					this.router.navigate([""]);
				} else {
					console.log("FOUND ITEMS SO GO BACK TO CHECKOUT");
					console.log(this.data.order.items);
					this.router.navigate(["checkout"]);
				}
			}
		}, err => this.errorMessage = "Failed to login!");
	}
}