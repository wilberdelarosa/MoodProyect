# MoodCoach

Aplicación de ejemplo construida con .NET 9 MAUI siguiendo MVVM.

## Requisitos
- SDK .NET 9
- Workloads MAUI

## Ejecutar
```bash
 dotnet workload install maui
 dotnet build
 dotnet maui run
```

## Variables de entorno
Configura la clave de Groq antes de ejecutar:
```bash
export GROQ_API_KEY="<tu_clave>"
```

## Estructura
- `MoodProyect/` código principal
- `MoodProyect.Tests/` pruebas xUnit

Las preguntas del cuestionario están definidas en `QuestionService` y la llamada a Groq se realiza en `GroqService`.
