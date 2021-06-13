Q: I just cloned this repo from https://github.com/SergeiFdrv/SocialWebForms.git and it won't run because
some Microsoft.SqlClient.SNI.x[2 digits].dll library cannot be found, what do I do?

A: Do the following steps locally on your machine:
  1. Update the NuGet packages (except for those turning from versions below 5.0.0.0 to verion 5.0.0.0 or above)
  2. Review the connection strings in app.config and web.config files of all 3 projects and edit them to work with your database
     (keep them identical to each other obviously)
  3. Have a database prepared. If you are going to have it on a local server (which you are) you will have to create it and generate the tables in it:
    3.1. Create an empty database (you can use the Viual Studio Server Explorer tab)
    3.2. Set WebApp.DataClassLibrary as StartUp project
    3.3. Open the NuGet Package Manager Console (Tools > NuGet Package Manager > Package Manager Console)
    3.4. Type in "Update-Database". If nothing is wrong this will generate the tables in a "code-first" manner in the database
         specified in the connection string
  4. Now, the solution consists of 3 projects. One is a class library containing the data model (DataClassLibrary) so it cannot be run.
     And the other two are website versions, one on WebForms and one on MVC. You can set either of the two as StartUp project now