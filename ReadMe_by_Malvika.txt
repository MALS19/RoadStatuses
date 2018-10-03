1.HTTP Client to make call to TFL API
2. XUNIT for Testing Purpose
3.Project is divided into three parts :Service Layer, Test Layer and Presentation Layer
4.Test covers basic scenario like giving Valid input id than display RoadName, Status, Severity Description
as well covers negative scenario when an invalid Road is passed .In that case it catches the HTTP exception error and displays the result.
5.My assumption is to  stay in  the console app when the success or failure occurs after calling the api using enivronment.exit code.
 It was not clear whether to exit the application after success or failure by api calls.If that the case i have added region  " exit the application " kindly uncomment that code and comment the previous one.

