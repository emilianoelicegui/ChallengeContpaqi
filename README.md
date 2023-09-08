# ChallengeContpaqi

Para actualizar la base de datos:

cd C:\Proyectos\EmilianoElicegui\ChallengeContpaqi

dotnet ef dbcontext scaffold "Data Source=DESKTOP-6MQF69Q\SQLEXPRESS;Initial Catalog=Contpaqi; User Id=sa;Password=123456;TrustServerCertificate=True;Encrypt=false" Microsoft.EntityFrameworkCore.SqlServer -p Contpaqi.Repositories -o Models -c ContpaqiDbContext -f
