import { Injectable, EventEmitter } from "@angular/core";

@Injectable()
export class LoadingBarService {

    onStart = new EventEmitter();
    onStop = new EventEmitter();

    start() {
        this.onStart.emit(undefined);
    }

    stop() {
        this.onStop.emit(undefined);
    }
}