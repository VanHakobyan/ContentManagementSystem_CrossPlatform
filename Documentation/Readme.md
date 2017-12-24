<p align="center"><img src="https://i.gyazo.com/5de4119f3207f231e47f76e41c0cddeb.png"></p>


# CMS Web API

# Specification Doc

#### 24. 12.

## Index

#### Customers

```
● Get (returns all Customers from database)
➔ Request - http://cmswepapi.azurewebsites.net/api/customers
➔ Response
● Get By GuId (returns specific contact and employments of that Customers)
➔ Request - http://cmswepapi.azurewebsites.net/api/customers/{Guid}
➔ Response
● Put (updates specific Customers by Id)
➔ Request - http://cmswepapi.azurewebsites.net/api/Contacts/{id}
➔ Response
● Post (add new Customers to database)
➔ Request - http://cmswepapi.azurewebsites.net/api/Contacts
```

```
➔ Response
● Delete (deletes Customers by Id array)
➔ Request - http://cmswepapi.azurewebsites.net/api /Contacts
➔ Response
```
#### Employments

```
● Get (returns Employments from database)
➔ Request - http://cmswepapi.azurewebsites.net/api/employments
➔ Response
● Get By GuId (returns specific Employments)
➔ Request - http://cmswepapi.azurewebsites.net/api/employments/{Guid}
➔ Response
● Put (put Employment from specific list by Id)
➔ Request - http://cmswepapi.azurewebsites.net/api/employments /{id}
Add in body the array of guids of contacts you would like to remove from mentioned mailing list
➔ Response
● Post (add new Employment to database)
➔ Request - http://cmswepapi.azurewebsites.net/api/employments
➔ Response
● Delete (delete Employment by Id)
➔ Request - http://cmswepapi.azurewebsites.net/api/employments /{id}
Add in body an array of ids you would like to remove
➔ Response
```
#### Schedules

```
● Get (returns Schedules from database)
➔ Request - http://cmswepapi.azurewebsites.net/api/schedules
➔ Response
● Get By GuId (returns specific Schedules)
➔ Request - http://cmswepapi.azurewebsites.net/api/schedules/{Guid}
➔ Response
● Put (put Schedules from specific list by Id)
➔ Request - http://cmswepapi.azurewebsites.net/api/schedules/{id}
Add in body the array of guids of contacts you would like to remove from mentioned mailing list
➔ Response
● Post (add new Schedules to database)
➔ Request - http://cmswepapi.azurewebsites.net/api/schedules
➔ Response
● Delete (delete Schedules by Id)
➔ Request - http://cmswepapi.azurewebsites.net/api/ schedules/{id}
Add in body an array of ids you would like to remove
➔ Response
```

#### You can see more here 
1. <a href="https://github.com/VanHakobyan/ContentManagementSystem_CrossPlatform/blob/master/Documentation/CMSWebAPISpecification.pdf">Pdf</a>
2. <a href="https://github.com/VanHakobyan/ContentManagementSystem_CrossPlatform/blob/master/Documentation/CMSWebAPISpecification.docx">Word</a>
