import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product'; 

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  // Замените на порт вашего ASP.NET проекта
  private apiUrl = 'https://localhost:7120/api/Products'; 

  constructor(private http: HttpClient) { }

  // Получить все товары
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }

  // Получить один товар по ID
  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }
}