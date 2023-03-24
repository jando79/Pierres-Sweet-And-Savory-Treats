# _Pierre's Sweet And Savory Treats_

#### By _David Jandron_

#### _A C# web application using MySQL that creates a website for Pierre's Backery customers to view, create, edit, and delete custom orders _

## Technologies Used

* C#
* Razor HTML
* VS Code
* .Net 6
* MySQL
* Entity Framework Core 6
* CSS

## Description

_This is site built to allow users to create, edit, delete, and view multiple flavors of multiple patries. This site uses authentication and authorization to allow each user customization_

## Setup/Installation Requirements

* Clone this repo.
* Open the terminal and navigate to this project's production directory called "PierresSweetAndSavoryTreats.Solution".
* Within the production directory "Pierres", create a new file called `appsettings.json`.
* Within appsettings.json, put in the following code.
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=pierres_treats;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```
* Within the production directory "Pierres", run `dotnet watch run` in the command line to start the project in development mode with a watcher.

* Open the browser to https://localhost:5001.


## Known Bugs

* _N/A_

## License

_MIT License_

Copyright (c) _2023_ _authored by: David Jandron_