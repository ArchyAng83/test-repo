import { Component, OnInit, signal } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-product-list',
  imports: [CommonModule, CurrencyPipe],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css',
})
export class ProductListComponent implements OnInit {
  products = signal<Product[]>([]);

  constructor(private productService: ProductService) {}

ngOnInit(): void {
    this.productService.getProducts().subscribe({
      next: (data) => {
        this.products.set(data); // Обновляем сигнал
      }
    });
  }
  /*  products$: Observable<Product[]>;

  constructor(private productService: ProductService) {
    // Просто присваиваем вызов метода переменной
    this.products$ = this.productService.getProducts();

  }*/
}
