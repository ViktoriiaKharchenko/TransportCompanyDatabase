# ControllersTest

Trailer Types
------

![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png "GET request")   __/api/TrailerTypes__ 
### request parameters:
  - __none__
### responce body:
```yaml
[
  {
    "id": 1,
    "type": "Flatbed Trailers",
    "trailers": []
  },
  {
    "id": 2,
    "type": "Refrigerated Trailers",
    "trailers": []
  },
  {
    "id": 3,
    "type": "Lowboy Trailers",
    "trailers": []
  },
  {
    "id": 4,
    "type": "Step Deck Trailers",
    "trailers": []
  }
]
```
![POST:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/POST.png "POST request") __/api/TrailerTypes__ 
### request parameters:
  - __request body:__
```yaml
{
  "type": "some trailers",
  "trailers": []
}
```  
### responce body:
```yaml
{
  "id": 22,
  "type": "some trailers",
  "trailers": []
}
```
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png  "GET request") __/api/TrailerTypes/{id}__ 
### request parameters:
  - __id - 2__
### responce body:
```yaml
{
  "id": 2,
  "type": "Refrigerated Trailers",
  "trailers": []
}
```
![PUT:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/PUT.png "PUT request") __/api/TrailerTypes/{id}__ 
### request parameters:
  - id - 22
  - __request body:__

```yaml
{
  "id": 22,
  "type": "Big one 2",
  "trailers": []
}
```
### responce body:
```yaml
```
![DELETE:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/DELETE.png  "DELETE request") __/api/TrailerTypes/{id}__ 

### request parameters:
  - id - 1
### responce body:

```yaml
{
  "id": 1,
  "type": "Flatbed Trailers",
  "trailers": []
}
```

Customer Companies
-----

![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png "GET request")   __api/CustomerCompanies__ 
### request parameters:
  - __none__
### responce body:
 - code:200
```yaml
[
  {
    "id": 1,
    "companyName": "Toyota",
    "documentNum": "doc num 1",
    "deliveries": []
  },
  {
    "id": 2,
    "companyName": "not toyota",
    "documentNum": "doc num 2",
    "deliveries": []
  },
  {
    "id": 3,
    "companyName": "Karrito",
    "documentNum": "doc num 3",
    "deliveries": []
  },
  {
    "id": 4,
    "companyName": "Boss corp",
    "documentNum": "doc num 4",
    "deliveries": []
  }
]
```
![POST:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/POST.png "POST request") __/api/CustomerCompanies__ 
### request parameters:
  - __request body:__
```yaml
{
    "companyName": "Company Name",
    "documentNum": "doc num 10",
    "deliveries": []
}
```  
### responce body: 
 - code:201
```yaml
{
  "id": 9,
  "companyName": "Company Name",
  "documentNum": "doc num 10",
  "deliveries": []
}
```
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png  "GET request") __/api/CustomerCompanies/{id}__ 
### request parameters:
  - __id - 4__
### responce body:
 - code:200
```yaml
{
  "id": 4,
  "companyName": "Boss corp",
  "documentNum": "doc num 4",
  "deliveries": []
}
```
![PUT:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/PUT.png "PUT request") __/api/CustomerCompanies/{id}__ 
### request parameters:
  - id - 3
  - __request body:__

```yaml
{
  "id": 3,
  "companyName": "Kritical Corp",
  "documentNum": "111111",
  "deliveries": []
}
```
### responce body:
 - code:204
```yaml
```
![DELETE:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/DELETE.png  "DELETE request") __/api/CustomerCompanies/{id}__ 

### request parameters:
  - id - 3
### responce body:
 - code:200
```yaml
{
  "id": 3,
  "companyName": "Kritical Corp",
  "documentNum": "111111",
  "deliveries": []
}
```
Loads
------

![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png "GET request")   __api/Loads__ 
### request parameters:
  - __none__
### responce body:
 - code:200
```yaml
[
  {
    "id": 1,
    "uploadDate": "2020-04-01T12:12:00",
    "address": "Fisk street 7a",
    "cargoName": "Food ",
    "requireADR": false,
    "deliveries": []
  },
  {
    "id": 2,
    "uploadDate": "2020-04-11T09:33:32",
    "address": "Karasin street 18",
    "cargoName": "Fuel ",
    "requireADR": true,
    "deliveries": []
  },
  {
    "id": 3,
    "uploadDate": "2020-04-19T15:09:45",
    "address": "Fisk street 7a",
    "cargoName": "Vegetables ",
    "requireADR": false,
    "deliveries": []
  },
  {
    "id": 4,
    "uploadDate": "2020-05-02T01:54:10",
    "address": "Karasin street 18",
    "cargoName": "Gas ",
    "requireADR": true,
    "deliveries": []
  }
]
```
![POST:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/POST.png "POST request") __/api/Loads__ 
### request parameters:
  - __request body:__
```yaml
 {
    "uploadDate": "2021-01-01T00:00:00",
    "address": "Khreschatyk street 18",
    "cargoName": "Food ",
    "requireADR": false,
    "deliveries": []
 }
```  
### responce body: 
 - code:201
```yaml
{
  "id": 5,
  "uploadDate": "2021-01-01T00:00:00",
  "address": "Khreschatyk street 18",
  "cargoName": "Food ",
  "requireADR": false,
  "deliveries": []
}
```
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png  "GET request") __/api/Loads/{id}__ 
### request parameters:
  - __id - 5__
### responce body:
 - code:200
```yaml
{
  "id": 5,
  "uploadDate": "2021-01-01T00:00:00",
  "address": "Khreschatyk street 18",
  "cargoName": "Food ",
  "requireADR": false,
  "deliveries": []
}
```
![PUT:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/PUT.png "PUT request") __/api/Loads/{id}__ 
### request parameters:
  - id - 5
  - __request body:__

```yaml
{
  "id": 5,
  "uploadDate": "2022-01-01T00:00:00",
  "address": "Khreschatyk street 19",
  "cargoName": "not Food ",
  "requireADR": true,
  "deliveries": []
}
```
### responce body:
 - code:204
```yaml
```
![DELETE:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/DELETE.png  "DELETE request") __/api/Loads/{id}__ 

### request parameters:
  - id - 5
### responce body:
 - code:200
```yaml
{
  "id": 5,
  "uploadDate": "2022-01-01T00:00:00",
  "address": "Khreschatyk street 19",
  "cargoName": "not Food ",
  "requireADR": true,
  "deliveries": []
}
```
Trailers
------

![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png "GET request")   __api/Trailers__ 
### request parameters:
  - __none__
### responce body:
 - code:200
```yaml
[
  {
    "id": 1,
    "volume": 25,
    "carryingCapacity": 15,
    "trailerTypeId": 8,
    "trailerType": null,
    "wagons": []
  },
  {
    "id": 2,
    "volume": 20,
    "carryingCapacity": 10,
    "trailerTypeId": 2,
    "trailerType": null,
    "wagons": []
  },
  {
    "id": 4,
    "volume": 20,
    "carryingCapacity": 10,
    "trailerTypeId": 8,
    "trailerType": null,
    "wagons": []
  }
]
```
![POST:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/POST.png "POST request") __/api/Trailers__ 
### request parameters:
  - __request body:__
```yaml
 {
    "volume": 19,
    "carryingCapacity": 9,
    "trailerTypeId": 8,
    "trailerType": null,
    "wagons": []
 }
```  
### responce body: 
 - code:201
```yaml
{
  "id": 5,
  "volume": 19,
  "carryingCapacity": 9,
  "trailerTypeId": 8,
  "trailerType": null,
  "wagons": []
}
```
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png  "GET request") __/api/Trailers/{id}__ 
### request parameters:
  - __id - 1__
### responce body:
 - code:200
```yaml
{
  "id": 1,
  "volume": 25,
  "carryingCapacity": 15,
  "trailerTypeId": 8,
  "trailerType": null,
  "wagons": []
}
```
![PUT:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/PUT.png "PUT request") __/api/Trailers/{id}__ 
### request parameters:
  - __id - 1__
  - __request body:__

```yaml
{
  "id": 1,
  "volume": 5,
  "carryingCapacity": 1,
  "trailerTypeId": 2,
  "trailerType": null,
  "wagons": []
}
```
### responce body:
 - code:204
```yaml
```
![DELETE:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/DELETE.png  "DELETE request") __/api/Trailers/{id}__ 

### request parameters:
 - id - 1
### responce body:
 - code:200
```yaml
{
  "id": 1,
  "volume": 5,
  "carryingCapacity": 1,
  "trailerTypeId": 2,
  "trailerType": null,
  "wagons": []
  "deliveries": []
}
```
Wagons
------

Drivers
------

DriversWagons
------

Deliveries
------
