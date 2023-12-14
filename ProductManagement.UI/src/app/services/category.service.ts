import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { NgForm } from '@angular/forms';
import { environment } from '../../environments/environment';
import { Category } from '../models/category.model';
import { forkJoin, map, mergeMap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {
  url: string = environment.apiBaseUrl + '/categories';
  categoryList: Category[] = [];
  categoryFormData: Category = new Category()
  categoryFormSubmitted:boolean = false;
  constructor(private http : HttpClient) { }

  refreshList(){
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.categoryList = res as Category[];
        },
        error: err => { console.log(err)}
      })
  }

  postCategory(){
    return this.http.post(this.url, this.categoryFormData);
  }

  putCategory() {
    return this.http.put(this.url + '/' + this.categoryFormData.Id, this.categoryFormData);
  }

  deleteCategory(id:string) {
    return this.http.delete(this.url + '/' + id);
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.refreshList();
    this.categoryFormData = new Category();
    this.categoryFormSubmitted = false;
  }

}
