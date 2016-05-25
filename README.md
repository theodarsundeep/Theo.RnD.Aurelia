# Theo.RnD.Aurelia
My Learning and RnD on the Awesome Aurelia frame work. 

(Still work in progress, Haave lot of things in my mind that I want to try out... So staay tunedd to thiss repo. Look into read me file of each project for details on the implementation)

I have been using the Aurelia Framework (http://aurelia.io) for sometime noww and I have been a great fan of this fraamework , Below are some of the points from the creators of Aurelia and how it standss out from the rest of the SPA crowd liek Angular , react etc...

### Key Highlightss of Aurelia
* Aurelia is a medium size framework, smaller than many others and with no external dependencies.
* Aurelia is as fast or faster than all other frameworks.
* Aurelia is more standards compliant than most other frameworks. (Only Polymer is at the same level.)
* Aurelia is the most unobstrusive framework today. There is nothing that even comes close to comparing.
* Aurelia integrates very well with other libraries. Other frameworks like Angular and React have a harder time with this.
* Aurelia has the best support for separated presentation patterns (MVC, MVVM, MVP) of any modern framework.
* Aurelia is better at dynamic, data-driven UI construction than anything else today.
* It is the only framework written in 100% ES 2015/2016 with no dependencies except polyfills. (At least that we are aware of.)
* Aurelia has no unnecessary DOM abstractions. So, it can be faster than and consume less memory than other frameworks.
* Aurelia has some of the best support for Web Components. (2nd to Polymer but when our new webcomponents plugin is released in a few weeks, we will be on equal ground with them.)
* Aurelia is the only framework built with a modern, modular architecture.

The List could go on and on. Here's a couple of links on the official Aurelia Docs.

Tech Benefits: http://aurelia.io/docs.html#/aurelia/framework/1.0.0-beta.1.1.1/doc/article/technical-benefits
Business Advantages: http://aurelia.io/docs.html#/aurelia/framework/1.0.0-beta.1.1.1/doc/article/business-advantages

### Aurelia Vs Angular 2
* Aurelia is a much smaller library. Angular 2 is 750k minified and that does not include a router, animation or http client. That's not something anyone should ever think of going to production with ever. Aurela is 350k minified and that does include a router, animation and an http client. If you are targeting modern browsers and don't need all the polyfills we provide, you can even reduce that size by up to another 100k.
* In the independent dbmonster re-paint rendering benchmark, Aurelia is as fast or faster than Angular 2. With our upcoming ui-virtualization plugin, it's almost 2x as fast as Angular 2.
* Aurelia is standards compliant; Angular 2 is not. See the other AMA answer for details.
*  Aurelia better supports separated presentation patterns such as MVVM. MVC and MVP. In Aurelia, there is a clean separation between views and view-models; all responsibilities are in their proper place. In Angular 2, you have to configure your view-model with internal implementation details of the view, thus breaking encapsulation and making it difficult or impossible to re-use view-models or views. It also greatly increases maintenance cost and makes it harder for teams of developers to work in parallel on components.
* Aurelia is very unobtrusive. For the most part you write plain ES 2016 or TypeScript code. You don't see the framework very much or at all in your JavaScript code. It stays out of the way. This is extremely important for the longevity and maintenance of your code, as well as learnability and readability. Angular 2, in contrast, must be imported everywhere and its metadata is required throughout your code. It's very configuration heavy, just as much as Angular 1, only the configuration looks different.
* Aurelia is more interoperable with other libraries than Angular 2 because we don't use a digest or abstract the DOM unnuecessarily. The closer a framework stays to standards and the more out of the way it stays, the more interoperable it will be.
* Finally, Aurelia is backed by Durandal Inc. The sole purpose of the company is to build Aurelia, its ecosystem and to support it. On the other hand, Angular 2 is one of six competing UI frameworks inside of Google. Each one desires to make themselves look like the "Google blessed stack" but none of them are. In reality, Google official does not back or support any of these libraries. They are open source side-projects of the various teams that build them. In the case of Angular 2, it's built by the Green Tea team, whose real job is to build an internal CRM-type application.

### Aurelia Vs React
* React is a smaller library than Aurelia, so they've got us beat on size. But, that's not entirely accurate because React is only a view engine and in most cases developers end up adding lots of 3rd party libraries together to create their homegrown framework. In this case, it's possible to end up with infrastructure code that is larger than Aurelia. Also, the developer has to maintain the sometimes tenuous connections between the libraries they have chosen. Aurelia gives you a complete platfrom, out of the box, so you don't need to worry about that as much.
* In the independent dbmonster re-paint rendering benchmark, Aurelia is about twice as fast as React. With our upcoming ui-virtualization plugin, it's almost 4x as fast as React.
* Aurelia is standards compliant; React is not. Basically, you have to adopt jsx which is neither standards compliant JS nor does it use standards compliant HTML (it has different properties and casing rules).
* Aurelia supports separated presentation patterns such as MVVM, MVC and MVP. React provides only the view layer, so you must implement these yourself. Typically, I've found that React developers don't do a good job of this and wind up not following separated presentation patterns at all.
* Aurelia is very unobtrusive. React is utterly intrusive. It uses a different language and infects the code of every component and screen.
* Aurelia is more interoperable with other libraries than React because we don't abstract the DOM unnecessarily. The closer a framework stays to standards and the more out of the way it stays, the more interoperable it will be. Usually, React developers have to rebuild just about everything. It's difficult to use jQuery or 3rd party widgets not specifically designed for React. This creates silos within the web which isn't good. Frameworks should be designed to interoperate.
* Finally, Aurelia is backed by Durandal Inc. The sole purpose of the company is to build Aurelia, its ecosystem and to support it. On the other hand, when asking a React team developer about Fracebook's committement to React they said "Facebook isn't committed to React. We are committed to some of its ideas, but not to the library." It's an open source project within FB that has no connection to their business model. It's replaceable like anything else and it's probably not up to the developers who work on it if and when that will happen.
