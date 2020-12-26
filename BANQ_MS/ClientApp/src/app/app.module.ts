import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatDialogModule } from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BanqProgramsComponent } from './banq-programs/banq-programs.component';
import { BanqProgramComponent } from './banq-programs/banq-program/banq-program.component';
import { BanqProgramFoodComponent } from './banq-programs/banq-program-food/banq-program-food.component';
import { BanqProgramAmenityComponent } from './banq-programs/banq-program-amenity/banq-program-amenity.component';
import { BanqProgramService } from './shared/banq-program.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FoodComponent } from './food/food.component';
import { FoodCreateComponent } from './food/food-create/food-create.component';
import { FoodListComponent } from './food/food-list/food-list.component';
import { AmenitiesComponent } from './amenities/amenities.component';
import { AmenityListComponent } from './amenities/amenity-list/amenity-list.component';
import { AmenityCreateComponent } from './amenities/amenity-create/amenity-create.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    BanqProgramsComponent,
    BanqProgramComponent,
    BanqProgramFoodComponent,
    BanqProgramAmenityComponent,
    FoodComponent,
    FoodCreateComponent,
    FoodListComponent,
    AmenityCreateComponent,
    AmenitiesComponent,
    AmenityListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    BrowserAnimationsModule,
    MatDialogModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'banq-programs', component: BanqProgramsComponent },
      {
        path: 'banq-program', children: [
          { path: '', component: BanqProgramComponent },
          { path: 'edit/:id', component: BanqProgramComponent },

        ]
      },
      { path: 'food', component: FoodComponent },
      { path: 'amenities', component: AmenitiesComponent },
    ]),
    BrowserAnimationsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }, BanqProgramService
  ],
  entryComponents: [BanqProgramFoodComponent, BanqProgramAmenityComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
