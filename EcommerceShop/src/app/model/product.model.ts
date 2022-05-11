import { Category } from "./category.model";
import { Supplier } from "./supplier.model";

export interface Product{
      id: number;
      name: string;
      price: number;
      priceInput:number;
      sale: number;
      inventory: number;
      insurance: number;
      accessory: string;
      sensor: string;
      imageProcessor: string;
      screen: number;
      iso: string;
      shutterSpeed: string;
      productSummary: string;
      categoryId: 1;
      supplierId: 2;
      viewProduct: 0;
      supplier:Supplier;
      category:Category
}