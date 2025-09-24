# GitHub Copilot Instructions for dotnetcore-microservices-poc

This guide helps contributors use GitHub Copilot effectively in this .NET microservices repository.

## Purpose
- Accelerate development with AI-powered code suggestions.
- Maintain code quality and consistency across microservices.

## How to Use Copilot
- Enable Copilot in your IDE (VS Code recommended).
- Use Copilot for boilerplate code, repetitive tasks, and generating tests.
- Always review Copilot suggestions before committing.

## Coding Standards
- Follow C# and .NET best practices (naming, formatting, async/await, etc.).
- Use dependency injection and SOLID principles.
- Organize code by service (see folder structure).
- Prefer explicit over implicit code for clarity.
- Add XML comments for public methods and classes.

## Example Copilot Prompts
- "Create a C# controller for user authentication."
- "Generate a unit test for GetAgentsSalesQuery."
- "Suggest a Dockerfile for a .NET 6 Web API."
- "Refactor this method to use async/await."

## Review and Testing
- Validate Copilot-generated code with unit and integration tests.
- Use existing test projects (e.g., `DashboardService.Test`) as reference.
- Ensure code builds and passes all tests before merging.

## Limitations and Tips
- Copilot may suggest insecure or deprecated patterns—always verify.
- Avoid accepting large code blocks without understanding them.
- Use Copilot for productivity, not as a replacement for code review.
- Document any Copilot-generated code that is non-trivial.

## Resources
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
- [GitHub Copilot Docs](https://docs.github.com/en/copilot)

---

Feel free to update this file as the project evolves.
