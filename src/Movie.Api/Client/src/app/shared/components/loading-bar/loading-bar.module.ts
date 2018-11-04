import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatProgressBarModule } from '@angular/material';
import { LoadingBarService } from 'src/app/shared/components/loading-bar/loading-bar.service';
import { LoadingBarComponent } from './loading-bar.component';


@NgModule({
    imports: [CommonModule, MatProgressBarModule],
    providers: [LoadingBarService],
    declarations: [LoadingBarComponent],
    exports: [LoadingBarComponent]
})

export class LoadingBarModule { }
