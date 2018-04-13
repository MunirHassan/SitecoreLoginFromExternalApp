# Sitecore Login From External App
There are scenarios in which the client might request that users which are part of an external system (for example the company’s internal system) should be able to login into the Siteocre. The fastest and the simplest way is to do it via custom implementation and virtual users.
Virtual User: https://sdn.sitecore.net/Articles/Security/Faking%20user%20roles/Virtual%20user.aspx

In this Project I have created actual user rather than virtual user. To do this, there is no need to create or inject custom processor in the pipeline.

## Solution:
I have created a simple Asp.net webform project with a single page called "LoginExternal.aspx". You need to copy this file into your Website directory. And also copy the "Sitecore.Login.External.dll" into your Website-> bin directory.

From the browser pass username as query string: <sitecore Instance>/LoginExternal.aspx?username="EverDeen" , a User "EverDeen" will be created with admin privilage and you will land into the Launchpad !!

Have fun! Happy coding!
