import {inject} from 'aurelia-framework';
import {AuthService} from 'aurelia-auth';

@inject(AuthService)
export class logout {
    constructor(auth) {
        this.auth = auth;
    }

    activate(){
        this.auth.logout("#/login")
        .then(response => { console.log("Logged out sucessfully from logout.js"); })
        .catch(err=> { console.log("Error in logging out from Logout.js"); });
    }
}