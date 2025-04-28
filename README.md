# use of Server:
# Project: OAuthServer

## End-point: CreateUser
### Method: POST
>```
>https://localhost:7062/api/User
>```
### Body (**raw**)

```json
{
  "username": "paulinho1512",
  "password": "estapasssimples"
}
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: CreateClient
### Method: POST
>```
>https://localhost:7062/api/Client
>```
### Body (**raw**)

```json
{
  "name": "App do Lopes",
  "redirectUri": "http://localhost:3000/callback"
}
```


⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: Authorize
### Method: GET
>```
>{{localurl}}/api/OAuth/authorize?response_type=code&clientid=01e399de-5ab3-49d5-992e-3a3d8d7b32c5&redirect_uri=http://localhost:3000/callback&state=randomState123

>```
### Query Params

|Param|value|
|---|---|
|response_type|code|
|clientid|01e399de-5ab3-49d5-992e-3a3d8d7b32c5|
|redirect_uri|http://localhost:3000/callback|
|state|randomState123
|



⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: Token
### Method: POST
>```
>{{localurl}}/api/oauth/Token?grant_type=authorization_code
>```
### Headers

|Content-Type|Value|
|---|---|
|Content-Type|application/x-www-form-urlencoded|


### Query Params

|Param|value|
|---|---|
|grant_type|authorization_code|



⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: PubKey
### Method: GET
>```
>https://localhost:7062/api/Key
>```

⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: protected endpoint
### Method: GET
>```
>https://localhost:7062/api/Key
>```

⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃

## End-point: Login
### Method: POST
>```
>https://localhost:7062/api/User/login?responsetype=code&clientid=eb6cddd0-0cb6-45f2-8151-25de92c86af1&redirecturi=http://localhost:3000/callback&state=randomState123

>```
### Body (**raw**)

```json
{
  "username": "paulinho1512",
  "password": "estapasssimples"
}
```

### Query Params

|Param|value|
|---|---|
|responsetype|code|
|clientid|eb6cddd0-0cb6-45f2-8151-25de92c86af1|
|redirecturi|http://localhost:3000/callback|
|state|randomState123
|



⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃ ⁃
_________________________________________________
Powered By: [postman-to-markdown](https://github.com/bautistaj/postman-to-markdown/)




# on the client side: 
OAUTH_SERVER_URL=http://localhost:5150 place the oauth server api

### place the publick key (got thro the endpoint) 

JWT_SECRET_KEY= -----BEGIN PUBLIC KEY-----MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEArZ8PI5jfSk1QHSYmeQ0+XJgMLbbZV3sq284ZYqQ4m6mBb+ozWPCq4wFiukMBCPQqJhEeHZuUXLBSSb4nvFL2N7ilPslaKjhE2w44w8xtHaIreX8xY8ibpdkbq6oT1nsv1RIP2abphW4hMsuRzkUY/K/q4+imDM9LhDVG24mwIdK+qyB8r39HIC5XG+7JBgPbLoRiOokdSxqIrYv2sZQZcBX0JlSmQXaV8VTdaS2ewGH7YIex6ATmUz1Vgt6YMum2NiPU8kkxs06rxBeZYdT7OZyRdaSwX59MQolv8kL0nLMmmcESQOw7ILNj3aFD0aTi4G9t4rkxjpS8lj/6AlhDcwIDAQAB-----END PUBLIC KEY-----

### your client id (returned when you created the client)
OAUTH_CLIENT_ID=2e068ec4-e39e-4ab6-a4d4-d7624dac3cb2
## the client secret (returned when you created the client)
OAUTH_CLIENT_SECRET=4HJ9GVuNxm83Kp4YpMC7Zw8w/03AUyi1ElHP+B05CbofoTKOotuOrBNzys/3jZ59vPqrwhmWRqiEDEUlp8hTYw==

### the url that you want to redirect your app after the OAuth flow
CALLBACK_URL=http://localhost:3000/callback

### the JWT Issuer
JWT_ISSUER = OAuthServer


### the audience should be the client id
JWT_AUDIENCE = 208db966-ed2b-4668-a193-f3e95602c545