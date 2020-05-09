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

![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png "GET request")   __api/Wagons__ 
### request parameters:
  - __none__
### responce body:
 - code:200
```yaml
[
  {
    "id": 2,
    "trailerId": 2,
    "trailer": null,
    "driversWagons": []
  },
  {
    "id": 4,
    "trailerId": 4,
    "trailer": null,
    "driversWagons": []
  }
]
```
![POST:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/POST.png "POST request") __/api/Wagons__ 
### request parameters:
  - __request body:__
```yaml
  {
    "trailerId": 4,
    "trailer": null,
    "driversWagons": []
  }
```  
### responce body: 
 - code:201
```yaml
{
  "id": 6,
  "trailerId": 4,
  "trailer": null,
  "driversWagons": []
}
```
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png  "GET request") __/api/Wagons/{id}__ 
### request parameters:
  - __id - 2__
### responce body:
 - code:200
```yaml
{
  "id": 2,
  "trailerId": 2,
  "trailer": null,
  "driversWagons": []
}
```
![PUT:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/PUT.png "PUT request") __/api/Wagons/{id}__ 
### request parameters:
  - __id - 2__
  - __request body:__

```yaml
{
  "id": 2,
  "trailerId": 4,
  "trailer": null,
  "driversWagons": []
}
```
### responce body:
 - code:204
```yaml
```
![DELETE:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/DELETE.png  "DELETE request") __/api/Wagons/{id}__ 

### request parameters:
 - id - 2
### responce body:
 - code:200
```yaml
{
  "id": 2,
  "trailerId": 4,
  "trailer": null,
  "driversWagons": []
}
```
Drivers
------

![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png "GET request")   __api/Drivers__ 
### request parameters:
  - __none__
### responce body:
 - code:200
```yaml
[
  {
    "id": 1,
    "fullName": "Pupkin Vasyl Ivanovich",
    "passportNum": "AB123456",
    "driverLicenseNum": "K12lk31233AA",
    "adrCertificate": true,
    "driversWagons": []
  },
  {
    "id": 2,
    "fullName": "John Trevis",
    "passportNum": "KSA12345678",
    "driverLicenseNum": "K22221233AA",
    "adrCertificate": false,
    "driversWagons": []
  },
  {
    "id": 3,
    "fullName": "Grigoriev Inokentyi Pavlovich",
    "passportNum": "AB760760",
    "driverLicenseNum": "K13lk31233AB",
    "adrCertificate": false,
    "driversWagons": []
  },
  {
    "id": 4,
    "fullName": "Miziakina Alla Valentynivna",
    "passportNum": "AC808678",
    "driverLicenseNum": "K34lL31267AA",
    "adrCertificate": true,
    "driversWagons": []
  }
]
```
![POST:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/POST.png "POST request") __/api/Drivers__ 
### request parameters:
  - __request body:__
```yaml
{
	"fullName": "Krykosk Yurii Andriyovych",
	"passportNum": "AC828678",
	"driverLicenseNum": "K34lL31267AA",
	"adrCertificate": true,
	"driversWagons": []
}
```  
### responce body: 
 - code:201
```yaml
{
  "id": 7,
  "fullName": "Krykosk Yurii Andriyovych",
  "passportNum": "AC828678",
  "driverLicenseNum": "K34lL31267AA",
  "adrCertificate": true,
  "driversWagons": []
}
```
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png  "GET request") __/api/Drivers/{id}__ 
### request parameters:
  - __id - 7__
### responce body:
 - code:200
```yaml
{
  "id": 7,
  "fullName": "Krykosk Yurii Andriyovych",
  "passportNum": "AC828678",
  "driverLicenseNum": "K34lL31267AA",
  "adrCertificate": true,
  "driversWagons": []
}
```
![PUT:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/PUT.png "PUT request") __/api/Drivers/{id}__ 
### request parameters:
  - __id - 7__
  - __request body:__

```yaml
{
  "id": 7,
  "fullName": "no name",
  "passportNum": " ",
  "driverLicenseNum": " ",
  "adrCertificate": false,
  "driversWagons": []
}
```
### responce body:
 - code:204
```yaml
```
![DELETE:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/DELETE.png  "DELETE request") __/api/Drivers/{id}__ 

### request parameters:
 - id - 7
### responce body:
 - code:200
```yaml
{
  "id": 7,
  "fullName": "no name",
  "passportNum": " ",
  "driverLicenseNum": " ",
  "adrCertificate": false,
  "driversWagons": []
}
```
Drivers Wagons
------

![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png "GET request")   __api/DriversWagons__ 
### request parameters:
  - __none__
### responce body:
 - code:200
```yaml
[
  {
    "id": 20,
    "driverId": 6,
    "wagonId": 4,
    "wagon": null,
    "driver": null,
    "deliveries": []
  }
]
```
![POST:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/POST.png "POST request") __/api/DriversWagons__ 
### request parameters:
  - __request body:__
```yaml
{
    "driverId": 6,
    "wagonId": 4,
    "wagon": null,
    "driver": null,
    "deliveries": []
}
```  
### responce body: 
 - code:201
```yaml
{
  "id": 43,
  "driverId": 6,
  "wagonId": 4,
  "wagon": null,
  "driver": null,
  "deliveries": []
}
```
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png  "GET request") __/api/DriversWagons/{id}__ 
### request parameters:
  - __id - 43__
### responce body:
 - code:200
```yaml
{
  "id": 43,
  "driverId": 6,
  "wagonId": 4,
  "wagon": null,
  "driver": null,
  "deliveries": []
}
```
![PUT:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/PUT.png "PUT request") __/api/DriversWagons/{id}__ 
### request parameters:
  - __id - 43__
  - __request body:__

```yaml
{
  "id": 43,
  "driverId": 5,
  "wagonId": 4,
  "wagon": null,
  "driver": null,
  "deliveries": []
}
```
### responce body:
 - code:204
```yaml
```
![DELETE:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/DELETE.png  "DELETE request") __/api/DriversWagons/{id}__ 

### request parameters:
 - id - 43
### responce body:
 - code:200
```yaml
{
  "id": 43,
  "driverId": 5,
  "wagonId": 4,
  "wagon": null,
  "driver": null,
  "deliveries": []
}
```
Deliveries
------

![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png "GET request")   __api/Deliveries__ 
### request parameters:
  - __none__
### responce body:
 - code:200
```yaml
[
  {
    "id": 201,
    "driverWagonId": 20,
    "customerCompanyId": 2,
    "loadId": 1,
    "unloadDate": "2020-04-03T12:00:10",
    "address": "Miska street 23/2",
    "driverWagon": null,
    "load": null,
    "customerCompany": null
  },
  {
    "id": 202,
    "driverWagonId": 20,
    "customerCompanyId": 2,
    "loadId": 3,
    "unloadDate": "2020-05-03T12:00:10",
    "address": "Samsoneko street 2",
    "driverWagon": null,
    "load": null,
    "customerCompany": null
  }
]
```
![POST:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/POST.png "POST request") __/api/Deliveries__ 
### request parameters:
  - __request body:__
```yaml
  {
    "driverWagonId": 20,
    "customerCompanyId": 2,
    "loadId": 1,
    "unloadDate": "2021-04-03T12:00:10",
    "address": "M street 23/2",
    "driverWagon": null,
    "load": null,
    "customerCompany": null
  }
```  
### responce body: 
 - code:201
```yaml
{
  "id": 207,
  "driverWagonId": 20,
  "customerCompanyId": 2,
  "loadId": 1,
  "unloadDate": "2021-04-03T12:00:10",
  "address": "M street 23/2",
  "driverWagon": null,
  "load": null,
  "customerCompany": null
}
```
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png  "GET request") __/api/Deliveries/{id}__ 
### request parameters:
  - __id - 207__
### responce body:
 - code:200
```yaml
{
  "id": 207,
  "driverWagonId": 20,
  "customerCompanyId": 2,
  "loadId": 1,
  "unloadDate": "2021-04-03T12:00:10",
  "address": "M street 23/2",
  "driverWagon": null,
  "load": null,
  "customerCompany": null
}
```
![PUT:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/PUT.png "PUT request") __/api/Deliveries/{id}__ 
### request parameters:
  - __id - 207__
  - __request body:__

```yaml
{
  "id": 207,
  "driverWagonId": 20,
  "customerCompanyId": 2,
  "loadId": 1,
  "unloadDate": "2020-04-03T12:00:10",
  "address": "M street 23/2",
  "driverWagon": null,
  "load": null,
  "customerCompany": null
}
```
### responce body:
 - code:204
```yaml
```
![DELETE:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/DELETE.png  "DELETE request") __/api/Deliveries/{id}__ 

### request parameters:
 - id - 207
### responce body:
 - code:200
```yaml
{
  "id": 207,
  "driverWagonId": 20,
  "customerCompanyId": 2,
  "loadId": 1,
  "unloadDate": "2020-04-03T12:00:10",
  "address": "M street 23/2",
  "driverWagon": null,
  "load": null,
  "customerCompany": null
}
```
