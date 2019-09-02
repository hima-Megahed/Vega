import { AppErrorHandler } from './app.error-handler';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { BsNavbarComponent } from './components/bs-navbar/bs-navbar.component';
import { VehicleService } from './services/vehicle.service';
import { ToastrModule } from 'ngx-toastr';
import * as Sentry from "@sentry/browser";

Sentry.init({
  dsn: "https://1efdcf0073434cbfb668ec3a837fbc6a@sentry.io/1549121"
});

@NgModule({
  declarations: [
    AppComponent,
    VehicleFormComponent,
    BsNavbarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '*', component: AppComponent, pathMatch: 'full' },
      { path: 'vehicle/new', component: VehicleFormComponent},
      { path: 'vehicle/:id', component: VehicleFormComponent }
    ]),
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler},
    VehicleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
