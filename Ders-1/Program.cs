var builder = WebApplication.CreateBuilder(args);


// Services (Container)
builder.Services.AddControllers(); // Controllerlar� kullan�caz
builder.Services.AddEndpointsApiExplorer(); // Ap� ke�fedilebilir hale getirdik
builder.Services.AddSwaggerGen(); // packages' dan indirdik Swagger'� kullanmak i�in.

var app = builder.Build();

if (app.Environment.IsDevelopment()) // Uygulamam development oratam�nda olup olmad���n� kontrol ettim
{
	app.UseSwagger();   //Swagger'� kullanmak i�in ekledik ama �al��t�rd���m�zda swaggerdan ba�lamas� i�in Properties i�indeki launchSettings'e eklememiz gerekiyor.
	app.UseSwaggerUI();
}


app.MapControllers();  // Apileri haritalamak,g�stermek i�in eklememiz gerekir aksi taktirde 404 hatas� al�r�z

app.Run(); //Uygulamay� �al��t�r�cak
