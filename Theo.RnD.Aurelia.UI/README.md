# Theo.RnD.Aurelia.UI

This is a copy of the ASP.NET Core application setup taken from the Producction setup section of the Aurelia Docs http://aurelia.io/docs.html#/aurelia/framework/1.0.0-beta.1.2.2/doc/article/a-production-setup

####First Step - Get the Aurelia.UI working : 

* Before the Build I have renamed the project and the solution details have added the "skeleton_navigation_es2016_vs" project found in the default zip to my ssolution and renamed the application according to my application choise  in this case "Theo.RnD.Aurelia.UI"

* Change the default namespace also to "Theo.RnD.Aurelia.UI" in the project properties.

* Next follow the steps give at the site and set up the project. to install all  the NPM & JSPM packages.

* Changed the connection string to point to my local "SQLEXPRESS" --> Dont ask why I like it this way than the default one "MY WISH" !!! ;-) [ Not used at this point will use it when we start the Auth  using IdentityServer4]

* Used the "Web" command had to change the port to 9001 though as the default 9000 was used by the gulp watch.

#####BOOM BOOM!! Got the Aurelia UI application up  and runing .. You might say "Nothing Great!!" at this point But I take  pride in accomplishing even simple things also "MY WISH" !!! ;-)

THis application loads teh SPA with routhing, binding annd http calls as explained in teh getting started docs. Will keep them as is and try to add more interesting stuff with Auth ussing the IdentityServer4 in to the ad for our RnD. 

lets see if Theo suceeds in the next steps.

####Second Step - Getting the Auth working using IdentityServer4 : 

* Look inot the Read.me of Theo.RnD.Aurelia.OAuthIdentityServer for setting up the Auth Server for users / Scopes / Roles and other configuration.

* This Application will be one of the client application that uses that  AuthServer as the Authority.

* Now that you understaanndd how we setup the Auth Server using the IdentityServer4 , Let configure this Aurelia.UI as a client that used the Auth Services.

* There are bassicaally two wayss I wanted to try out the Authentication on this client...

	* First --> Enaable the Auth from just the ASP.NET Core MVC, which is fairly simple as mentioned below in the below points.
		
		* Enable the CORS by adding the package "Microsoft.AspNet.Cors" in package.jason 

		* Added the follwing dependencies "Microsoft.AspNet.Authorization", "Microsoft.AspNet.Authentication.jwtBearer", "IdentityServer4.AccessTokenValidation", "Microsoft.AspNet.Authentication.OpenIdConnect".
		
		* added the code to configue teh Identity servver in the Statup.cs (Comented now).
		
		* For evaluationg this funcctionality have added a client on the identity server as aurelia.ui which implements the Hybrid flow. (look inot the IdentityServer ddoccs for the details on the flow.)
		
		* Then Just add the "Authorize" attribute in the home controller and run the application.

		* These chaange done should get the application redirect to our identity server for the authentication aand show the login page if the user is not authenticaated. #####BOOM BOOM!! EASY PEASY!!! got the client working !! Next thing that I wanted to evaaluate is more interesting staay tuned.

	* Second --> This was the interesting one that I wanted to try, Enaable and implement the Auth using the Aurealia client libary. Luckly had a open souce aaurelia Auth plugin available  (https://github.com/paulvanbladel/aurelia-auth) wwith the samples thanks to the creator  made my life a bit easy.  Below listed are some cchange done to the project.
		
		* Installed the aurelia-auth into the JSPM packages.
		
		* For evaluationg this funcctionality have added a client on the identity server as aurelia.ui.js which implements the Code flow. (look inot the IdentityServer ddoccs for the details on the flow.)

* 

