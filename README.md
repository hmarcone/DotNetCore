# ProAgil

## Projeto para realizar gestão de Eventos

- [Latest .NET Core 3.1 release]
- Asp.NET Core Identity - (TOKEN - JWT)
- Angular + JWT + .NET Core Identity
- EF Core
- AutoMapper
- Banco SQLite
- Angula 10 
    - NGX Bootstrap
    - Reactive Forms
    - Upload de Imagens 
    - NGX Toastr
    - Observable
    - Angular Gard
    - ngx-currency - https://www.npmjs.com/package/ngx-currency
    - Bootswatch - https://www.npmjs.com/package/bootswatch
    - Bootsnipp - https://bootsnipp.com/snippets/aMp3k
- Deploy Angular - https://angular.io/guide/deployment

## Build & Run

```sh
cd ProAgil.WebApi
dotnet run

cd ProAgil-App
npm install
ng serve -o
```

## Deploy Angular

- Instalar source-map
    - npm install source-map-explorer --save-dev
    - ng build --prod --source-map
    - ls dist/*.bundle.js

## Publish DotNet WebApi

-  dotnet publish -o C:\Users\humbe\Desktop\ProAgil
    - cd C:\Users\humbe\Desktop\ProAgil
    - dotnet ProAgil.WebApi.dll
    - observar se será necessário a criação da pasta Resources
    - Verificar se o banco SQLite está corrompido e buscar na pasta de desenvolvimento