import {inject} from 'aurelia-framework';
import {AuthService} from 'aurelia-auth';

@inject(AuthService)
export class login {
    constructor(auth) {
        this.auth = auth;
    }

    heading = 'Login';

    authenticate(name){
        return this.auth.authenticate(name,false,null)
        .then((response)=>{
            console.log(" auth response --> ");
            console.log(response);
            console.log("this.auth.isAuthenticated();")
            console.log(this.auth.isAuthenticated())
        });
    }
}