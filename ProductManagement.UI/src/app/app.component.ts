import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { CategoryComponent } from "./components/category/category.component";
import { ProductComponent } from "./components/product/product.component";
import { NavbarComponent } from "./components/navbar/navbar.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styles: [],
    imports: [CommonModule, RouterOutlet, CategoryComponent, ProductComponent, NavbarComponent, RouterOutlet]
})
export class AppComponent {
  title = 'ProductManagement.UI';
}
