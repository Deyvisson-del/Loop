# Loop  (Em desenvolvimento)
## _Gerenciador de frequências de estagiários_
 Esse sistema tem o objetivo de facilitar processos do RH de empresas visando automatizar e monitorar processos de frequências de estagiários
## Configuration
## Stacks
[![My Skills](https://skillicons.dev/icons?i=html,css,js)](https://skillicons.dev) 
[![My Skills](https://skillicons.dev/icons?i=cs,dotnet,mysql,docker)](https://skillicons.dev)

## Tecnologias Utilizadas

- NET 8/ ASP.NET Core MVC
- Entity Framework Core 8.0.21
- Entity Framework Core Design 8.0.21
- Entity Framework Core Tools 8.0.21
- Microsoft Extensions Configuration 8.0.0
- Microsoft Extensions Configuration FileExtensions 8.0.1
- Microsoft Extensions Configuration Json 8.0.1
- Pomelo.EntityFrameworkCore.MySql
- Docker version 28.4.0

## Arquitetura do Projeto

📁 **Loop.sln** </br>
├─ 🧩 **Loop.Domain** → Entidades e interfaces  
├─ 🧠 **Loop.Application** → Casos de uso e DTOs  
├─ 🗄️ **Loop.Infra.Data** → DbContext e Repositórios  
│  ├─ Context → `AppDbContext.cs`  
│  ├─ Migrations  
│  └─ Repositories  
├─ ⚙️ **Loop.Infra.IoC** → Configuração de DI  
│  └─ `DependencyInjection.cs`  
└─ 💻 **Loop.MVC** → Apresentação  
   ├─ `appsettings.json`  
   ├─ `Program.cs`  
   └─ Controllers/



## Instalação e Configuração
```sh
git clone https://github.com/Deyvisson-del/ArchitectureClean.git

cd ArchitectureClean

````
