# Proyecto.Net

SO: MacOs
BD: Sql Server a través de Docker y Azure Data Studio

CONFIGURACIONES BD

Docker
1.- Crear y correr un contenedor para la imagen
docker run -e "ACCEPT_EULA=1" -e "MSSQL_USER=SA" -e "MSSQL_SA_PASSWORD=SQLConnect1\!" -e "MSSQL_PID=Developer" -p 1433:1433 -d --name=sql_connect mcr.microsoft.com/azure-sql-edge

  Credenciales de la conexión en Azure Data Studio:
    Server: localhost
    User:sa
    password:SQLConnect1!

2.-Detener e iniciar contenedor:
    docker stop sql_connect
    docker start sql_connect

Conexión en el proyetcto:

1.- Archivo appsettings.json
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost,1433;Database=CRUDNet;User Id=sa;Password=SQLConnect1!;MultipleActiveResultSets=true;TrustServerCertificate=True"
    },

2.- Creación de un ApplicationDbContext.cs
  public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
		}
		//Aqui agregar los modelos de la bd, (tablas)
    //Ejemplo de tabla:
		  public DbSet<Contacto> Contacto { get; set; } ... etc...
	}
3.- Archivo Program.cs
  //Configurar bd local
  var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
  builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

Comandos para realizar la Migración desde terminal:

1.- Construir el proyecto para evitar errores:
    dotnet build 
2.- Crear la migración:
    dotnet ef migrations add <NombreDeLaMigracion>
3.- Actualizar bd:
    dotnet update-database

