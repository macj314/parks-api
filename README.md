# _Parks Api_

#### _Epicodus Project Jun 12, 2020_

#### By _**Jason Macie**_

## Description

_This is a simple api that holds user created data on state and national parks._

## Setup/Installation Requirements

1. Clone this repository from GitHub.
2. Open the downloaded directory in a text editor of your choice.
  (VSCode, Atom, etc.)
3. Set up your database Default Connection in appsettings.json in the ParksApi directory. Change these settings: 'server', 'port', 'uid', and 'pwd' to your own personal values for your SQL service. Set the 'database' setting to: **jason_macie**<br>
**Example:** `"DefaultConnection": "Server=localhost;Port=3306;database=jason_macie;uid=root;pwd=epicodus;"`
4. Build project and database with the commands: `dotnet build` | `dotnet ef database update`
5. Launch the API with: `dotnet run`
6. Use the Queries listed below in Specs to interact with the database.

## Known Bugs

There are no known bugs at the time of this update.

## Technologies Used

* C#
* MSBuild
* ASP.Net Core v2.2
* MVC
* Razor
* HtmlHelper
* Entity Framework Core
* Git and GitHub

## Specs

| Spec | Input | Result Behavior |
| :------------- | :------------- | :------------- |
| **Users can use a get query to see a list of all parks.** | GET request to -> `https://localhost:****/api/parks` | Display a list of park object |
| **Users can add a park to either list.** | POST to -> https://`localhost:****/api/parks` with the body structure of displayed below this table. Also make sure the format type is JSON. | A new park with the entered attributes will be added to the list of parks. It's ID will be the next sequential number after the last added ParkID in the list. |
| **Users can delete a park from the database** | DELETE request to specific park -> `https://localhost:****/api/parks/1` | The Park with ParkId of 1 will be deleted from the list. |
| **Users can edit a park in the database** | PUT to specific park -> `https://localhost:****/api/parks/2` Follow the body structure below the table (like the post command). Change 1 or multiple aspects of that park. | Original park: `Name: "Olympic"` Changes to be made: `Name: "Big Park"`|

Raw body structure of POST/PUT requests using JSON format.
```
{
  "name": "Olympic",
  "type": "National",
  "description": "It's big...",
  "rating": 5,
  "imageUrl": null
}
```

### License

This software is licensed under the MIT license.

Copyright (c) 2020 **_Jason Macie_**