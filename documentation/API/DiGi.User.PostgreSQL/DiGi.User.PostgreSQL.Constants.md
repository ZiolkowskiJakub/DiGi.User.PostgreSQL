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