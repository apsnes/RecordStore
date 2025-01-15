This is a record store application for managing inventory


## About
This is a record store application for managing inventory via Http requests or via a cocona CLI.

## Features
- Uses MVC layers to link a web api to the record store database.
- Various endpoints for getting records using a number of different filters, as well as endpoints for
  delete, post and put requests.
- Use dotnet commands in the CLI to perform service layer  get methods.

## Running the application
- Clone the repo: https://github.com/apsnes/RecordStore.git
- Open the solution in Visual Studio or other IDE
- To use the web app, run the project.
- To use the CLI, navigate to the RecordStoreConsoleApp folder and run commands as required.

## dotnet commands
- Get all records currently in stock:
  dotnet run get-all-records
- Get record by id:
  dotnet run get-record-by-id --id <id>
- Get records by artist:
  dotnet run get-records-by-artist --artist <"artist">
- Get records by genre:
  dotnet run get-records-by-genre --genre <"genre">
- Get records by release year:
  dotnet run get-records-by-release-year --year <year>
- Get record by name:
  dotnet run get-record-info-by-name --name <"name">

## Future Improvements
- Develop fully functional frontend
