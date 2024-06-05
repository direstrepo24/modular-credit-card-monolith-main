**1. Run Migrations App.**   
- create bd **_creditcard_**
- delete all files folder **_AppMigrations_** from ___Data___ 
- run for create migrations **_dotnet ef migrations add InitialMigration --context CardDbContext --output-dir "Data/Migrations" --project Cards.Infraestructure.Persistence --startup-project Cards.Api_**
- update database **_dotnet ef database update --context CardDbContext --project Cards.Infraestructure.Persistence --startup-project Cards.Api_**

**2. Run Exist Migrations**   
- update database **_dotnet ef database update  --context CardDbContext_**
- update database **_dotnet ef database update  --context SecurityDbContext_**

**3. Run Back**   
- run **_dotnet restore_**
- run **_dotnet run_**