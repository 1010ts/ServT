# Andruha wants to connect with server 
## GET params: car_id=""
```
{
  "customer_id": "customer_id",
  "department_date": "2012-03-19T07:22Z",
  "department_place": "name of place",
  "department_coords": [
    0,
    1
  ],
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

# Andruha sends his data to serv
## POST param: jsoned=""
```
[
{
  "car_id": "car_id",
  "current_time": "2012-03-19T07:22Z",
  "measurements": "хуйня, которая упала с сервака",
  "current_coords": [
    0,
    1
  ]
}, ...
]
```

# Bro wants car list capable to do his biding
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

# Bro wants to ORDER
## POST params: customer_id="", 
## car_id="", 
## car_params="(\*)", 
## department_coords="{0} {1}", 
## department_place="", 
## department_time="", 
## destination_coords="{0} {1}", 
## destination_place="", 
## description=""

```
{ "status":"ok" }
```

# Bro wants detales on cars 
## GET param: coord="{0} {1}" или time="time"

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

# Bro wants coord for map
## GET params: order_id="{0} {1} {2} ..." 

```
[
  {
    "order_id": "order_id",
    "car_id": "car_id",
    "coords": [
      [
        0,
        1
      ],...
    ]
  }, ...
]
```

