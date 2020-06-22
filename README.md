# _Parks Api_

#### _Epicodus Project Jun 12, 2020_

#### By _**Jason Macie**_

## Description

_This is a simple api that holds user created data under the theme of state and national parks. There are two tables generated from the migrations. One that holds user, and another to hold parks. There is rudimentary static token authentication implemented in the delete and edit functions._

## Setup/Installation Requirements

1. Clone this repository from GitHub.
2. Open the downloaded directory in a text editor of your choice.
  (VSCode, Atom, etc.)
3. Set up your database Default Connection in appsettings.json in the ParksApi directory. Change these settings: 'server', 'port', 'uid', and 'pwd' to your own personal values for your SQL service. Set the 'database' setting to: **jason_macie**<br>
**Example:** `"DefaultConnection": "Server=localhost;Port=3306;database=jason_macie;uid=root;pwd=epicodus;"`
4. Open a terminal set to the ParksApi directory. Build project and database with the commands: `dotnet build` | `dotnet ef database update`
5. Launch the API with: `dotnet run`

### Use of Database

#### Acquiring and Using JWS Authentication Token
1. Get a user token by POST `https://localhost:****/users/authenticate` matching the username and password of the only user in the database. There's an example with the login info below the table.
2. Set your Authorization header to: "Bearer Token"
3. Copy user token into the Token field.
4. Test by querying PUT or DELETE onto a specific park in the database at: `https://localhost:****/api/parks/{parkId}`

#### Specs

| Spec | Input | Result Behavior |
| :------------- | :------------- | :------------- |
| **Users can use a get query to see a list of all parks.** | GET request to -> `https://localhost:****/api/parks` | Display a list of park object |
| **Users can add a park to either list.** | POST to -> https://`localhost:****/api/parks` with the body structure of the code block displayed below this table. Make sure the format type is JSON. | A new park with the entered attributes will be added to the list of parks. It's ID will be the next sequential number after the last added ParkID in the list. |
| **Users can delete a park from the database** | DELETE request to specific park -> `https://localhost:****/api/parks/1` | The Park with ParkId of 1 will be deleted from the list. |
| **Users can edit a park in the database** | PUT to specific park -> `https://localhost:****/api/parks/2` Follow the body structure below the table (like the post command). Change 1 or multiple aspects of that park. | Original park: `Name: "Big Park"`<br> Changes to be made: `Name: "Olympic"`|

#### JSON Examples

Raw body structure of POST/PUT requests using JSON format.
```
{
  "name": "Olympic",
  "type": "National",
  "description": "It's big...",
  "rating": 5,
}
```
Raw body structure of POST request for user authentication.
```
{
  "username": "Test",
  "password": "test",
}
```

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

### Further Exploration

* Make Authentication dynamic with tokens that time out.
* Integrate UserId into Parks Model to add another layer of authentication. 

### License

This software is licensed under the MIT license.

Copyright (c) 2020 **_Jason Macie_**