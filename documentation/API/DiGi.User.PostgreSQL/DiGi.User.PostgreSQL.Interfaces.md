#### [DiGi\.User\.PostgreSQL](DiGi.User.PostgreSQL.Overview.md 'DiGi\.User\.PostgreSQL\.Overview')

## DiGi\.User\.PostgreSQL\.Interfaces Namespace
### Interfaces

<a name='DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLConverter'></a>

## IUserPostgreSQLConverter Interface

Defines the contract for a User\-specific PostgreSQL converter\.

```csharp
public interface IUserPostgreSQLConverter : DiGi.PostgreSQL.Interfaces.IPostgreSQLConverter, DiGi.PostgreSQL.Interfaces.IPostgreSQLObject, DiGi.Core.Interfaces.IObject, DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLObject
```

Derived  
↳ [UserPostgreSQLConverter](DiGi.User.PostgreSQL.Classes.md#DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter 'DiGi\.User\.PostgreSQL\.Classes\.UserPostgreSQLConverter')

Implements [DiGi\.PostgreSQL\.Interfaces\.IPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.interfaces.ipostgresqlconverter 'DiGi\.PostgreSQL\.Interfaces\.IPostgreSQLConverter'), [DiGi\.PostgreSQL\.Interfaces\.IPostgreSQLObject](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.interfaces.ipostgresqlobject 'DiGi\.PostgreSQL\.Interfaces\.IPostgreSQLObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [IUserPostgreSQLObject](DiGi.User.PostgreSQL.Interfaces.md#DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLObject 'DiGi\.User\.PostgreSQL\.Interfaces\.IUserPostgreSQLObject')

<a name='DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLObject'></a>

## IUserPostgreSQLObject Interface

Defines the contract for a User object that can be persisted in a PostgreSQL database\.

```csharp
public interface IUserPostgreSQLObject : DiGi.Core.Interfaces.IObject
```

Derived  
↳ [UserPostgreSQLConverter](DiGi.User.PostgreSQL.Classes.md#DiGi.User.PostgreSQL.Classes.UserPostgreSQLConverter 'DiGi\.User\.PostgreSQL\.Classes\.UserPostgreSQLConverter')  
↳ [IUserPostgreSQLConverter](DiGi.User.PostgreSQL.Interfaces.md#DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLConverter 'DiGi\.User\.PostgreSQL\.Interfaces\.IUserPostgreSQLConverter')

Implements [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')

<a name='DiGi.User.PostgreSQL.Interfaces.IUserPostgreSQLSerializableObject'></a>

## IUserPostgreSQLSerializableObject Interface

Defines the contract for objects that are serializable and compatible with PostgreSQL User storage\.

```csharp
public interface IUserPostgreSQLSerializableObject : DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject, DiGi.Core.Interfaces.IObject
```

Implements [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')