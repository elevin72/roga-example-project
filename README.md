# roga-example-project

This code was written for an example project for an interview. 

The code was developed and tested on a linux machine running Ubuntu, targeting .NET 7

This solution contains 2 projects.

## generate-data
 This project uses some raw CSV files that I found online, and megrges them into a single output csv called `dataset.csv`
 
### Running the project
 `cd generate-data`

 `dotnet run --project generate-data.csproj`

 After generating the csv, copy that file to the other project folder:
 `cp dataset.csv ../example-project/`

## example-project
Finds some possibly useful information from the generated csv
 
### Running the project
 `cd example-project`

 `dotnet run --project example-project.csproj dataset.csv`
 Make sure to include the path to the csv file generated, so that this project knows which file to use



