# TryingDapper with postgresSQL
## Step 1: Create ElephantSQL account 
## Step 2: Create the database instance 
## Step 3: Create a new console
## Step 4: Create a pizza class
## Step 5: Add reference csproj file

 <ItemGroup>
    <PackageReference Include="Npgsql" Version="6.0.6" />
    <PackageReference Include="Dapper" Version="2.0.123" />
  </ItemGroup>
  
## Step 6: Install NuGet packages:

- Install package Npgsql
- Install package Dapper

## step 7: in program class add the namespaces:

- using Npgsql;
- using Dapper;

## Step 8: Create connection string:

 string connectionString = "Server=myservername;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword";

## Step 9: Create connection to the server:

var connection = new NpgsqlConnection(connectionString);
    connection.Open();
    
## step 10: create the pizza table using ddl command:

string CREATE_PIZZA_TABLE = @"create table if not exists pizza (
	id  serial NOT NULL,
	type  character varying(45) NOT NULL,
	size   character varying(45) NOT NULL,
	price  decimal NOT NULL,
    PRIMARY KEY (id) 
    );" ;
## step 11: Instert into data into the table:

- You can insert the data the same way as with SQLite

## last Step : close the connection since I didn't use the Using functionality  when I created my database connection:

- connection.Close()
