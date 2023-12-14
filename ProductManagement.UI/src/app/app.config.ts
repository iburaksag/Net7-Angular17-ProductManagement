import { ApplicationConfig, enableProdMode, importProvidersFrom } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';
import { NotificationService } from './services/notification.service';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), 
    provideClientHydration(), 
    importProvidersFrom(HttpClientModule, FormsModule, NotificationService),
    provideAnimations(),
    provideToastr()
  ]
};
