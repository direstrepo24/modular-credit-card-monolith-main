**1. Run Migrations App.**   
- create bd **_creditcard_**
- delete all files folder **_AppMigrations_** from ___Data___ 
- run for create migrations **_dotnet ef migrations add InitialMigration --context PaymentDbContext --output-dir "Data/Migrations" --project Payment.Infraestructure.Persistence --startup-project Payment.Api_**
- update database **_dotnet ef database update --context PaymentDbContext --project Payment.Infraestructure.Persistence --startup-project Payment.Api_**

**3. Run Back**   
- run **_dotnet restore_**
- run **_dotnet run_**