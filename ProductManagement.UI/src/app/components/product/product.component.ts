import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductFormComponent } from "./product-form/product-form.component";
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product',
  standalone: true,
  templateUrl: './product.component.html',
  styles: ``,
  imports: [ProductFormComponent, CommonModule]
})
export class ProductComponent implements OnInit {
  constructor(public service: ProductService, private toastr: ToastrService) {

  }
  
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Product) {
    this.service.productFormData = Object.assign({}, selectedRecord);
  }

  onDelete(id: string) {
    if (confirm('Are you sure to delete this product?')) {
      this.service.deleteProduct(id)
        .subscribe({
          next: res => {
            this.service.productList = res as Product[];
            this.service.refreshList();
            this.toastr.error('Deleted succesfully', 'Product Register');
          },
          error: err => { console.log(err) }
        })
    }
  }

  getCategoryName(categoryId: string): string {
    const category = this.service.categoryList.find((c) => c.Id === categoryId);
    return category ? category.Name : 'Deleted Category';
  }

}
