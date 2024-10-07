var builder = WebApplication.CreateBuilder(args);


// Services (Container)
builder.Services.AddControllers(); // Controllerlarý kullanýcaz
builder.Services.AddEndpointsApiExplorer(); // Apý keþfedilebilir hale getirdik
builder.Services.AddSwaggerGen(); // packages' dan indirdik Swagger'ý kullanmak için.

var app = builder.Build();

if (app.Environment.IsDevelopment()) // Uygulamam development oratamýnda olup olmadýðýný kontrol ettim
{
	app.UseSwagger();   //Swagger'ý kullanmak için ekledik ama çalýþtýrdýðýmýzda swaggerdan baþlamasý için Properties içindeki launchSettings'e eklememiz gerekiyor.
	app.UseSwaggerUI();
}


app.MapControllers();  // Apileri haritalamak,göstermek için eklememiz gerekir aksi taktirde 404 hatasý alýrýz

app.Run(); //Uygulamayý çalýþtýrýcak
