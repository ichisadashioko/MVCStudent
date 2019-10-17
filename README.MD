# StudentMVC sample

## Clone the `master` branch

```
git clone https://github.com/ichisadashioko/MVCStudent --branch master --single-branch
```

## Common exceptions

- `SqlException: Cannot attach the file as database.`

    - Open `Package Manager Console`
    - Remove the `LocalDB` instance if it exists.
    
        ```powershell
        SqlLocalDB i
        SqlLocalDB p "MSSQLLocalDB"
        SqlLocalDB d "MSSQLLocalDB"
        ```
    
    - Delete all `*.mdf` files in the `App_Data` folder.
    - Delete Migration folder if it exists.
    - Rebuild project `Ctrl + B`
    - Enable Code-First Migration

        ```powershell
        # Enable-Migrations -ContextTypeName <DbContext class FullName>
        # Example:
        Enable-Migrations -ContextTypeName FUStudentMVC.Models.FUDBContext
        # (Optional) Restore `Configuration.cs` content to populate database
        Update-Database
        ```

- `SqlException: Directory lookup for the file ...`
    - Manually crete the `App_Data` folder.