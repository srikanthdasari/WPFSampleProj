Step 1: install Entity Framework from Nuget

Step 2: Add the below configuration in app.configuration

Step 3: Execute the below steps


PM> enable-migrations -force
Checking if the context targets an existing database...
Code First Migrations enabled for project WpfSampleProj.UI.


PM> add-migration
cmdlet Add-Migration at command pipeline position 1
Supply values for the following parameters:
Name: EmployeeScripts
Scaffolding migration 'EmployeeScripts'.
The Designer Code for this migration file includes a snapshot of your current Code First model. This snapshot is used to calculate the changes to your model when you scaffold the next migration. If you make additional changes to your model that you want to include in this migration, then you can re-scaffold it by running 'Add-Migration EmployeeScripts' again.


PM> update-database
Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Applying explicit migrations: [201710102309202_EmployeeScripts].
Applying explicit migration: 201710102309202_EmployeeScripts.
Running Seed method.
PM> # WPFSampleProj