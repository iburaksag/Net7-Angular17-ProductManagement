import { Component } from '@angular/core';
import { CategoryService } from '../../../services/category.service';
import { FormsModule, NgForm } from '@angular/forms';
import { Category } from '../../../models/category.model';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-category-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './category-form.component.html',
  styles: ``
})
export class CategoryFormComponent {
  constructor(public service: CategoryService, private toastr: ToastrService) {

  }

  onSubmit(form: NgForm){
    this.service.categoryFormSubmitted = true
    if(form.valid)
    {
      if(this.service.categoryFormData.Id == "")
        this.insertRecord(form)
      else
        this.updateRecord(form)
    }
  }
  
  insertRecord(form: NgForm){
    this.service.postCategory()
      .subscribe({
        next: res => {
          this.service.categoryList = res as Category[];
          this.service.resetForm(form);
          this.toastr.success('Inserted succesfully', 'Category Register');
        },
        error: err => { console.log(err) }
      })
  }

  updateRecord(form: NgForm){
    this.service.putCategory()
      .subscribe({
        next: res => {
          this.service.categoryList = res as Category[];
          this.service.resetForm(form);
          this.toastr.info('Updated succesfully', 'Category Register');
        },
        error: err => { console.log(err) }
      })
  }

  resetForm() {
    this.service.categoryFormData = new Category();
  }
  
}
