# NoCO2 Overview
NoCO2 is a personal carbon emissions tracker targeted at individuals who want to know what their carbon footprint is and how to take steps to reduce it. Users log events to the app, such as a food or clothing purchase, or a trip they took in their car, and that is added to their daily CO2 totals and their overall CO2 totals. Users can see what categories and items they purchase emit the most CO2, and can use that information to decrease their carbon footprint.

## Project Goals
- Create a functional way for user to log their activities and see how much emissions their activities produced
- Create a clean but feature-rich UX, that allows the user to easily see emissions by categories and individual items
- As developers, learn about working with external SQL databases and connecting that to backend and frontend code
- As developers, work on our collaboration skills and ability to work under pressure

## Desired User Experience
NoCO2 is currently set up as a web app. Its content and functionality is more optimized for that of a mobile app, but due to time constraints and our knowledge, we created it as a web app. You may consider it proof-of-concept for a mobile app. 
Upon opening NoCo2, the user is directed to a signup or login page. When they sign up, a unique user key is created which is used to manage their data in the database (more information in *Implementation details*). After the signup page, they are given the option to log an event or view their current emission statistics. Currently, that is the extent of the user experience. In the future, features such as detailed emission graphs/timelines and the ability to see other user's profiles could be implemented. 

## Implementation details
NoCO2 has four major components. 
1. Frontend HTML/CSS/JS suite
2. Backend CS program that processes data coming from the frontend suite
3. Backend CS program that takes the processed data and communicates it to the database
4. MySQL Database.
When the user signs up, the frontend suite creates a uniqe key similar to a GUID. If the user decides to log an event (ex. I bought 3 lbs of beef) or view past events, the frontend passes the key along with query details (represented as a string) to the processing program. This program checks for possible datatype conversions (metric to imperial) and sends it to the program that communicates wih the database. This program either inputs that information into the database given the user key, or gets information out of the database and sends it back up to the front end. 

## Bugs, issues, and future work
A major issue we encountered while developing NoCO2 was finding and connecting to a database. Most databases required a subscription service to use, and those that didn't often had troubles connecting to. Luc finally found a database that is free and streamlined to use. 

I do not know of any current issues with the code- see Chapman or Luc for additional details.

Future work: As was discussed a little bit in the Desired User Experience section, a large-scale future work would be to turn this web app into a mobile app. Following that, detailed emissions graphs and timelines could be implemented, along with a "multiplayer" functionality that allows users to connect with other users and see each other's emissions trends.