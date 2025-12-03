# Loop  (Em desenvolvimento)
## _Gerenciador de frequências de estagiários_
Este projeto é um sistema de gerenciamento de frequência desenvolvido para auxiliar o setor de Recursos Humanos no controle de estagiários, oferecendo uma visão organizada e automatizada da jornada de atividades. Ele centraliza e simplifica processos como registro de presença, banco de horas, contabilização de horas trabalhadas, controle de férias, entre outros
## Configuration
## Stacks

### Back End
[![My Skills](https://skillicons.dev/icons?i=cs,dotnet,mysql,docker,postman&perline=3)](https://skillicons.dev)


### Front End
[![My Skills](https://skillicons.dev/icons?i=vite,react,figma&perline=3)](https://skillicons.dev)

## Tecnologias Utilizadas

- NET 9/ ASP.NET Core MVC
- Entity Framework Core 9.0.21
- Entity Framework Core Design 9.0.21
- Entity Framework Core Tools 9.0.21
- Microsoft Extensions Configuration 9.0.0
- Microsoft Extensions Configuration FileExtensions 9.0.1
- Microsoft Extensions Configuration Json 9.0.1
- Pomelo.EntityFrameworkCore.MySql
- Docker version 28.4.0
- Node version v24.11.1
- npm version 11.6.2

## Arquitetura do Projeto

 📁 **Backend** </br></br>
📁 **Loop.sln** </br>
├─ 🧩 **Loop.Domain** → Entidades e interfaces  
├─ 🧠 **Loop.Application** → Casos de uso e DTOs  
├─ 🗄️ **Loop.Infra.Data** → DbContext e Repositórios  
│  ├─ Context → `AppDbContext.cs`  
│  ├─ Migrations  
│  └─ Repositories  
├─ ⚙️ **Loop.Infra.IoC** → Configuração de DI  
│  └─ `DependencyInjection.cs`  
└─ 💻 **Loop.API** → Apresentação  
   ├─ `appsettings.json`  
   ├─ `Program.cs`  
   └─ Controllers/

   📁 **Frontend** </br>  
├─  **public** → Casos de uso e DTOs  
├─  **src** → DbContext e Repositórios  
│  ├─ assets → `AppDbContext.cs`  
│  ├─ components  
│  ├─ stores
│  ├─ views
│  └─ router  
│  ├─ App.vue
│  └─ main.js 
└─ Index.html 



## Instalação e Configuração
```sh
git clone https://github.com/Deyvisson-del/Loop.git

cd Loop/backend/Loop.API/

dotnet run

cd ../..

cd frontend

npm run dev

````
