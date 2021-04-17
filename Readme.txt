1) La solución se encuentra hecha con .NET 5.0
El mismo puede ejecutarse en Visual Studio 2019 actualizado

2) Creación de la base de datos
En la carpeta Clima\ClimaWeb\Models\SQL se encuentra el archivo ClimaDataBase.sql. 
Este archivo permite hacer la creación de la base de datos en un servidor SQL Server.

También se puede hacer una restauración de la base de datos con el archivo Clima.bak que se encuentra en dicha carpeta.

2) Deben modificar la siguiente linea del archivo Clima\ClimaWeb\Models\ClimaContext.cs . 
En el mismo deben colocar el connection string correspondiente a su base de datos.

optionsBuilder.UseSqlServer("Server=DESKTOP-NFHI0EI\\SQLEXPRESS;Database=Clima;Trusted_Connection=True");