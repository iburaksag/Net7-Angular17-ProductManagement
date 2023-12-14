import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { NgForm } from '@angular/forms';
import { environment } from '../../environments/environment';
import { Product } from '../models/product.model';
import { Category } from '../models/category.model';
import { Observable, catchError, throwError } from 'rxjs';
import { NotificationService } from './notification.service';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  url: string = environment.apiBaseUrl + '/products';
  productList: Product[] = [];
  categoryList: Category[] = [];
  productFormData: Product = new Product()
  productFormSubmitted: boolean = false;
  constructor(private http: HttpClient, private notificationService: NotificationService) { }

  refreshList() {
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.productList = res as Product[];
        },
        error: err => { console.log(err) }
      })
  }

  postProduct() {
    return this.http.post(this.url, this.productFormData)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 400) {
            if (error.error && error.error.errors) {
              const validationErrors = error.error.errors;
              for (const key in validationErrors) {
                if (validationErrors.hasOwnProperty(key)) {
                  const errorMessage = validationErrors[key];
                  this.notificationService.showError(errorMessage, 'Validation Error');
                }
              }
            }
          }
          return throwError(error);
        })
      );
  }


  putProduct() {
    return this.http.put(this.url + '/' + this.productFormData.Id, this.productFormData)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 400) {
            if (error.error && error.error.errors) {
              const validationErrors = error.error.errors;
              for (const key in validationErrors) {
                if (validationErrors.hasOwnProperty(key)) {
                  const errorMessage = validationErrors[key] + ' ';
                  this.notificationService.showError(errorMessage, 'Validation Error');
                }
              }
            }
          }
          return throwError(error);
        })
      );
  }

  deleteProduct(id: string) {
    return this.http.delete(this.url + '/' + id);
  }

  getCategories() {
    return this.http.get(environment.apiBaseUrl + '/categories') as Observable<Category[]>;
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.refreshList();
    this.productFormData = new Product();
    this.productFormSubmitted = false;
  }
}
