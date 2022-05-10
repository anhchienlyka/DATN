import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top/top-bar/top-bar.component';
import { NavComponent } from './top/nav/nav.component';
import { BottomBarComponent } from './top/bottom-bar/bottom-bar.component';
import { MainBannerComponent } from './body/main-banner/main-banner.component';
import { NavBarComponent } from './top/nav-bar/nav-bar.component';
import { BannerComponent } from './body/banner/banner.component';
import { BrandComponent } from './body/brand/brand.component';
import { FeatureComponent } from './body/feature/feature.component';
import { CategoryComponent } from './body/category/category.component';
import { CallToActionComponent } from './body/call-to-action/call-to-action.component';
import { FeaturedProductComponent } from './body/featured-product/featured-product.component';
import { NewsletterComponent } from './body/newsletter/newsletter.component';
import { RecentProductComponent } from './body/recent-product/recent-product.component';
import { ReviewComponent } from './body/review/review.component';
import { FooterComponent } from './bottom/footer/footer.component';
import { FooterBottomComponent } from './bottom/footer-bottom/footer-bottom.component';
import { BestSellingComponent } from './body/best-selling/best-selling.component';
import { NewArrivalsComponent } from './body/new-arrivals/new-arrivals.component';
import { ProductsComponent } from './body/products/products.component';
import { ProductDetailComponent } from './body/product-detail/product-detail.component';
import { CartComponent } from './body/cart/cart.component';
import { CheckoutComponent } from './body/checkout/checkout.component';
import { WishListComponent } from './body/wish-list/wish-list.component';
import { MyaccountComponent } from './body/myaccount/myaccount.component';
import { LoginComponent } from './body/login/login.component';
import { RegisterComponent } from './body/register/register.component';
import { MainTopComponent } from './top/main-top/main-top.component';
import { MainBodyComponent } from './body/main-body/main-body.component';
import { MainFooterComponent } from './bottom/main-footer/main-footer.component';
import { HomeComponent } from './body/home/home.component';
import { BreadcrumbComponent } from './body/breadcrumb/breadcrumb.component';
import { SidebarComponent } from './body/sidebar/sidebar.component';
import { SidebarCatComponent } from './body/sidebar-cat/sidebar-cat.component';
import { SidebarSliderComponent } from './body/sidebar-slider/sidebar-slider.component';
import { SidebarBrandsComponent } from './body/sidebar-brands/sidebar-brands.component';
import { SidebarTagComponent } from './body/sidebar-tag/sidebar-tag.component';
import { ContactusComponent } from './body/contactus/contactus.component';
import { BodyComponent } from './body/body.component';
import { BottomComponent } from './bottom/bottom.component';
import { TopComponent } from './top/top.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProductInHomeComponent } from './body/product-in-home/product-in-home.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { AdminModule } from './admin/admin.module';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { CompletedComponent } from './body/completed/completed.component';
import { SwiperModule } from "swiper/angular";


@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    NavComponent,
    BottomBarComponent,
    MainBannerComponent,
    NavBarComponent,
    BannerComponent,
    BrandComponent,
    FeatureComponent,
    CategoryComponent,
    CallToActionComponent,
    FeaturedProductComponent,
    NewsletterComponent,
    RecentProductComponent,
    ReviewComponent,
    FooterComponent,
    FooterBottomComponent,
    BestSellingComponent,
    NewArrivalsComponent,
    ProductsComponent,
    ProductDetailComponent,
    CartComponent,
    CheckoutComponent,
    WishListComponent,
    MyaccountComponent,
    LoginComponent,
    RegisterComponent,
    MainTopComponent,
    MainBodyComponent,
    MainFooterComponent,
    HomeComponent,
    BreadcrumbComponent,
    SidebarComponent,
    SidebarCatComponent,
    SidebarSliderComponent,
    SidebarBrandsComponent,
    SidebarTagComponent,
    ContactusComponent,
    BodyComponent,
    BottomComponent,
    TopComponent,
    ProductInHomeComponent,
    UserLayoutComponent,
    CompletedComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    NgxPaginationModule,
    AdminModule,
    SwiperModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
