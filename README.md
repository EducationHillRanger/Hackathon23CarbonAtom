# NoCO2

## Prerequisite

1. Install .NET 6.0 SDK
2. Install Node.js

## How to run

1.  Clone the repository using ```git clone```
2. Move into the NoCOS directory
3. Transition into ClientApp directory and run ```npm install```
4. Transition back to the NoCO2 directory
5. run ```dotnet build```
6. run ```dotnet run```
7. use the link https://localhost:7194 to start

## Inspiration

The project is inspired by Microsoft's article of "Xbox is the first console platform to release dedicated energy and carbon emissions measurement tools designed for (and with) game creators". Microsoft was able to release tools to help game developers to measure the CO2 emission for their game and help innovation to build more sustainable game.

Another Inspiration of our game is the database system "NoSQL" where we don't want any relationship with CO2 emission.

Source: [link](https://developer.microsoft.com/en-us/games/articles/2023/03/gdc-2023-xbox-sustainability-toolkit-for-game-creators/?ocid=FY23_soc_omc_br_li_XboxSustain)

## What it does

The NoCO2 is a web platform that allow user to login or signup for accessing their dashboard. User can login/signup only using email and password. There are 2 main sections of the dashboard: line chart, and input form. The dashboard shows the recent 3 day entry of your daily emission. The input form allow user to input their daily emission on different subjects like transportation, food, and laundry cycles.

## How we built it

The frontend is build using React framework and utilize packages such as Tailwind CSS, Firebase SDK, and Recharts to visualize UIs. The backend is written in .NET 6.0 which links to a MySQL database hosted in AWS RDS.

1. We start building the project on May 5th.
2. Complete Introduction web page and API design by the end of May 5th.
3. Integrate Firebase and Rechart for frontend interaction and backend MySQL functions by the end of May 6th.

## Challenges we ran into

1. First time learning Tailwind CSS, unfamiliar with responsive styling.
2. We are unfamiliar with .NET MVC, which makes the whole deployment of backend very technical. And we are unable to deploy the project to any Azure App Service or AWS EC2.

## Accomplishments that we're proud of

1. Build a React App that allows user login and signup.
2. Design tables in MySQL and database connection function to retrieve user information.
3. Host MySQL in AWS RDS.

## What we learned

1. Split the MVC architecture into different repository, makes it easier to deploy individually.
2. Learn how to develop MySQL database and host it on AWS RDS.
3. Learn to style React components using Tailwind CSS.

## What's next for NoCO2

We want to split the project into two repositories: Frontend and Backend. The frontend should be deploy and host on a static website. The backend should be in an individual repository that can be deploy to Azure App Service. We also want to improve user experience on using the input form for adding daily emission by styling it in a more structural way. Furthermore, adding more information in the line chart to make the graph more understandable.
