import { Routes } from '@angular/router';
import { ProductListComponent } from './pages/product-list.component/product-list.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'product-list',
        pathMatch: 'full'
    },
    {
        path: 'product-list',
        component: ProductListComponent
    }
];
