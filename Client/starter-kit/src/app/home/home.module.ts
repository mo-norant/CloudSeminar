import { GameService } from './game.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { AgmCoreModule } from '@agm/core';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule, TranslateModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAu5gA5PSD9SueivXhW_0VQvPKgFJ6oy7M'
    }),
    FormsModule,
     CoreModule, SharedModule, HomeRoutingModule],
  declarations: [HomeComponent],
  providers: [GameService]
})
export class HomeModule {}
