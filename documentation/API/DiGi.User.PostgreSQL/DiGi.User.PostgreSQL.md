#### [DiGi\.User\.PostgreSQL](DiGi.User.PostgreSQL.Overview.md 'DiGi\.User\.PostgreSQL\.Overview')

## DiGi\.User\.PostgreSQL Namespace
### Classes

<a name='DiGi.User.PostgreSQL.Create'></a>

## Create Class

Provides static extension methods on [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection') for the data\-definition operations of the User schema\.

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.User.PostgreSQL.Create.TableAsync_User(thisNpgsql.NpgsqlConnection,int,System.Threading.CancellationToken)'></a>

## Create\.TableAsync\_User\(this NpgsqlConnection, int, CancellationToken\) Method

Asynchronously creates the users table in the PostgreSQL database if it does not already exist\.

Every statement is idempotent (`IF NOT EXISTS`), so the method is safe to run on every
            write and read path, mirroring the create-then-act pattern used by the converter.

```csharp
public static System.Threading.Tasks.Task<bool> TableAsync_User(this Npgsql.NpgsqlConnection? npgsqlConnection, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Create.TableAsync_User(thisNpgsql.NpgsqlConnection,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection') instance used to execute the command\.

<a name='DiGi.User.PostgreSQL.Create.TableAsync_User(thisNpgsql.NpgsqlConnection,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Create.TableAsync_User(thisNpgsql.NpgsqlConnection,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') to monitor for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. The task result is true if the table was created successfully; otherwise, false\.

<a name='DiGi.User.PostgreSQL.Create.UserPostgreSQLConverterManager()'></a>

## Create\.UserPostgreSQLConverterManager\(\) Method

Creates a [UserPostgreSQLConverterManager\(\)](DiGi.User.PostgreSQL.md#DiGi.User.PostgreSQL.Create.UserPostgreSQLConverterManager() 'DiGi\.User\.PostgreSQL\.Create\.UserPostgreSQLConverterManager\(\)') with all PostgreSQL converters registered\.
Reads the connection configuration from the `PostgreSQL_Main` file in the executing assembly's directory\.

IMPORTANT: Every converter consumed by a User WebAPI controller MUST be registered here.
The WebAPI `InitializeAsync` reads converters from the returned manager and adds them to the DI container.
A missing registration causes the controller's converter dependency to be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null'),
resulting in a 500 Internal Server Error at runtime.

```csharp
public static DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager? UserPostgreSQLConverterManager();
```

#### Returns
[UserPostgreSQLConverterManager](DiGi.User.PostgreSQL.Classes.md#DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager 'DiGi\.User\.PostgreSQL\.Classes\.UserPostgreSQLConverterManager')  
A configured [UserPostgreSQLConverterManager\(\)](DiGi.User.PostgreSQL.md#DiGi.User.PostgreSQL.Create.UserPostgreSQLConverterManager() 'DiGi\.User\.PostgreSQL\.Create\.UserPostgreSQLConverterManager\(\)') if successful; otherwise, null\.