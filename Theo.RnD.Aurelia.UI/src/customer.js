import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class customer {
    heading = 'List Customers';
    customers = [];

    constructor(http) {
        http.configure(config => {
            config
              .useStandardConfiguration()
              .withBaseUrl('http://localhost:10012/api/');
        });

        this.http = http;
    }

    activate() {
        return this.http.fetch('customer')
          .then(response => response.json())
          .then(customers => this.customers = customers);
    }
}
