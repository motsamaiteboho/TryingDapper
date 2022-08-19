using Npgsql;
using Dapper;

    string CONNSTR = "Server=tyke.db.elephantsql.com;Port=5432;Database=hgbxwsfw;User Id=hgbxwsfw;Password=BgpLmExnayeVRK_w3ntajOL9KOLwZ9Xg;";

    var connection = new NpgsqlConnection(CONNSTR);
    connection.Open();

    string CREATE_PIZZA_TABLE = @"create table if not exists pizza (
	id  serial NOT NULL,
	type  character varying(45) NOT NULL,
	size   character varying(45) NOT NULL,
	price  decimal NOT NULL,
    PRIMARY KEY (id) 
    );" ;

    connection.Execute(CREATE_PIZZA_TABLE);
    
     connection.Execute(@"
	insert into 
		pizza (type, size, price)
	values 
		(@Type, @Size, @Price);",
		new Pizza() {
		Type = "Regina",
		Size = "small",
		Price = 31.75
	});

    connection.Execute(@"
	insert into 
		pizza (type, size, price)
	values 
		(@Type, @Size, @Price);",
	new Object[] {
		new Pizza() {
		Type = "Regina",
		Size = "small",
		Price = 31.75
	}, new Pizza {
		Type = "Regina",
		Size = "medium",
		Price = 51.75
	}, new Pizza {
		Type = "Regina",
		Size = "large",
		Price = 89.75
	}
  });
    
   var pizzas = connection.Query<Pizza>(@"select * from pizza");
   Console.WriteLine(pizzas.Count());
   
    connection.Close();