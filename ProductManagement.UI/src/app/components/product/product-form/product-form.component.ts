import { Component } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { FormsModule, NgForm } from '@angular/forms';
import { Product } from '../../../models/product.model';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { Category } from '../../../models/category.model';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './product-form.component.html',
  styles: ``
})
export class ProductFormComponent {
  constructor(public service: ProductService, private toastr: ToastrService) {
    this.fetchCategories();
  }

  onSubmit(form: NgForm) {
    this.service.productFormSubmitted = true
    if (form.valid) {
      if (this.service.productFormData.Id == "")
        this.insertRecord(form)
      else
        this.updateRecord(form)
    }
  }

  insertRecord(form: NgForm) {
    this.service.postProduct()
      .subscribe({
        next: res => {
          this.service.productList = res as Product[];
          this.service.resetForm(form);
          this.toastr.success('Inserted succesfully', 'Product Register');
        },
        error: err => { console.log(err) }
      })
  }

  updateRecord(form: NgForm) {
    this.service.putProduct()
      .subscribe({
        next: res => {
          this.service.productList = res as Product[];
          this.service.resetForm(form);
          this.toastr.info('Updated succesfully', 'Product Register');
        },
        error: err => { console.log(err) }
      })
  }

  fetchCategories() {
    this.service.getCategories()
    .subscribe((categories: Category[]) => {
      this.service.categoryList = categories;
    });
  }

  resetForm() {
    this.service.productFormData = new Product();
  }

}
