import { PhotoService } from './services/photo.service';
import { AppErrorHandler } from './app.error-handler';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { BsNavbarComponent } from './components/bs-navbar/bs-navbar.component';
import { VehicleService } from './services/vehicle.service';
import { ToastrModule } from 'ngx-toastr';
import * as Sentry from "@sentry/browser";
import { VehicleListComponent } from './components/vehicle-list/vehicle-list.component';
import { PaginationComponent } from './components/shared/pagination.component';
import { ViewVehicleComponent } from './components/view-vehicle/view-vehicle.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from './services/auth.service';
import { CallbackComponent } from './components/callback/callback.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AuthGuard } from './guards/auth.guard';
import { InterceptorService } from './services/interceptor.service';
import { AdminAuthGuard } from './guards/admin-auth.guard';

/* Sentry.init({
  dsn: "https://1efdcf0073434cbfb668ec3a837fbc6a@sentry.io/1549121"
}); */

@NgModule({
  declarations: [
    AppComponent,
    VehicleFormComponent,
    BsNavbarComponent,
    VehicleListComponent,
    PaginationComponent,
    ViewVehicleComponent,
    CallbackComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'vehicles', pathMatch: 'full' },
      { path: 'vehicles/new', component: VehicleFormComponent, canActivate: [AdminAuthGuard]},
      { path: 'vehicles/edit/:id', component: VehicleFormComponent, canActivate: [AuthGuard]},
      { path: 'vehicles/:id', component: ViewVehicleComponent },
      { path: 'vehicles', component: VehicleListComponent},
      { path: 'callback', component: CallbackComponent},
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},
    ]),
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgbModule
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler},
    { provide: HTTP_INTERCEPTORS, useClass: InterceptorService, multi: true},
    VehicleService,
    PhotoService,
    AuthService,
    AuthGuard,
    AdminAuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
