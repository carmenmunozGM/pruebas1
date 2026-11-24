# Agenda GM

Aplicación de escritorio para Windows construida con **.NET MAUI Blazor Hybrid**. Es el cliente (frontend) del **Proyecto SPEC** y consume la API **APIProyectoSPEC**.

> El proyecto se llama `pruebas1`, pero la aplicación se publica como **Agenda GM**.

## Funcionalidades

- Inicio de sesión
- **Calendario:** vistas diaria y semanal; tareas, subtareas, eventos y reglas de recurrencia
- **Plan de trabajo**
- **Autoevaluación**
- **Minutas** con historial
- **Dashboard** de tareas y autoevaluaciones
- **Configuración:**
  - Personalización (vista vertical, horizontal o cuadrícula)
  - Apariencia (modo claro/oscuro)
  - Directorio, administrar agendas, asignar clientes, ver agendas
  - Reportes, días inhábiles, perfiles, ficha de puesto
- **Archivo permanente** y **archivo institucional** (carpetas y archivos en SharePoint a través de la API)
- **Actualización automática** con Velopack

## Tecnologías

- .NET 8 MAUI – Blazor Hybrid (`BlazorWebView`)
- Plataforma: Windows (`net8.0-windows10.0.19041.0`)
- Blazored.LocalStorage, Newtonsoft.Json
- Bootstrap + CSS propio con temas
- Flatpickr (selector de fechas)
- Velopack (auto-actualizaciones)

## Requisitos

- .NET SDK **8.0.422** (fijado en `global.json`)
- Workload de MAUI:

  ```bash
  dotnet workload install maui
  ```

- Windows 10 versión 1809 (10.0.17763) o superior
- Visual Studio 2022 con la carga de trabajo **Desarrollo de interfaz de usuario de aplicaciones multiplataforma de .NET**
- **APIProyectoSPEC** en ejecución

## Configuración de la API

En `pruebas1/MauiProgram.cs`, cambia `BaseAddress` según el ambiente:

```csharp
//BaseAddress = new Uri("https://redgm.site:9096/")  // PRODUCCIÓN
BaseAddress = new Uri("http://localhost:5231/")       // LOCAL
//BaseAddress = new Uri("https://redgm.site:9097/")  // PRUEBAS
```

## Ejecución

**Desde Visual Studio:** abre `pruebas1.sln`, selecciona **Windows Machine** y presiona **F5**.

**Desde la terminal:**

```bash
dotnet build pruebas1/pruebas1.csproj -t:Run -f net8.0-windows10.0.19041.0
```

## Estructura

```
pruebas1/
├── pruebas1.sln
└── pruebas1/
    ├── Components/
    │   ├── DTOs/
    │   ├── Layout/          # MainLayout, LoginLayout, NavMenu
    │   ├── Models/
    │   ├── Pages/           # Calendario, Semanal, Dia2, Plantrabajo, Autoevaluacion, Minuta...
    │   │   └── Configuracion/
    │   └── UI/              # Button, Card, Input, Select, Table, SearchBar...
    ├── Entidades/
    ├── Servicios/           # Servicios HTTP, estado de usuario, tema, Updater
    ├── Platforms/
    ├── Resources/
    ├── wwwroot/             # index.html, css, js, imágenes
    └── MauiProgram.cs
```

## Actualizaciones automáticas

`Servicios/Updater.cs` usa Velopack para buscar versiones nuevas en `https://redgm.site:9096/AgendaGM`. Cuando hay una versión nueva, la descarga y la aplica.
