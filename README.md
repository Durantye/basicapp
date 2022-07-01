# README #

Dev Ops Test consists of two parts: An API and a front end React Application

### Back End Setup ###
You can run the application without the database
and validate that the health check runs.  After that,
you will need a postgres sql database set up with the username
and password set up in the `appsettings.json` file.

To build the database, please run the api, navigate to the
swagger page `~/swagger/index.html` and select `Build Database`

### Front End Setup ###
Run `npm install` and then `npm build`.  This should give you the output
of the UI, which you can then copy over to the web server.


### Development Options ###
You can also run these locally using `npm start` and Visual Studio or Rider 
to run the API server.  If you run it locally, you'll need to tunnel
to the postgres sql server running on the ssh server
or install one locally.