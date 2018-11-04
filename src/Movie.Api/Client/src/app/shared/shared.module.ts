import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './interceptors/error-interceptor';
import { MaterialModule } from '../material.module';
import { AlertService } from './services/alert-service';
import { ShowErrorComponent } from './components/show-error/show-error.component';
import { TranslateModule } from './pipes/translate/transalte.module';
import { CommonService } from './services/common.service';
import { LoadingBarModule } from './components/loading-bar/loading-bar.module';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    TranslateModule,
    LoadingBarModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AlertService,
    CommonService
  ],
  declarations: [
    ShowErrorComponent,
  ],
  exports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    TranslateModule,
    LoadingBarModule,
    ShowErrorComponent,
  ]
})
export class SharedModule { }
