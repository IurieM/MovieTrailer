var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
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
var SharedModule = /** @class */ (function () {
    function SharedModule() {
    }
    SharedModule = __decorate([
        NgModule({
            imports: [
                CommonModule,
                FormsModule,
                MaterialModule,
                TranslateModule
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
                ShowErrorComponent,
            ]
        })
    ], SharedModule);
    return SharedModule;
}());
export { SharedModule };
//# sourceMappingURL=shared.module.js.map