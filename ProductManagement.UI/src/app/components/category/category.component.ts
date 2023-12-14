import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryFormComponent } from "./category-form/category-form.component";
import { CategoryService } from '../../services/category.service';
import { Category } from '../../models/category.model';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-category',
    standalone: true,
    templateUrl: './category.component.html',
    styles: ``,
    imports: [CategoryFormComponent, CommonModule]
})
export class CategoryComponent implements OnInit {
    constructor(public service: CategoryService, private toastr: ToastrService) {
        
    }
    ngOnInit(): void {
        this.service.refreshList();
    }

    populateForm(selectedRecord:Category){
        this.service.categoryFormData = Object.assign({}, selectedRecord);
    }

    onDelete(id:string) {
        if(confirm('Are you sure to delete this category?'))
        {
            this.service.deleteCategory(id)
                .subscribe({
                    next: res => {
                        this.service.categoryList = res as Category[];
                        this.service.refreshList();
                        this.toastr.error('Deleted succesfully', 'Category Register');
                    },
                    error: err => { console.log(err) }
                })
        }
    }

}
