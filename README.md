# Android wants to connect with server 
## GET api\CarTask params: car_id=""
```
{
  "customer_phone": "customer_phone",
  "department_date": "2012-03-19T07:22Z",
  "department_place": "name of place",
  "department_coords": "{0} {1}",
  "destination_place": "name of place",
  "destination_coords": [
    0,
    1
  ],
  "requirements": {
    "temperature": [
      -20,
      36
    ],
    "humidity": [
      40,
      60
    ],
    "preassure": [
      1212,
      1213
    ]
  },
  "description": "optional"
}
```

# Android sends his data to serv
## POST api\Orders\  param: jsoned="(&)"
## Ans status ok
**(&)**
```
[
{
  "order_id": "order_id",
  "time": "2012-03-19T07:22Z",
  "measurements": "хуйня, которая упала с сервака",
  "coords": "{0} {1}"
}, ...
]
```

# Browser wants car list capable to do his biding
## GET params: car_params="(\*)", department_coords="{0} {1}", department_time=""

### (\*)
```
{
    "temperature": [
      -20,
      36
    ],
"humidity": [
      40,
      60
    ],
    "preassure": [
      1212,
      1213
    ]
 }
```
### Ans
```
[
  {
    "car_id": "car_id",
    "capabilities": {
      "temperature": [
        -20,
        36
      ],
      "humidity": [
        40,
        60
      ],
      "preassure": [
        1212,
        1213
      ]
    },
    "info": "белиберда какая-то"
  }, ...
]
```

# Browser wants to ORDER
## POST api\OrderCar params: (
##            string Car_id,          
##            string Department_time,
  ##          string Department_place,
  ##          string Department_coords,
  ##          string Destination_place,
  ##          string Destination_coords,
  ##          string Requirements,  
##            string Description = ""     
  ##          )

```
{ "status":"ok" }
```

# Browser wants detales on cars 
## GET param: order_id="", coord="{0} {1}" ИЛИ time="time"

```
  {
    "coords": [0, 1],

"time": "time"
    "capabilities": {
      "temperature": [
        -20,
        36
      ],
      "humidity": [
        40,
        60
      ],
      "preassure": [
        1212,
        1213
      ]
    }
  }
```

# Browser wants coord for map
## GET  api/OrdersMapping params: order_id="{0} {1} {2} ..." 

```
[
  {
    "order_id": "order_id",
    "coords": [
      [
        0,
        1
      ],...
    ]
  }, ...
]
```

# Browser wants list of orders
## GET param: client_id=""

```
[
   {
       "order_id" : "order_id",
       "department_place": "department_place",
       "destination_place": "destination_place",
       "description": "description"
   },
]
```

# Browser creates user
## POST api\client params: (string name, string phone, string email = "")

**ANS** status


# Browser wants id of user by phone + name
## GET api\client params: (string name, string phone)

**ANS** status, client_id


# Browser wants user info by id
## GET api\client params: (string id)

**ANS** status, name, phone, email
