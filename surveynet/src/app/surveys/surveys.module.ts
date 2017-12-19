import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './components/list/list.component';
import {SharedModule} from "../shared/shared.module";

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [ListComponent]
})
export class SurveysModule { }
