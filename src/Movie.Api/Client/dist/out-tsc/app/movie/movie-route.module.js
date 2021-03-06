var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { MovieListComponent } from "./components/movie-list/movie-list.component";
var routes = [
    { path: '', component: MovieListComponent },
];
var MovieRoutingModule = /** @class */ (function () {
    function MovieRoutingModule() {
    }
    MovieRoutingModule = __decorate([
        NgModule({
            exports: [RouterModule],
            imports: [RouterModule.forChild(routes)]
        })
    ], MovieRoutingModule);
    return MovieRoutingModule;
}());
export { MovieRoutingModule };
//# sourceMappingURL=movie-route.module.js.map