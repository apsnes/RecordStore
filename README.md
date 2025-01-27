## About
This is a record store application for managing inventory via a fully functional blazor web app or via a cocona CLI.

## Features
- Uses MVC layers to link a web api to the record store database.
- Various endpoints for getting records using a number of different filters, as well as endpoints for
  delete, post and put requests.
- Use dotnet commands in the CLI to perform service layer  get methods.
- Blazor web frontend supporting calling all endpoints
- Spotify embedding enabled for all records

## Running the application
- Clone the repo: https://github.com/apsnes/RecordStore.git
- Open the solution in Visual Studio or other IDE
- To use the web app, run the project.
- To use the CLI, navigate to the RecordStoreConsoleApp folder and run commands as required.

## dotnet commands
- Get all records currently in stock:
  dotnet run get-all-records
- Get record by id:
  dotnet run get-record-by-id --id <"id">
- Get records by artist:
  dotnet run get-records-by-artist --artist <"artist">
- Get records by genre:
  dotnet run get-records-by-genre --genre <"genre">
- Get records by release year:
  dotnet run get-records-by-release-year --year <"year">
- Get record by name:
  dotnet run get-record-info-by-name --name <"name">

## Future Improvements
- Automate description fetching upon creating a new artist/record
- Artist artwork for Artist Summary page
