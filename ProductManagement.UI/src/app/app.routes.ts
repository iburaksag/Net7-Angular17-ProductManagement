import { Routes } from '@angular/router';
import { CategoryComponent } from './components/category/category.component';
import { ProductComponent } from './components/product/product.component';

export const routes: Routes = [
    { path: 'category', component: CategoryComponent },
    { path: 'product', component: ProductComponent },
    { path: '', redirectTo: '/product', pathMatch: 'full' },
];