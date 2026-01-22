# Pantalla de Configuración - Blazor

Este proyecto contiene una pantalla de configuración completa implementada en Blazor con CSS puro.

## Estructura de Archivos

```
/blazor-code/
├── ConfiguracionScreen.razor           # Página principal de configuración
├── ConfiguracionScreen.razor.css      # Estilos de la página principal
├── ConfigSidebar.razor                # Componente de navegación lateral
├── ConfigSidebar.razor.css            # Estilos del sidebar
├── Personalizacion.razor              # Sección de personalización
├── Personalizacion.razor.css          # Estilos de personalización
├── Apariencia.razor                   # Sección de apariencia (modo claro/oscuro)
├── Apariencia.razor.css               # Estilos de apariencia
├── Directorio.razor                   # Directorio telefónico
├── Directorio.razor.css               # Estilos del directorio
├── AdministrarAgendas.razor           # Administración de agendas
├── AdministrarAgendas.razor.css       # Estilos de administrar agendas
├── AsignarClientes.razor              # Asignación de clientes
├── AsignarClientes.razor.css          # Estilos de asignar clientes
├── VerAgendas.razor                   # Visualización de agendas
├── VerAgendas.razor.css               # Estilos de ver agendas
├── Reportes.razor                     # Sección de reportes
├── Reportes.razor.css                 # Estilos de reportes
├── DiasInhabiles.razor                # Registro de días inhábiles
└── DiasInhabiles.razor.css            # Estilos de días inhábiles
```

## Características Implementadas

### 1. **Personalización**
- Visualización de bloques en modo lista (horizontal scroll)
- Visualización de bloques en modo cuadrícula (grid)
- Vista previa en tiempo real

### 2. **Apariencia**
- Toggle completo entre modo claro y oscuro
- Los cambios se propagan a todos los componentes
- Vista previa de ambos modos

### 3. **Directorio**
- Tablas organizadas por departamento
- Extensiones telefónicas por rol (no por persona)
- 4 departamentos: TI, Recursos Humanos, Ventas, Administración

### 4. **Administrar Agendas**
- 3 acciones principales:
  - Crear Agenda (tarjeta rosa)
  - Asignar Agenda (tarjeta morada)
  - Desvincular Agenda (tarjeta naranja)
- Notificaciones toast

### 5. **Asignar Clientes**
- Dos columnas distintas:
  - **Clientes Individuales**: Actividades por cliente individual
  - **Grupos de Clientes**: Actividades compartidas entre clientes
- Dropdowns para seleccionar empleados (Karim Negrete, Carmen Muñoz, Gustavo Betanzos)

### 6. **Ver Agendas**
- Cards con información de empleados
- Estadísticas (pendientes y completadas)
- Modal para ver detalles de la agenda
- 6 empleados de ejemplo

### 7. **Reportes**
- Tabla con lista de usuarios
- Botón "Descargar Excel" por cada usuario
- Contador de actividades

### 8. **Días Inhábiles**
- Formulario para registrar días no laborables:
  - Día (1-31)
  - Mes (1-12)
  - Año
  - Título del día
- Lista de días registrados con calendario visual
- 3 días pre-registrados de ejemplo

## Instalación y Uso

### Requisitos
- .NET 6.0 o superior
- Visual Studio 2022 o VS Code con extensión de C#

### Pasos de Instalación

1. Crea un nuevo proyecto Blazor Server o Blazor WebAssembly:
```bash
dotnet new blazorserver -o ConfiguracionApp
# o
dotnet new blazorwasm -o ConfiguracionApp
```

2. Copia todos los archivos `.razor` a la carpeta `/Pages` o `/Components`

3. Copia todos los archivos `.razor.css` junto a sus archivos `.razor` correspondientes

4. Agrega la ruta en `_Imports.razor` si es necesario:
```csharp
@using ConfiguracionApp.Components
```

5. Para usar la página, navega a `/configuracion`

## Personalización del CSS

Todos los estilos están en archivos `.razor.css` separados utilizando CSS Scoped de Blazor. Esto significa que los estilos solo se aplican al componente específico.

### Paleta de Colores Pastel

**Modo Claro:**
- Rosa: `#fce7f3`, `#fbcfe8`, `#f9a8d4`
- Morado: `#e9d5ff`, `#ddd6fe`, `#c084fc`
- Naranja: `#fed7aa`, `#fdba74`, `#fb923c`
- Verde: `#d1fae5`, `#bbf7d0`, `#10b981`
- Azul: `#dbeafe`, `#93c5fd`, `#3b82f6`
- Gris: `#f3f4f6`, `#e5e7eb`, `#d1d5db`

**Modo Oscuro:**
- Fondo principal: `#1a1a1a`, `#262626`
- Borders: `#404040`, `#525252`
- Texto: `#f5f5f5`, `#d1d5db`, `#9ca3af`

### Clases CSS Globales

Si deseas agregar estilos globales, crea un archivo `site.css` en `wwwroot/css/`:

```css
/* Estilos globales comunes */
.dark-mode {
    /* Clase aplicada al contenedor principal cuando está en modo oscuro */
}
```

## Funcionalidad del Estado

### Modo Oscuro
El estado del modo oscuro se gestiona en `ConfiguracionScreen.razor` y se propaga mediante la clase CSS `.dark-mode` en el contenedor principal:

```csharp
private bool isDarkMode = false;

private void ToggleDarkMode()
{
    isDarkMode = !isDarkMode;
}
```

Para persistir el estado entre sesiones, considera usar:
- `localStorage` con JavaScript Interop
- Preferencias de usuario en base de datos
- Cookies

### Cambio de Sección
La navegación entre secciones usa un sistema de routing interno:

```csharp
private string currentSection = "personalizacion";

private void HandleSectionChange(string section)
{
    currentSection = section;
}
```

## Integraciones Futuras

### Base de Datos
Para conectar con una base de datos, reemplaza las listas estáticas con llamadas a servicios:

```csharp
@inject IDirectorioService DirectorioService

protected override async Task OnInitializedAsync()
{
    departments = await DirectorioService.GetDepartmentsAsync();
}
```

### Descarga de Excel
Para implementar la descarga real de Excel, usa una biblioteca como EPPlus o ClosedXML:

```csharp
private async Task HandleDownload(string userName)
{
    var excelData = await ReportesService.GenerateExcelAsync(userName);
    await JSRuntime.InvokeVoidAsync("downloadFile", "reporte.xlsx", excelData);
}
```

### Notificaciones
Las notificaciones toast actuales son simples. Para un sistema más robusto, considera usar:
- Blazored.Toast
- MudBlazor Snackbar
- Radzen Notification

## Compatibilidad

- ✅ Blazor Server (.NET 6+)
- ✅ Blazor WebAssembly (.NET 6+)
- ✅ Blazor Hybrid (MAUI)
- ✅ Navegadores modernos (Chrome, Firefox, Safari, Edge)
- ✅ Diseño responsive (móvil, tablet, desktop)

## Soporte

Este código es un punto de partida completo y funcional. Puedes extenderlo según tus necesidades específicas.

### Recursos Adicionales
- [Documentación oficial de Blazor](https://docs.microsoft.com/aspnet/core/blazor)
- [CSS Isolation en Blazor](https://docs.microsoft.com/aspnet/core/blazor/components/css-isolation)
- [Blazor Component Libraries](https://github.com/AdrienTorris/awesome-blazor)

---

**Desarrollado con:** Blazor + CSS Puro  
**Diseño:** Pastel moderno con soporte para modo oscuro  
**Fecha:** Enero 2026
