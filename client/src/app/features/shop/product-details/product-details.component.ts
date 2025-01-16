import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../../core/services/shop.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../../shared/models/product';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { MatDivider } from '@angular/material/divider';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-product-details',
  imports: [CurrencyPipe, MatDivider, CommonModule, MatIcon],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss',
})
export class ProductDetailsComponent implements OnInit {
  private shopService = inject(ShopService);
  private activatedRoute = inject(ActivatedRoute);
  product?: Product;
  isVisible = false;
  isContentReady: boolean = false;

  ngOnInit(): void {
    this.loadProduct();

    setTimeout(() => {
      this.isVisible = true;
    }, 500);

    setTimeout(() => {
      this.isContentReady = true;
    }, 100);
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.shopService.getProduct(+id).subscribe({
      next: (product) => (this.product = product),
      error: (error) => console.log(error),
    });
  }
}
