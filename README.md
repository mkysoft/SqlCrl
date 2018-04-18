# SqlCrl
Some functions for Microsoft SQL Server
## Functions
| Function  | Description |
| ------------- | ------------- |
| Unzip  | Unzip binary data |
## Installation
I prefer install this dll to master because of accesing in any db.
### Loading Dll
Load SqlCrl.dll to SQL Server db from Programmablty > Assemblies
### Enabling Function
Run below command in master or whenever db.
```sql
CREATE FUNCTION Unzip(@Input varbinary(max)) RETURNS varbinary(max)
AS EXTERNAL NAME [SqlCrl].[Zip].Unzip;
```
### Enabling CRL Functionalty
```sql
sp_configure 'clr enabled', 1;
RECONFIGURE
```
