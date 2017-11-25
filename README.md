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
  "arriving_place": "name of place",
  "arriving_coords": [
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
