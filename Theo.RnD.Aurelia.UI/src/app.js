import {inject} from 'aurelia-framework';
import {FetchConfig} from 'aurelia-auth';

@inject(FetchConfig)
export class App {

    constructor(fetchConfig)
    {
        this.fetchConfig = fetchConfig;
    }

    activate()
    {
        this.fetchConfig.configure();
    }

  configureRouter(config, router) {
    config.title = 'Aurelia';
    config.map([
      { route: ['', 'welcome'], name: 'welcome',      moduleId: 'welcome',      nav: true, title: 'Welcome'},
      { route: 'users',         name: 'users',        moduleId: 'users',        nav: true, title: 'Github Users' , auth:true  },
      { route: 'customer',         name: 'customer',        moduleId: 'customer',        nav: true, title: 'Customers List' , auth:true  },
      { route: 'child-router',  name: 'child-router', moduleId: 'child-router', nav: true, title: 'Child Router' },
      { route: 'login',        moduleId: 'login',       nav: false, title:'Login' },
        { route: 'logout',        moduleId: 'logout',       nav: false, title:'Logout' }
    ]);
    console.log("Router Configured!!!")
    console.log(router);
    this.router = router;
  }
}
