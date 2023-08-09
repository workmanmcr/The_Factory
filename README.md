# The Factory

# By: Mike Workman

This MVC application acts as a tool for a factory supervisor to manage their engineers and machines.

View on [Github Pages](https://https://workmanmcr.github.io/The_Factory/)

## **Technologies Used**

- C#
- .NET
- GIT
- GitHub
- VScode
- MySql Workbench

## **Description**
This application is intended to help a factory owner keep track of all their engineers and factory machines. The owner is able to view a list of all current engineers, see details for each specific engineer, add new engineers to the system, and add new machines to a specific engineer. There is also functionality (in the form of buttons and clickable links) to edit and delete specified machines or Engineers.
## **Complete Setup**
 
1. Navigate to main page of repo.
2. Copy link from repo.
3. Clone this repo.
4. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory called "Factory.solution".
5. Once the Factory.solution has been selected type "code ." to open VS Code.
6. Click"terminal" in the top leff of the window.
7. Select "new temrinal" from the drop down menu.
8. Navigate to "Factory" in the temrinal.
9. In the temrinal type the command "dotnet watch run".

## Recreating the Database
1. Open MySQL Workbench and navigate to the Administration tab
2. Under the Management label, click Data Import/Restore
3. Under the Import Options tab, select the circle for Import from Self-Contained File and click the small button with two dots after the text box
4. In the window that pops up, navigate to the root level of this project, titled HairSalon.Solution and select the file titled Factory.sql
5. Under the Default Target Schema tab, select the New button and create a name for your new database
6. Verify your database is named properly and click the Start Import button. Once complete, you will receive a confirmation from MySQL
7. Once your import is complete, navigate to the Schemas tab at the top of the page. Once you click the small refresh icon in the upper right corner, your new database should populate within the list
8. You will be able to click the new database name, and click the tables tab to verify that both the clients and stylists tables were imported properly
## Connecting the Database
9. Return to your computer's terminal application to your newly cloned project
10. Within the production level of this directory, called Factory, create a new file called appsettings.json
11. Input the following code into your appsettings.json file
{ "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD-HERE];" } }

- Replace [ YOUR-DB-NAME ] with the name of the database you just imported to MySQL Workbench
- Replace [ YOUR-USER-HERE ] with your username for MySQL Workbench
- Replace [ YOUR-PASSWORD-HERE ] with your password for MySQL Workbench
- Make sure you save all changes you've made to the file


## **Known Bugs**
no known bugs at this time. 


MIT License

Copyright (c) [2023] [Micheal Workman]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.