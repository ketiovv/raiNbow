### Database with EF Core

#### Migrations
```
dotnet ef migrations add "MIGRATION_NAME" --project RaiNbow --startup-project RaiNbow.API --output-dir Core/Storage/Migrations
```

#### Database update
```
dotnet ef database update --project RaiNbow --startup-project RaiNbow.API
```
