# UserManagementAPI


# User Management API

A RESTful API built with ASP.NET Core that manages users with full CRUD operations, input validation, and custom middleware.

## Features
- CRUD endpoints (GET, POST, PUT, DELETE) for users
- Validation using Data Annotations ([Required], [EmailAddress], [StringLength], [Range])
- Custom middleware:
  - RequestLoggingMiddleware — logs request method, path, response status, and elapsed time
  - ApiKeyMiddleware — protects endpoints with an X-API-Key header
- Swagger UI for interactive API testing

## How Copilot assisted with debugging

- **Fixed null reference on `GetById`** — Copilot diagnosed that `_users.FirstOrDefault` returned null and suggested the `NotFound` guard.
- **Resolved ModelState validation issue** — Copilot explained that `[ApiController]` auto-validates models, so I removed the redundant manual check but kept it as a safety net.
- **Fixed middleware ordering bug** — originally logging ran after the API key check, so unauthenticated requests weren't logged; Copilot suggested moving logging first.
- **Corrected 500 error on POST** — Copilot identified the missing `[FromBody]` attribute on the parameter.
- **Diagnosed routing conflict** — Copilot noticed the missing `{id:int}` constraint was letting `/api/users/abc` reach the handler and suggested the fix.

## Running
```bash
dotnet run