# ControllersTest

Trailer Types
------
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png "GET request")   __/api/TrailerTypes__ 
### request parameters:
  - none
### responce:
```json
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
![GET:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/GET.png  "GET request") __/api/TrailerTypes/{id}__ 
### request parameters:
  - id - 2
### responce:
```json
{
  "id": 2,
  "type": "Refrigerated Trailers",
  "trailers": []
}
```
![PUT:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/PUT.png "PUT request") __/api/TrailerTypes/{id}__ 
![DELETE:](https://github.com/ViktoriiaKharchenko/TransportCompanyDatabase/blob/master/images/DELETE.png  "DELETE request") __/api/TrailerTypes/{id}__ 
Customer Companies
------

Loads
------

Trailers
------

Wagons
------

Drivers
------

DriversWagons
------

Deliveries
------
