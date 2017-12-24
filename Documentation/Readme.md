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

## 1 Customers

### 1 .1 Get

Get all customers from database

#### Request

Method URL

Get [http://cmswepapi.azurewebsites.net/api/customers](http://cmswepapi.azurewebsites.net/api/customers)^

#### Response

Status Response

200 OK An array of Customers
[
{
"guId": "ff247f5d-95c2-493e-a079-63d962138b19",
"firstName": "Van",
"lastName": "Hakobyan",
"birthDate": "2017- 10 - 28T00:00:00",
"email": "vanhakobyan1996@gmail.com",
"phoneNumber": "093579717",
"country": "Armenia",
"city": "Yerevan",
"employments": []
},
{
"guId": "2ffa7f53-8a18-4e6c-b3f8-51dcb5da9ce2",
"firstName": "Komitas ",
"lastName": "Ghukasyan",
"birthDate": "2017- 10 - 23T00:00:00",
"email": "Ghukasyan@gmail.com",
"phoneNumber": "055050505",
"country": "Armenia",
"city": "Yerevan",
"employments": []
},
{
"guId": "0034bafe-6d31-437e- 8072 - 988e7b0374f8",
"firstName": "Vazgen",
"lastName": "Sargsian",
"birthDate": "2017- 10 - 25T00:00:00",
"email": "VazgenSargsian@gmail.com",
"phoneNumber": "093939393",
"country": "Armenia",
"city": "Yerevan",
"employments": []
}
]


### 1 .2 Get

Get specific customers by GuId

#### Request

Method URL

Get [http://crmbeta.azurewebsites.net/api/customers](http://crmbeta.azurewebsites.net/api/customers)

##### Parameters

Type Param name Values

URL_PARAM guid ff247f5d-95c2-493e-a079-63d962138b1^9

#### Response

Status Response

200 OK Full contact and array of email list of that customers

```
{
"guId": "ff247f5d-95c2-493e-a079-63d962138b19",
"firstName": "Van",
"lastName": "Hakobyan",
"birthDate": "2017- 10 - 28T00:00:00",
"email": "vanhakobyan1996@gmail.com",
"phoneNumber": "093579717",
"country": "Armenia",
"city": "Yerevan",
"employments": []
}
```
### 1 .3 Put

Updates specific customers by Id. Specify in http body the fields you would like to change (note

that “firstName” and “email” are mandatory)

#### Request

Method URL

Put [http://crmbeta.azurewebsites.net/api/customers/{id}](http://crmbeta.azurewebsites.net/api/customers/{id})


##### Parameters

From Type Value

###### BODY

```
CustomersViewMod
el
```
###### {

```
"firstName": "Vanik",
"lastName": "Hakobyan",
"birthDate": "2017- 10 - 28T00:00:00",
"email": "vanhakobyan1996@gmail.com",
"phoneNumber": "093579717",
"country": "Armenia",
"city": "Yerevan"
}
```
URL id 4

#### Response

Status Type Response

200 OK CustomersViewModel Full customers of that contact
{
"guId": "ff247f5d-95c2-493e-a079-63d962138b19",
"firstName": "Vanik",
"lastName": "Hakobyan",
"birthDate": "2017- 10 - 28T00:00:00",
"email": "vanhakobyan1996@gmail.com",
"phoneNumber": "093579717",
"country": "Armenia",
"city": "Yerevan",
"employments": []
}

### 1 .4 Post

Adds new customers to database. Add in body a json object with “fullName” ... (note that

“firstName” and “email” are mandatory)

#### Request

Method URL

##### Post http://cmswepapi.azurewebsites.net/api/customers^

##### Parameters

From Type Value

```
{
"firstName": "The",
```

###### BODY

```
CustomersViewMod
el
```
```
"lastName": "new",
"birthDate": "2017- 10 - 28T00:00:00",
"email": "thenew@gmail.com",
"phoneNumber": "020202002",
"country": "Armenia",
"city": "Yerevan"
}
```
#### Response

Status Type Response

200 OK CustomersViewModel Full customer list of that customers
{
"guId": "b2ce2e86-9c8b-4adc-95ad-
5b826fcc8d93",
"firstName": "The",
"lastName": "new",
"birthDate": "2017- 10 - 28T00:00:00",
"email": "thenew@gmail.com",
"phoneNumber": "020202002",
"country": "Armenia",
"city": "Yerevan",
"employments": []
}

### 1. 5 Delete

#### Request

#### Deletes all contacts, which match the sent array of id.

Method URL

##### Delete http://crmbeta.azurewebsites.net/api/contacts/{id}^

##### Parameters

From Type Value

URl 13

Response {
"guId": "b2ce2e86-9c8b-4adc-95ad-
5b826fcc8d93",
"firstName": "The",
"lastName": "new",
"birthDate": "2017- 10 - 28T00:00:00",
"email": "thenew@gmail.com",


```
"phoneNumber": "020202002",
"country": "Armenia",
"city": "Yerevan",
"employments": []
}
```
#### Response

Status

200 OK

## 2 Employments

### 2 .1 Get

Get all employments from database

#### Request

Method URL

Get [http://cmswepapi.azurewebsites.net/api/customers](http://cmswepapi.azurewebsites.net/api/customers)^

#### Response

Status Response

200 OK An array of Employments
[
{
"guId": "7d02c5fc-3f2c-42e0-b0c8-f420179d4201",
"employmentName": "Music Conductor",
"price": "54633",
"makingTime": null,
"customerId": 4,
"customer": null,
"viewSchedules": []


###### },

###### {

```
"guId": "b62507c1-bd44-4f96-a573-f377d7eaa829",
"employmentName": "Fundraiser",
"price": "54633",
"makingTime": null,
"customerId": 10,
"customer": null,
"viewSchedules": []
},
{
"guId": "e1510d67- 1515 - 4e5f-bfec-f14ae816b92c",
"employmentName": "Insurance Agent",
"price": "54633",
"makingTime": null,
"customerId": 4,
"customer": null,
"viewSchedules": []
},
{
"guId": "fcbffbec-9b63-408d- 8968 - 52f0ab99e4cc",
"employmentName": "Freelance JS",
"price": "2152513",
"makingTime": null,
"customerId": 10,
"customer": null,
"viewSchedules": []
},
{
"guId": "d9f1724e-22dc-4aff-8e11-a957ec248c24",
"employmentName": "Freelance Writer",
"price": "21513",
"makingTime": null,
"customerId": 9,
"customer": null,
"viewSchedules": []
},
{
"guId": "5ae630fe-840a-4dcf-b8fc-cd0f091b4abd",
"employmentName": "Freelance JS",
"price": "2152513",
"makingTime": null,
"customerId": 10,
"customer": null,
"viewSchedules": []
}
]
```
### 2 .2 Get


Get specific customers by GuId

#### Request

Method URL

Get [http://crmbeta.azurewebsites.net/api/employments](http://crmbeta.azurewebsites.net/api/employments)

##### Parameters

Type Param name Values

URL_PARAM guid e1510d67-^1515 - 4e5f-bfec-f14ae816b92c^

#### Response

Status Response

200 OK Full contact and array of email list of that customers

```
{
{
"guId": "e1510d67- 1515 - 4e5f-bfec-f14ae816b92c",
"employmentName": "Insurance Agent",
"price": "54633",
"makingTime": null,
"customerId": 4,
"customer": null,
"viewSchedules": []
}}
```
### 2 .3 Put

Updates specific employment by Id. Specify in http body the fields you would like to change (note

that “price” and “customerId” are mandatory)

#### Request

Method URL

Put [http://crmbeta.azurewebsites.net/api/employments/{id}](http://crmbeta.azurewebsites.net/api/employments/{id})

##### Parameters

From Type Value

(^) {


###### BODY

```
"employmentName": "Insurance Agent",
"price": "546",
"makingTime": null,
"customerId": 4
}
```
URL id 6

#### Response

Status Type Response

200 OK EmploymentViewModel Full customers list of that contact
{
"guId": "e1510d67- 1515 - 4e5f-bfec-f14ae816b92c",
"employmentName": "Insurance Agent",
"price": "54633",
"makingTime": null,
"customerId": 4,
"customer": null,
"viewSchedules": []
}

### 2 .4 Post

Adds new employment to database. Add in body a json object with “employmentName” ... (note

that “employmentName” and “price” are mandatory)

#### Request

Method URL

##### Post http://cmswepapi.azurewebsites.net/api/employments^

##### Parameters

From Type Value

###### BODY

###### {

```
"employmentName": "New Empl",
"price": "410",
"makingTime": null,
"customerId": 12
}
```
#### Response


Status Type Response

200 OK EmploymentsViewMo
del

```
Full employment of that employments
{
"guId": "088D8706- 8932 - 4AA8-A6E2-
ACAADC4C83C1",
"employmentName": "New Empl",
"price": "410",
"makingTime": null,
"customerId": 12,
"customer": null,
"viewSchedules": []
}
```
### 2. 5 Delete

#### Request

#### Deletes employment, which match the sent array of id.

Method URL

##### Delete http://crmbeta.azurewebsites.net/api/employments/{id}^

##### Parameters

From Type Value

URl 13

Response {
"guId": "088d8706- 8932 - 4aa8-a6e2-
acaadc4c83c1",
"employmentName": "New Empl",
"price": "410",
"makingTime": null,
"customerId": 12,
"customer": null,
"viewSchedules": []
}

#### Response

Status

200 OK


## 3 Schedules

### 3 .1 Get

Get all schedules from database

#### Request

Method URL

Get [http://cmswepapi.azurewebsites.net/api/schedules](http://cmswepapi.azurewebsites.net/api/schedules)^

#### Response

Status Response

200 OK An array of Schedules
[
{
"guId": "2d88b44d-82e3-42b6-9f5c-1ac7696d5ec4",
"startWorkTime": "2017- 10 - 28T06:04:14.02",
"endWorkTime": "2017- 10 - 28T06:40:04.02",
"allWorkTime": 9,
"isAccessible": true,
"employmentEmploymentId": 4,
"employmentEmployment": null
},
{
"guId": "2d88b44d-82e3-42b6-9f5c-1ac3696a3ec4",
"startWorkTime": "2017- 10 - 28T06:04:14.02",
"endWorkTime": "2017- 10 - 28T06:40:04.02",
"allWorkTime": 9,
"isAccessible": true,
"employmentEmploymentId": 5,
"employmentEmployment": null
},
{
"guId": "e14f8028-2e23-440c- 8360 - 4afb0bb91fdf",
"startWorkTime": "2017- 10 - 28T06:04:14.02",
"endWorkTime": "2017- 10 - 28T06:40:04.02",
"allWorkTime": 9,
"isAccessible": true,
"employmentEmploymentId": 6,
"employmentEmployment": null
},
{
"guId": "304f3972-cc44-40af-ae98-efd17926c662",
"startWorkTime": "2017- 10 - 28T06:04:14.02",
"endWorkTime": "2017- 10 - 28T06:40:04.02",
"allWorkTime": 15,
"isAccessible": true,
"employmentEmploymentId": 4,


```
"employmentEmployment": null
},
{
"guId": "11fba402-9ec8-40a0-aa7d-1a377ed3d915",
"startWorkTime": "2017- 10 - 28T06:04:14.02",
"endWorkTime": "2017- 10 - 28T06:40:04.02",
"allWorkTime": 1,
"isAccessible": true,
"employmentEmploymentId": 4,
"employmentEmployment": null
}
]
```
### 3 .2 Get

Get specific customers by GuId

#### Request

Method URL

Get [http://crmbeta.azurewebsites.net/api/schedules](http://crmbeta.azurewebsites.net/api/schedules)

##### Parameters

Type Param name Values

URL_PARAM guid 2d88b44d-82e3-42b6-9f5c-1ac7696d5ec^

#### Response

Status Response

200 OK Full schedules list of that schedules

```
{
"guId": "2d88b44d-82e3-42b6-9f5c-1ac7696d5ec4",
"startWorkTime": "2017- 10 - 28T06:04:14.02",
"endWorkTime": "2017- 10 - 28T06:40:04.02",
"allWorkTime": 9,
"isAccessible": true,
"employmentEmploymentId": 4,
"employmentEmployment": null
}
```

### 3 .3 Put

Updates specific schedule by Id. Specify in http body the fields you would like to change (note that

“startWorkTime” and “endWorkTime” are mandatory)

#### Request

Method URL

Put [http://crmbeta.azurewebsites.net/api/schedules/{id}](http://crmbeta.azurewebsites.net/api/schedules/{id})

##### Parameters

From Type Value

###### BODY

###### {

```
"startWorkTime": "2017- 10 - 28T06:04:14.02",
"endWorkTime": "2017- 10 - 28T06:40:04.02",
"allWorkTime": 12,
"isAccessible": true,
"employmentEmploymentId": 4
}
```
URL id 3

#### Response

Status Type Response

200 OK SchedulesViewModel Full schedules list of that schedule
{
"guId": "2d88b44d-82e3-42b6-9f5c-1ac7696d5ec4",
"startWorkTime": "2017- 10 - 28T06:04:14.02",
"endWorkTime": "2017- 10 - 28T06:40:04.02",
"allWorkTime": 12,
"isAccessible": true,
"employmentEmploymentId": 4,
"employmentEmployment": null
}


### 3 .4 Post

Adds new schedules to database. Add in body a json object with “startWorkTime” ...

#### Request

Method URL

##### Post http://cmswepapi.azurewebsites.net/api/schedules^

##### Parameters

From Type Value

###### BODY

###### {

```
"startWorkTime": "2017- 10 - 28T06:04:14.00",
"endWorkTime": "2017- 01 - 28T06:40:04.02",
"allWorkTime": 2,
"isAccessible": false,
"employmentEmploymentId": 12
}
```
#### Response

Status Type Response

200 OK schedulesViewModel Full schedule list of that schedules
{
"guId": "32b50c61-97f3-490a- 9864 - f751fdaa33e8",
"startWorkTime": "2017- 10 - 28T06:04:14",
"endWorkTime": "2017- 01 - 28T06:40:04.02",
"allWorkTime": 2,
"isAccessible": false,
"employmentEmploymentId": 12,
"employmentEmployment": null
}

### 2. 5 Delete

#### Request

#### Deletes schedule, which match the sent array of id.

Method URL

##### Delete http://crmbeta.azurewebsites.net/api/schedules/{id}^

##### Parameters

From Type Value


URl 13

Response {
"guId": "32b50c61-97f3-490a- 9864 - f751fdaa33e8",
"startWorkTime": "2017- 10 - 28T06:04:14",
"endWorkTime": "2017- 01 - 28T06:40:04.02",
"allWorkTime": 2,
"isAccessible": false,
"employmentEmploymentId": 12,
"employmentEmployment": null
}

#### Response

Status

200 OK


