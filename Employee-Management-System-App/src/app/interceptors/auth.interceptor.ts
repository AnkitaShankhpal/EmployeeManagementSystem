import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Define routes where token is not needed
    const excludedUrls = ['/api/Account/Login']; // Add more endpoints if needed

    // Check if the request URL is one of the excluded URLs
    if (excludedUrls.some(url => request.url.includes(url))) {
      // If it's an excluded URL, skip adding the token
      return next.handle(request);
    }

    // Get the token from localStorage or sessionStorage
    const token = localStorage.getItem('token');

    // If token exists, clone the request and add the Authorization header
    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    // Forward the request to the next handler
    return next.handle(request);
  }
}
