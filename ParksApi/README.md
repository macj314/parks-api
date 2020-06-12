# _Parks Api_

#### _Epicodus Project Jun 12, 2020_

#### By _**Jason Macie**_

## Description

_This is a simple api that holds user created data on state and national parks._

## Setup/Installation Requirements

1. Clone this repository from GitHub.
2. Open the downloaded directory in a text editor of your choice.
  (VSCode, Atom, etc.)
3. Create an appsettings.json folder in the root directory. Set the 'server', 'port', 'uid', and 'pwd' to your own personal setting for your SQL service. But set the 'database' setting to jason_macie<br>
Example: 
``` 
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=server;Port=port;database=jason_macie;uid=userid;pwd=password;"
  }
}
```
4. Run the program with the commands dotnet restore, dotnet build, and dotnet run inside of the ParksApi directory.

## Known Bugs

There are no known bugs at the time of this update.

## Technologies Used

* C#
* .NET Core
* MSBuild
* ASP.Net Core
* MVC
* Razor
* HtmlHelper
* Entity Framework Core
* Git and GitHub

## Specs

| Spec | Input | Output |
| :------------- | :------------- | :------------- |
| **Users can use a get query to get all state parks** | GET request -> https://localhost:****/stateparks | Name: Cape Disapointment |
| **Users can use a get query to get all national parks** | GET request -> https://localhost:****/nationalparks | Name: Olympic |
| **Users can add a park to either list** | POST to either of the previous urls with the format: {"Name": "ENTER NAME HERE"} | Result: 200 |
| **Users can delete a park from the database** | | |
| **Users can edit a park in the database** | | |

### License

This software is licensed under the MIT license.

Copyright (c) 2020 **_Jason Macie_**