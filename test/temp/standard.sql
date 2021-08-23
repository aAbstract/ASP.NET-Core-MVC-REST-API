USE AdventureWorks2012;  
GO  
SELECT p.FirstName + ' ' + p.LastName AS 'Employee Name',  
a.AddressLine1, a.AddressLine2 , a.City, a.PostalCode   
FROM Person.Person AS p   
   INNER JOIN HumanResources.Employee AS e   
        ON p.BusinessEntityID = e.BusinessEntityID  
    INNER JOIN Person.BusinessEntityAddress bea   
        ON bea.BusinessEntityID = e.BusinessEntityID  
    INNER JOIN Person.Address AS a   
        ON a.AddressID = bea.AddressID;  
GO
