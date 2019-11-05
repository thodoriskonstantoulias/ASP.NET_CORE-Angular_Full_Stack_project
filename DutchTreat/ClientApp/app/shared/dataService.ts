import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Product } from './product';

@Injectable()

export class DataService {

	constructor(private http: HttpClient) {
	}
	public products: Product[] = [];

	loadProducts(): Observable<boolean> {
		return this.http.get("/api/products")
			.pipe(
				map((data: any[]) => {
					this.products = data;
					return true;
				}));
	}
} 