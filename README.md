


# Project: OAuthServer
This project is hosted in Azure, whit the url : https://oauthserver.azurewebsites.net
This OAuth server project works whit any generic Oauth library

You can test this project whit the client on this repo, or whit any client
Configure the client and run. 




## Setup
### Create a Client:
The first step is to create a client

#### Method: POST
>```
>https://oauthserver.azurewebsites.net/api/Client
>```
### Body (**raw**)

```json
{
  "name": "App do Lopes",
  "redirectUri": "http://localhost:3000/callback"
}
```
Enter your project name, and callback uri, this endpoint will return a json whit your client id, name, secret and redirect uri

```json
{
    "id": "fe94558c-d0fd-4272-8602-c6a2f68d574a",
    "name": "My new Application",
    "clientSecret": "IOEncMqfrUGGFfIxESJQcP/WNpsukjYCjxOR8tzqnPBEEWlZUj3U8KSMzXLg4nkY7rdiLjsNQXKL+er9hcmdZw==",
    "redirectUri": "http://localhost:3000/callback"
}
```

## Create a User 

The you need to create a user

Call this endpoint
### Method: POST
>```
>https://oauthserver.azurewebsites.net/api/User
>```
### Body (**raw**)

```json
{
  "username": "paulinho1512",
  "password": "estapasssimples"
}
```

The Api will return:
```json
{
    "id": "05a031d1-d481-4e9b-b6f4-897c3d26c9a3",
    "username": "pedro"
}
```


## Get the JWT pub key
the JWT on this project works whit a private/public key encription for the JWT signatures,so, for this work you should get the pubkey:

### Method: GET
>```
>https://oauthserver.azurewebsites.net/api/Key
>```
result: 
"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAzyWRTDYj3IxpcOuKG/RHkBEj6LFfTv1EljMmL++bf/F2wLYrwuGNJeVDH7OwKHpd0b4s80WeDLc38OMSEPpDq1WVYa/KOaqb45rDree0T5L5WH9kMtXP1QVJra5Q6geyBGV0cGGwpkvWSeEIkT9WGOsECDWJCXODGNm3gnSi2Qxrpp9ANhkgfK8hCfNt3Do6vblMuq+4U8bwHjjoxiaohPTwEai6+zNhBuPKJkcmZaT/TQ1JS6RBz8Hxf5O+LZWNaymAM+Uu9hNE91p9VnkIqmnuNr+b5dvZykbDtFP90jxqfYlFjcfohPWiTEOqKeyIihIu6TU72JO/of9rxYlGJQIDAQAB"


the pubkey is betwin "".

## Client side setup

Set up the server url, the key, the client id, the secret, the JWT issuers and audiencies
OAUTH_SERVER_URL=http://localhost:5150 place the oauth server api

JWT_SECRET_KEY= -----BEGIN PUBLIC KEY-----MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEArZ8PI5jfSk1QHSYmeQ0+XJgMLbbZV3sq284ZYqQ4m6mBb+ozWPCq4wFiukMBCPQqJhEeHZuUXLBSSb4nvFL2N7ilPslaKjhE2w44w8xtHaIreX8xY8ibpdkbq6oT1nsv1RIP2abphW4hMsuRzkUY/K/q4+imDM9LhDVG24mwIdK+qyB8r39HIC5XG+7JBgPbLoRiOokdSxqIrYv2sZQZcBX0JlSmQXaV8VTdaS2ewGH7YIex6ATmUz1Vgt6YMum2NiPU8kkxs06rxBeZYdT7OZyRdaSwX59MQolv8kL0nLMmmcESQOw7ILNj3aFD0aTi4G9t4rkxjpS8lj/6AlhDcwIDAQAB-----END PUBLIC KEY-----

OAUTH_CLIENT_ID=2e068ec4-e39e-4ab6-a4d4-d7624dac3cb2

OAUTH_CLIENT_SECRET=4HJ9GVuNxm83Kp4YpMC7Zw8w/03AUyi1ElHP+B05CbofoTKOotuOrBNzys/3jZ59vPqrwhmWRqiEDEUlp8hTYw==


CALLBACK_URL=http://localhost:3000/callback

JWT_ISSUER = OAuthServer


JWT_AUDIENCE = 208db966-ed2b-4668-a193-f3e95602c545





# Rest of the API documentation
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

