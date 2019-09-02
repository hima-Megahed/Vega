import { ErrorHandler, Inject, NgZone, isDevMode } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import * as Sentry from "@sentry/browser";

export class AppErrorHandler implements ErrorHandler {
    constructor(@Inject(NgZone) private ngZone: NgZone, @Inject(ToastrService) private toastr: ToastrService) {
    }

    handleError(error: any): void {
        this.ngZone.run(() => {
            this.toastr.error("Unexpected error has occured", "Error");
            if(!isDevMode){
                const eventId = Sentry.captureException(error.originalError || error);
                Sentry.showReportDialog({ eventId });
            }
            else
                throw error;
            
        });

    }

}