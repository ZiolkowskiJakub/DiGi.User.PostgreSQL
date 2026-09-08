#### [DiGi\.User\.PostgreSQL](DiGi.User.PostgreSQL.Overview.md 'DiGi\.User\.PostgreSQL\.Overview')

## DiGi\.User\.PostgreSQL\.Constants Namespace
### Classes

<a name='DiGi.User.PostgreSQL.Constants.FileName'></a>

## FileName Class

Provides constant values for PostgreSQL configuration file names\.

```csharp
public static class FileName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FileName
### Fields

<a name='DiGi.User.PostgreSQL.Constants.FileName.PostgreSQL_Main'></a>

## FileName\.PostgreSQL\_Main Field

The filename of the main PostgreSQL configuration file\.

```csharp
public const string PostgreSQL_Main = "User_PostgreSQL_Main.conf";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.User.PostgreSQL.Constants.Password'></a>

## Password Class

Provides the PBKDF2 parameters new password credentials are derived with\.

```csharp
public static class Password
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Password
### Fields

<a name='DiGi.User.PostgreSQL.Constants.Password.HashSize'></a>

## Password\.HashSize Field

The length in bytes of the derived key stored as the password hash\.

```csharp
public const int HashSize = 32;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.User.PostgreSQL.Constants.Password.Iterations'></a>

## Password\.Iterations Field

The number of PBKDF2\-HMAC\-SHA256 iterations a new credential is stretched over, per the OWASP password
storage guidance\.

This value applies to credentials being created. Verification uses the iteration count stored on the
            credential itself, so raising this number costs nothing to the credentials already written.

```csharp
public const int Iterations = 210000;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.User.PostgreSQL.Constants.Password.SaltSize'></a>

## Password\.SaltSize Field

The length in bytes of the random salt generated for a new credential\.

```csharp
public const int SaltSize = 16;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.User.PostgreSQL.Constants.TableName'></a>

## TableName Class

Provides constant values for database table names used in the PostgreSQL User system\.

```csharp
public static class TableName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → TableName
### Fields

<a name='DiGi.User.PostgreSQL.Constants.TableName.User'></a>

## TableName\.User Field

The name of the user table\. One row is a single user, addressed by its unique email\.

```csharp
public const string User = "users";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')