# Library
 Built a library management web application with ASP.NET Core Razor Pages (.NET 9) and EF Core: modeled entities (Books, Authors, Categories, Borrowings), implemented CRUD pages, file upload with validation, and reusable Partial Views.

# Library — ASP.NET Core Razor Web App

A simple library management web application built with ASP.NET Core (Razor) on .NET 9.0.  
Implements domain models and relationships with Entity Framework Core, CRUD for books/authors/categories/borrowings, image upload handling, server/client validation and reusable partial views.

## Tech stack
- .NET: `net9.0`
- Language: C# (C# 13)
- Framework: `ASP.NET Core` (Razor views / Razor Pages)
- ORM: `Entity Framework Core` (SQL Server)
- Client validation: `jQuery Validation`
- Tools: Visual Studio 2022, `dotnet` CLI, EF Core Migrations

## Features
- Entity models: `Books`, `Authors`, `Categories`, `Borrowings`
- Full CRUD pages for main entities
- Image upload for `Books` using `IFormFile` (server-side and client-side validation)
- Reusable UI with Partial Views (example: `_AvailableBooksPartial.cshtml`)
- EF Core migrations and SQL Server support

## Quickstart (development)
1. Clone the repo:
   - `git clone <repo-url>`
   - `cd Library`

2. Configure database connection:
   - Add your connection string to `appsettings.json`:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=.;Database=LibraryDb;Trusted_Connection=True;"
       }
     }
     ```
   - Update your `DbContext` to use `"DefaultConnection"` if not already configured.

3. Restore and build:
   - `dotnet restore`
   - `dotnet build`

4. Create and apply migrations (requires `dotnet-ef` / EF tools installed):
   - `dotnet ef migrations add Initial`
   - `dotnet ef database update`

5. Run the app:
   - `dotnet run`
   - Open the browser at `https://storyshelf.runasp.net/`.

If you use Visual Studio, open the solution and press F5 or use __Debug > Start Debugging__.

## Project structure (high level)
- `Library/` — project root
  - `Controllers/` or `Pages/` — request handlers (depending on project layout)
  - `Views/` (or `Pages/`) — Razor views and partials
    - `Views/Shared/_AvailableBooksPartial.cshtml`
  - `Models/` — entity classes: `Books.cs`, `Authors.cs`, `Categories.cs`, `Borrowings.cs`
  - `wwwroot/` — static assets (JS, CSS, images)
  - `appsettings.json` — configuration

## Models overview
- `Books`
  - `Id`, `Title`, `Pages`, `Image` (path), `ImageFile` (`IFormFile`, `[NotMapped]`), `AuthorId`, `CategoryId`
  - Navigation: `Authors`, `Categories`, `Borrowings`
- `Authors`
  - `Id`, `Name`, navigation `Books`
- `Categories`
  - `Id`, `Name`, navigation `Books`
- `Borrowings`
  - `Id`, `BorrowDate`, `ReturnDate`, `BookId`, navigation `Books`

## Important notes & troubleshooting
- Partial view model mismatch:
  - If you render a partial like:
    ```razor
    @model List<Library.Models.Books>
    <partial name="_AvailableBooksPartial" model="Model" />
    ```
    ensure the partial declares a compatible model:
    ```razor
    @model IEnumerable<Library.Models.Books>
    ```
  - If Razor cannot find the partial, use an absolute path:
    ```razor
    <partial name="~/Views/Shared/_AvailableBooksPartial.cshtml" model="Model" />
    ```
- `IFormFile` properties used for upload should be marked `[NotMapped]` and validated. Save uploaded files to `wwwroot` (or a safe location) and persist the saved file path in the `Image` property.
- Ensure EF Core packages and tools are installed (`Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`).

## Testing & validation
- Client-side: jQuery Validation is included under `wwwroot/lib/jquery-validation`
- Server-side: DataAnnotations on model properties validate on postbacks (e.g., `[Required]`, `[MinLength]`, `[DataType(DataType.Date)]`)

## Contributing
- Create feature branches, open PRs, and include migration changes when you modify models.
- Run and test migrations locally before pushing.
- Add/describe breaking changes in PR descriptions.

## TODO / Improvements
- Add authentication/authorization for borrowing actions.
- Add pagination/filtering for book lists.
- Move uploaded images to a dedicated storage (cloud or protected folder).
- Add unit/integration tests.

## License
Add a `LICENSE` file to clarify the project license. (No license included by default.)

## Contact
For questions or help running the project, open an issue in this repository.
