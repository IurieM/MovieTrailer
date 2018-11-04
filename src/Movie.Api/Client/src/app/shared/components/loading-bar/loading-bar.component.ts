import { Component, OnInit, OnDestroy } from '@angular/core';
import { LoadingBarService } from './loading-bar.service';

@Component({
    selector: 'loading-bar',
    template: '<div [hidden]="!visible"><mat-progress-bar mode="indeterminate"></mat-progress-bar></div>',
    styles: ['mat-progress-bar { position: fixed; z-index:1000 }']
})
export class LoadingBarComponent implements OnInit, OnDestroy {
    visible = false;
    constructor(private loadingBarService: LoadingBarService) {
    }

    ngOnInit() {
        if (this.loadingBarService) {
            this.loadingBarService.onStart.subscribe(() => this.start());
            this.loadingBarService.onStop.subscribe(() => this.stop());
        }
    }

    ngOnDestroy() {
        if (this.loadingBarService) {
            this.loadingBarService.onStart.unsubscribe();
            this.loadingBarService.onStop.unsubscribe();
        }
    }

    start() {
        this.visible = true;
    }

    stop() {
        this.visible = false;
    }
}