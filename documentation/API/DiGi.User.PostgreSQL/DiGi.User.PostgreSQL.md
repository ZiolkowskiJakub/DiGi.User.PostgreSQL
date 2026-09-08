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

Asynchronously creates the users table in the PostgreSQL database if it does not already exist, and brings an
existing table up to the current column set\.

Every statement is idempotent (`IF NOT EXISTS`), so the method is safe to run on every
            write and read path, mirroring the create-then-act pattern used by the converter.

The `ALTER TABLE ... ADD COLUMN IF NOT EXISTS` statements are the migration for databases whose users
            table predates the credential and level columns: `CREATE TABLE IF NOT EXISTS` alone does nothing to a table
            that already exists. A database is migrated only by a path that calls this method, which the converter's write
            operations do; a read against an unmigrated database fails with `42703 column does not exist`.

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

<a name='DiGi.User.PostgreSQL.Create.UserCredential(string,string)'></a>

## Create\.UserCredential\(string, string\) Method

Creates a [UserCredential\(string, string\)](DiGi.User.PostgreSQL.md#DiGi.User.PostgreSQL.Create.UserCredential(string,string) 'DiGi\.User\.PostgreSQL\.Create\.UserCredential\(string, string\)') for a password, deriving it with PBKDF2\-HMAC\-SHA256 over a freshly
generated random salt\.

The salt is random per call, so creating a credential twice for the same password yields two different
            hashes and neither reveals that the passwords match.

The credential is not stored by this method. Pass the result to
            [SetUserCredentialAsync\(UserCredential, int, CancellationToken\)](DiGi.User.PostgreSQL.Classes.md#DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter.SetUserCredentialAsync(DiGi.User.Classes.UserCredential,int,System.Threading.CancellationToken) 'DiGi\.User\.PostgreSQL\.Classes\.UserPostgreSQLConverter\.SetUserCredentialAsync\(DiGi\.User\.Classes\.UserCredential, int, System\.Threading\.CancellationToken\)') to write it against an existing user.

```csharp
public static DiGi.User.Classes.UserCredential? UserCredential(string? email, string? password);
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Create.UserCredential(string,string).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user the credential belongs to\.

<a name='DiGi.User.PostgreSQL.Create.UserCredential(string,string).password'></a>

`password` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The plain text password to derive the credential from\.

#### Returns
[DiGi\.User\.Classes\.UserCredential](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.usercredential 'DiGi\.User\.Classes\.UserCredential')  
The derived [UserCredential\(string, string\)](DiGi.User.PostgreSQL.md#DiGi.User.PostgreSQL.Create.UserCredential(string,string) 'DiGi\.User\.PostgreSQL\.Create\.UserCredential\(string, string\)'), or null when the email or the password is blank\.

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

<a name='DiGi.User.PostgreSQL.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.User.PostgreSQL.Query.IsPasswordValid(thisDiGi.User.Classes.UserCredential,string)'></a>

## Query\.IsPasswordValid\(this UserCredential, string\) Method

Determines whether a password matches a stored credential, deriving it with the iteration count recorded on
the credential and comparing the result in constant time\.

Every branch that is not an exact match denies: a null credential, a blank password, a credential
            missing its hash or salt, a non-positive iteration count, and malformed Base64 all return false.

A null credential is still verified against a fixed dummy salt before the answer is returned, so the
            time an unknown email takes to be rejected does not reveal that the account does not exist.

```csharp
public static bool IsPasswordValid(this DiGi.User.Classes.UserCredential? userCredential, string? password);
```
#### Parameters

<a name='DiGi.User.PostgreSQL.Query.IsPasswordValid(thisDiGi.User.Classes.UserCredential,string).userCredential'></a>

`userCredential` [DiGi\.User\.Classes\.UserCredential](https://learn.microsoft.com/en-us/dotnet/api/digi.user.classes.usercredential 'DiGi\.User\.Classes\.UserCredential')

The stored credential to verify against, or null when the user has none\.

<a name='DiGi.User.PostgreSQL.Query.IsPasswordValid(thisDiGi.User.Classes.UserCredential,string).password'></a>

`password` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The plain text password presented by the caller\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True when the password derives to the stored hash; otherwise, false\.