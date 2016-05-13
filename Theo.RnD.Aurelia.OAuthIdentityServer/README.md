# Theo.RnD.Aurelia.OAuthIdentityServer

This will act as the OAuth Server for our Client application which takees the responsibility of user Authentication. This will be implemented using the latesst IdentityServer4.

####First Step - Cretate the Applicaation Setup : 

* Create a normal ASP.Net 5 application in Visual studio with the Authentication set as No Authentication. We will ennnable the Auth using IdentityServer4 for this Application.

* Add the refrence of IdentityServer4 & Microsoft.AspNet.Cors from Nuget by updating the project.json file.

* rest of the code is exactly coped from the IdentityServer4 samples.

* Creating of the certificate :
	- Used the instructions give here to create the self signed certificate https://blog.didierstevens.com/2015/03/30/howto-make-your-own-cert-with-openssl-on-windows/ only change I did was to gerenate teh pfx file.
	- This helped me to fix the Certificate object creation issue in teh code http://vdachev.net/2012/03/07/c-sharp-error-creating-x509certificate2-from-a-pfx-or-p12-file-in-production/
	
#####BOOM BOOM!! Got the OAuth server using the IdentityServer4 up  and runing .. Quite  a task with all the certificate issues , but finall got it working .. Way to go THEO !!! ;-)
	

