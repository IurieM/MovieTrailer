import { NgModule } from '@angular/core';
import {
    MatCardModule, MatIconModule, MatInputModule,
    MatButtonModule, MatListModule, MatSnackBarModule, MatTooltipModule, MatProgressBarModule
} from '@angular/material';

@NgModule({
    imports: [MatCardModule, MatIconModule, MatInputModule,
        MatButtonModule, MatListModule, MatSnackBarModule, MatTooltipModule, MatProgressBarModule],
    exports: [MatCardModule, MatIconModule, MatInputModule,
        MatButtonModule, MatListModule, MatSnackBarModule, MatTooltipModule, MatProgressBarModule],
})
export class MaterialModule { }
