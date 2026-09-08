#### [DiGi\.User\.PostgreSQL](DiGi.User.PostgreSQL.Overview.md 'DiGi\.User\.PostgreSQL\.Overview')

## DiGi\.User\.PostgreSQL\.Classes Namespace
### Classes

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter'></a>

## UserPostgreSQLConverter Class

Provides functionality to convert and manage [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') entities within a PostgreSQL database,
implementing the [IUserPostgreSQLConverter](DiGi.User.PostgreSQL.Interfaces.md#DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLConverter 'DiGi\.User\.PostgreSQL\.Interfaces\.IUserPostgreSQLConverter') interface\.

The natural key of a user is its unique email. Writes are upserts against that key, so storing
            a user read back from the database replaces its own row rather than creating a duplicate.

```csharp
public class UserPostgreSQLConverter : DiGi.PostgreSQL.Classes.PostgreSQLConverter<DiGi.User.Classes.User>, DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLConverter, DiGi.PostgreSQL.Interfaces.IPostgreSQLConverter, DiGi.PostgreSQL.Interfaces.IPostgreSQLObject, DiGi.Core.Interfaces.IObject, DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.PostgreSQL\.Classes\.PostgreSQLConverter&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.classes.postgresqlconverter-1 'DiGi\.PostgreSQL\.Classes\.PostgreSQLConverter\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.classes.postgresqlconverter-1 'DiGi\.PostgreSQL\.Classes\.PostgreSQLConverter\`1') → UserPostgreSQLConverter

Implements [IUserPostgreSQLConverter](DiGi.User.PostgreSQL.Interfaces.md#DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLConverter 'DiGi\.User\.PostgreSQL\.Interfaces\.IUserPostgreSQLConverter'), [DiGi\.PostgreSQL\.Interfaces\.IPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.interfaces.ipostgresqlconverter 'DiGi\.PostgreSQL\.Interfaces\.IPostgreSQLConverter'), [DiGi\.PostgreSQL\.Interfaces\.IPostgreSQLObject](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.interfaces.ipostgresqlobject 'DiGi\.PostgreSQL\.Interfaces\.IPostgreSQLObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [IUserPostgreSQLObject](DiGi.User.PostgreSQL.Interfaces.md#DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLObject 'DiGi\.User\.PostgreSQL\.Interfaces\.IUserPostgreSQLObject')
### Constructors

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.UserPostgreSQLConverter(DiGi.PostgreSQL.Classes.ConnectionData)'></a>

## UserPostgreSQLConverter\(ConnectionData\) Constructor

Initializes a new instance of the [UserPostgreSQLConverter](DiGi.User.PostgreSQL.Classes.md#DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter 'DiGi\.User\.PostgreSQL\.Classes\.UserPostgreSQLConverter') class\.

```csharp
public UserPostgreSQLConverter(DiGi.PostgreSQL.Classes.ConnectionData? connectionData);
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.UserPostgreSQLConverter(DiGi.PostgreSQL.Classes.ConnectionData).connectionData'></a>

`connectionData` [DiGi\.PostgreSQL\.Classes\.ConnectionData](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.classes.connectiondata 'DiGi\.PostgreSQL\.Classes\.ConnectionData')

The [DiGi\.PostgreSQL\.Classes\.ConnectionData](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.classes.connectiondata 'DiGi\.PostgreSQL\.Classes\.ConnectionData') containing database connection settings\.
### Properties

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.TableName'></a>

## UserPostgreSQLConverter\.TableName Property

Gets the name of the database table associated with users\.

```csharp
public static string TableName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.ClearAsync(int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.ClearAsync\(int, CancellationToken\) Method

Asynchronously clears all records from the users table, managing the connection\.

```csharp
public System.Threading.Tasks.Task<bool> ClearAsync(int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.ClearAsync(int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.ClearAsync(int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
True if the table was cleared successfully; otherwise, false\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.ClearAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.ClearAsync\(NpgsqlConnection, int, CancellationToken\) Method

Asynchronously clears all records from the users table\.

```csharp
public static System.Threading.Tasks.Task<bool> ClearAsync(Npgsql.NpgsqlConnection? npgsqlConnection, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.ClearAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.ClearAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.ClearAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
True if the table was cleared successfully; otherwise, false\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.CreateTableAsync(int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.CreateTableAsync\(int, CancellationToken\) Method

Asynchronously creates the users table in the database if it does not already exist, managing the connection\.

```csharp
public System.Threading.Tasks.Task<bool> CreateTableAsync(int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.CreateTableAsync(int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.CreateTableAsync(int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
True if the table was created successfully; otherwise, false\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.CreateTableAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.CreateTableAsync\(NpgsqlConnection, int, CancellationToken\) Method

Asynchronously creates the users table in the database if it does not already exist\.

```csharp
public static System.Threading.Tasks.Task<bool> CreateTableAsync(Npgsql.NpgsqlConnection? npgsqlConnection, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.CreateTableAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.CreateTableAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.CreateTableAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
True if the table was created successfully; otherwise, false\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.DeleteUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.DeleteUserByEmailAsync\(NpgsqlConnection, string, int, CancellationToken\) Method

Asynchronously deletes a user by their unique email\.

```csharp
public static System.Threading.Tasks.Task<int> DeleteUserByEmailAsync(Npgsql.NpgsqlConnection? npgsqlConnection, string? email, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.DeleteUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.DeleteUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user to delete\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.DeleteUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.DeleteUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The number of rows deleted, or \-1 if the connection is null or the email is empty\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.DeleteUserByEmailAsync(string,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.DeleteUserByEmailAsync\(string, int, CancellationToken\) Method

Asynchronously deletes a user by their unique email, managing the connection\.

```csharp
public System.Threading.Tasks.Task<int> DeleteUserByEmailAsync(string? email, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.DeleteUserByEmailAsync(string,int,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user to delete\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.DeleteUserByEmailAsync(string,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.DeleteUserByEmailAsync(string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The number of rows deleted, or \-1 if a connection cannot be established or the email is empty\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUserByEmailAsync\(NpgsqlConnection, string, int, CancellationToken\) Method

Asynchronously retrieves a user by their unique email\.

```csharp
public static System.Threading.Tasks.Task<DiGi.User.Classes.User?> GetUserByEmailAsync(Npgsql.NpgsqlConnection? npgsqlConnection, string? email, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByEmailAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') if found; otherwise, null\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByEmailAsync(string,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUserByEmailAsync\(string, int, CancellationToken\) Method

Asynchronously retrieves a user by their unique email, managing the connection\.

```csharp
public System.Threading.Tasks.Task<DiGi.User.Classes.User?> GetUserByEmailAsync(string? email, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByEmailAsync(string,int,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByEmailAsync(string,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByEmailAsync(string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') if found; otherwise, null\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByIdAsync(int,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUserByIdAsync\(int, int, CancellationToken\) Method

Asynchronously retrieves a user by their surrogate identifier, managing the connection\.

```csharp
public System.Threading.Tasks.Task<DiGi.User.Classes.User?> GetUserByIdAsync(int id, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByIdAsync(int,int,System.Threading.CancellationToken).id'></a>

`id` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The surrogate identifier of the user\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByIdAsync(int,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByIdAsync(int,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') if found; otherwise, null\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByIdAsync(Npgsql.NpgsqlConnection,int,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUserByIdAsync\(NpgsqlConnection, int, int, CancellationToken\) Method

Asynchronously retrieves a user by their surrogate identifier\.

```csharp
public static System.Threading.Tasks.Task<DiGi.User.Classes.User?> GetUserByIdAsync(Npgsql.NpgsqlConnection? npgsqlConnection, int id, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByIdAsync(Npgsql.NpgsqlConnection,int,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByIdAsync(Npgsql.NpgsqlConnection,int,int,System.Threading.CancellationToken).id'></a>

`id` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The surrogate identifier of the user\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByIdAsync(Npgsql.NpgsqlConnection,int,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserByIdAsync(Npgsql.NpgsqlConnection,int,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') if found; otherwise, null\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCountAsync(int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUserCountAsync\(int, CancellationToken\) Method

Asynchronously retrieves the number of users stored in the database, managing the connection\.

```csharp
public System.Threading.Tasks.Task<int> GetUserCountAsync(int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCountAsync(int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCountAsync(int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The number of stored users, or \-1 if a connection cannot be established\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCountAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUserCountAsync\(NpgsqlConnection, int, CancellationToken\) Method

Asynchronously retrieves the number of users stored in the database\.

```csharp
public static System.Threading.Tasks.Task<int> GetUserCountAsync(Npgsql.NpgsqlConnection? npgsqlConnection, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCountAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCountAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCountAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The number of stored users, or \-1 if the connection is null\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCredentialAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUserCredentialAsync\(NpgsqlConnection, string, int, CancellationToken\) Method

Asynchronously retrieves the stored password credential of a user by their unique email\.

The credential is read from its own columns rather than from the `object` payload, so it never travels
            with the [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') returned by the other read operations.

```csharp
public static System.Threading.Tasks.Task<DiGi.User.Classes.UserCredential?> GetUserCredentialAsync(Npgsql.NpgsqlConnection? npgsqlConnection, string? email, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCredentialAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCredentialAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCredentialAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCredentialAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.User\.Classes\.UserCredential](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.usercredential 'DiGi\.User\.Classes\.UserCredential')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The [DiGi\.User\.Classes\.UserCredential](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.usercredential 'DiGi\.User\.Classes\.UserCredential') if the user exists and has a complete credential; otherwise, null\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCredentialAsync(string,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUserCredentialAsync\(string, int, CancellationToken\) Method

Asynchronously retrieves the stored password credential of a user by their unique email, managing the connection\.

```csharp
public System.Threading.Tasks.Task<DiGi.User.Classes.UserCredential?> GetUserCredentialAsync(string? email, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCredentialAsync(string,int,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCredentialAsync(string,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUserCredentialAsync(string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.User\.Classes\.UserCredential](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.usercredential 'DiGi\.User\.Classes\.UserCredential')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The [DiGi\.User\.Classes\.UserCredential](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.usercredential 'DiGi\.User\.Classes\.UserCredential') if the user exists and has a complete credential; otherwise, null\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersAsync(int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUsersAsync\(int, CancellationToken\) Method

Asynchronously retrieves all users from the database, managing the connection\.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.List<DiGi.User.Classes.User>?> GetUsersAsync(int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersAsync(int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersAsync(int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A list of [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') entities, or null if a connection cannot be established\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUsersAsync\(NpgsqlConnection, int, CancellationToken\) Method

Asynchronously retrieves all users from the database\.

```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.List<DiGi.User.Classes.User>?> GetUsersAsync(Npgsql.NpgsqlConnection? npgsqlConnection, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersAsync(Npgsql.NpgsqlConnection,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A list of [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') entities, or null if the connection is null\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUsersByEmailsAsync\(NpgsqlConnection, IEnumerable\<string\>, int, int, CancellationToken\) Method

Asynchronously retrieves users matching a collection of email addresses in batched queries\.

```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.List<DiGi.User.Classes.User>?> GetUsersByEmailsAsync(Npgsql.NpgsqlConnection? npgsqlConnection, System.Collections.Generic.IEnumerable<string>? emails, int batchSize=1000, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken).emails'></a>

`emails` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of email addresses to retrieve\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of email addresses to query per batch\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A list of matching [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') entities, or null if the connection is null\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUsersByEmailsAsync\(IEnumerable\<string\>, int, int, CancellationToken\) Method

Asynchronously retrieves users matching a collection of email addresses, managing the connection\.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.List<DiGi.User.Classes.User>?> GetUsersByEmailsAsync(System.Collections.Generic.IEnumerable<string>? emails, int batchSize=1000, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken).emails'></a>

`emails` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of email addresses to retrieve\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of email addresses to query per batch\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByEmailsAsync(System.Collections.Generic.IEnumerable_string_,int,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A list of matching [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') entities, or null if a connection cannot be established\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByLastNameAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUsersByLastNameAsync\(NpgsqlConnection, string, int, CancellationToken\) Method

Asynchronously retrieves users matching the specified last name \(case\-insensitive search\)\.

```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.List<DiGi.User.Classes.User>?> GetUsersByLastNameAsync(Npgsql.NpgsqlConnection? npgsqlConnection, string? lastName, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByLastNameAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByLastNameAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).lastName'></a>

`lastName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The last name or part of the last name to search for\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByLastNameAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByLastNameAsync(Npgsql.NpgsqlConnection,string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A list of matching [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') entities, or null if the connection is null or the name is empty\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByLastNameAsync(string,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.GetUsersByLastNameAsync\(string, int, CancellationToken\) Method

Asynchronously retrieves users matching the specified last name, managing the connection\.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.List<DiGi.User.Classes.User>?> GetUsersByLastNameAsync(string? lastName, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByLastNameAsync(string,int,System.Threading.CancellationToken).lastName'></a>

`lastName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The last name or part of the last name to search for\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByLastNameAsync(string,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.GetUsersByLastNameAsync(string,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A list of matching [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') entities, or null if a connection cannot be established or the name is empty\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.InsertAsync\(NpgsqlConnection, IEnumerable\<User\>, int, int, CancellationToken\) Method

Asynchronously inserts or updates a collection of [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') entities in the database in batches\.

Users are upserted against the unique email key, so a user that is already stored has its row
            refreshed rather than duplicated. The `ON CONFLICT DO UPDATE` clause names its columns explicitly and the
            credential columns are not among them, so re-inserting a user leaves an existing password credential intact.

```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.List<string>> InsertAsync(Npgsql.NpgsqlConnection? npgsqlConnection, System.Collections.Generic.IEnumerable<DiGi.User.Classes.User>? users, int batchSize=1000, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken).users'></a>

`users` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of users to insert or update\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of users per batch command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the command execution\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(Npgsql.NpgsqlConnection,System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A list of user identifiers successfully inserted or updated\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.InsertAsync\(IEnumerable\<User\>, int, int, CancellationToken\) Method

Asynchronously inserts or updates a collection of [DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User') entities in the database, managing the connection\.

Users are upserted against the unique email key, and an existing password credential is left intact.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.List<string>> InsertAsync(System.Collections.Generic.IEnumerable<DiGi.User.Classes.User>? users, int batchSize=1000, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken).users'></a>

`users` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.User\.Classes\.User](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.user 'DiGi\.User\.Classes\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of users to insert or update\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of users per batch command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the command execution\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.InsertAsync(System.Collections.Generic.IEnumerable_DiGi.User.Classes.User_,int,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A list of user identifiers successfully inserted or updated\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.SetUserCredentialAsync\(UserCredential, int, CancellationToken\) Method

Asynchronously stores the password credential of an existing user, managing the connection\.

```csharp
public System.Threading.Tasks.Task<bool> SetUserCredentialAsync(DiGi.User.Classes.UserCredential? userCredential, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken).userCredential'></a>

`userCredential` [DiGi\.User\.Classes\.UserCredential](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.usercredential 'DiGi\.User\.Classes\.UserCredential')

The credential to store\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
True if the credential was stored against an existing user; otherwise, false\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(Npgsql.NpgsqlConnection,DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken)'></a>

## UserPostgreSQLConverter\.SetUserCredentialAsync\(NpgsqlConnection, UserCredential, int, CancellationToken\) Method

Asynchronously stores the password credential of an existing user\.

This updates and never inserts: the user row addressed by [DiGi\.User\.Classes\.UserCredential\.Email](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.usercredential.email 'DiGi\.User\.Classes\.UserCredential\.Email') must already
            exist, so a credential can never bring an otherwise unknown account into being.

```csharp
public static System.Threading.Tasks.Task<bool> SetUserCredentialAsync(Npgsql.NpgsqlConnection? npgsqlConnection, DiGi.User.Classes.UserCredential? userCredential, int commandTimeout=30, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(Npgsql.NpgsqlConnection,DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken).npgsqlConnection'></a>

`npgsqlConnection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

The active [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(Npgsql.NpgsqlConnection,DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken).userCredential'></a>

`userCredential` [DiGi\.User\.Classes\.UserCredential](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.usercredential 'DiGi\.User\.Classes\.UserCredential')

The credential to store\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(Npgsql.NpgsqlConnection,DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken).commandTimeout'></a>

`commandTimeout` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The timeout in seconds for the execution of the command\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(Npgsql.NpgsqlConnection,DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
True if the credential was stored against an existing user; otherwise, false\.

<a name='DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverterManager'></a>

## UserPostgreSQLConverterManager Class

Manages the conversion processes specifically for User data within a PostgreSQL database context\.

```csharp
public class UserPostgreSQLConverterManager : DiGi.PostgreSQL.Classes.PostgreSQLConverterManager<DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLConverter>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.PostgreSQL\.Classes\.PostgreSQLConverterManager&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.classes.postgresqlconvertermanager-1 'DiGi\.PostgreSQL\.Classes\.PostgreSQLConverterManager\`1')[IUserPostgreSQLConverter](DiGi.User.PostgreSQL.Interfaces.md#DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLConverter 'DiGi\.User\.PostgreSQL\.Interfaces\.IUserPostgreSQLConverter')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.classes.postgresqlconvertermanager-1 'DiGi\.PostgreSQL\.Classes\.PostgreSQLConverterManager\`1') → UserPostgreSQLConverterManager