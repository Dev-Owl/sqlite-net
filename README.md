
# SQLite-net

## This fork adds in the following changes:

- Virtual Columns (are ignored during table creation) but can be used in queries to map to entities
- Default values for columns (using meta attributes)
- Some query function that where useful at least for me 

## Example

### Virtual columns

Given this tables/classes:

```csharp
public class Customer
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	[MaxLength(8)]
	public string ShortName { get; set; }
    [VirtualColumn]
    public int MaxRevenue {get; set;}
}

public class Revenue
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
    public int CustomerID {get; set;}
    [Indexed]
	public int RevenueAmount { get; set; }
	public DateTime Time { get; set; }
}
```

The column *TotalRevenue* will not be generated in the database but can be used in queries to store values inside like:
```sql
SELECT Customer.*,
       MAX(Revenue.RevenueAmount) AS MaxRevenue 
FROM  Customer 
INNER JOIN Revenue
           ON Revenue.CustomerID = Customer.ID
```

### Default values

The Class *DefaultAttrribute* can be used to set a default value for a column in a SQL Lite table like:

```csharp
public class Customer
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	[MaxLength(8),DefaultAttrribute("'NEW'")]
	public string ShortName { get; set; }
}
```
**Important notice: The value provided as default value must be a valid SQLLite value, like a string,number or function!**



