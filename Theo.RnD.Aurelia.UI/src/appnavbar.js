import {bindable } from 'aurelia-framework';
import {inject} from 'aurelia-framework';
import {AuthService} from 'aurelia-auth';
import {BindingEngine} from 'aurelia-framework'; 

@inject(AuthService, BindingEngine)
export class appnavbar {
    _isAuthenticated = false;
    displayName = "";
    @bindable router = null;
    subscription = {};
    
    constructor(auth, bindingEngine) {
        this.auth = auth;
        this.bindingEngine = bindingEngine;
        this._isAuthenticated = this.auth.isAuthenticated();
        console.log("constructor called - in Navbaar before this.subscription");
        this.subscription = bindingEngine.propertyObserver(this, 'isAuthenticated')
                .subscribe((newValue, oldValue) => {
                    if (this.isAuthenticated) {
                        console.log("this.isAuthenticated --> " + this.isAuthenticated);
                        this.auth.getMe().then(data => { return this.displayName = data.name; console.log('this.auth.getMe().then'); console.log(data); });
                    }
                });
        console.log("in Navbaar after this.subscription");
    }

    get isAuthenticated() 
    {
        return this.auth.isAuthenticated();
    }

    deactivate()
    {
        this.subscription.dispose();
    }
}

