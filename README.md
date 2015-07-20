Library-Track

Basic Library for Track your e-books, Api is contained in a assembly: Library.Core.dll main functions are:

List all books

List books by category (Individual or all Category to display in a combo box)

List books by author

a database script with preview data is added in /TrackLibrary/App_Data/LibraryDatabase.sql

Developed in Asp.Net MVC 5 and C# language, EF with SQL Server 2012 is requiered, you need to modify section connectionstring in web.config file in root level.

<add name="LibraryDatabaseEntities" connectionString="metadata=res://*/Model.EntityModel.csdl|res://*/Model.EntityModel.ssdl|res://*/Model.EntityModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source={YOUR-SERVER};initial catalog=LibraryDatabase;user id=LibraryUsr;password=Library2015;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
