# Project: OAuthServer
This project is hosted in Azure, whit the url : https://oauthserver.azurewebsites.net

<details>
<summary>Flaws</summary>
Our project have some flaws that we didn't manage to solve, being:

- JWT Token generation, is creating successfully but placing the same id twice in the audience.
- The cookies are successfully created, but expiration is not working very well meaning there might be the need to remove them manually.
</details>


## Setup
In order to test our project, follow this quick Setup guide.

## Create a Client:
Using Postman create a Client that will be used to retrieve the JWT Token from the OAuth Server. To create, choose a name and the desired redirectUri.

**IMPORTANT: After creation, both id and clientSecret will only be displayed once, being necessary to configure the client.**

### Method: POST
>```
>https://oauthserver.azurewebsites.net/api/Client
>```
### Body (**raw**)
```json
{
  "name": "app_name",
  "redirectUri": "http://localhost:3000/callback"
}
```
#### Return 
```json
{
    "id": "fe94558c-d0fd-4272-8602-c6a2f68d574a",
    "name": "app_name",
    "clientSecret": "IOEncMqfrUGGFfIxESJQcP/WNpsukjYCjxOR8tzqnPBEEWlZUj3U8KSMzXLg4nkY7rdiLjsNQXKL+er9hcmdZw==",
    "redirectUri": "http://localhost:3000/callback"
}
```

## Create a User 
Using Postman create a User that will be used to login into the OAuth Server granting access to the Client previously registred. To create, choose a username and a password.

**IMPORTANT: After creation, the user id will be displayed. Save it to check with JWT token later.**
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
#### Return 
```json
{
    "id": "05a031d1-d481-4e9b-b6f4-897c3d26c9a3",
    "username": "paulinho1512"
}
```


## Get the JWT pub key
Using Postman get the public key that can be used to check the signature of the JWT Token, taking into account that the project works with a private/public key encryption.

### Method: GET
>```
>https://oauthserver.azurewebsites.net/api/Key
>```
#### Return
>```
>"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAzyWRTDYj3IxpcOuKG/RHkBEj6LFfTv1EljMmL++bf/F2wLYrwuGNJeVDH7OwKHpd0b4s80WeDLc38OMSEPpDq1WVYa/KOaqb45rDree0T5L5WH9kMtXP1QVJra5Q6geyBGV0cGGwpkvWSeEIkT9WGOsECDWJCXODGNm3gnSi2Qxrpp9ANhkgfK8hCfNt3Do6vblMuq+4U8bwHjjoxiaohPTwEai6+zNhBuPKJkcmZaT/TQ1JS6RBz8Hxf5O+LZWNaymAM+Uu9hNE91p9VnkIqmnuNr+b5dvZykbDtFP90jxqfYlFjcfohPWiTEOqKeyIihIu6TU72JO/of9rxYlGJQIDAQAB"
>```

## Client Setup
To setup the client, there is the need to configure a environment file with the information that we obtained from before, being this file in the following path: 
>```
>express-client/.env
>``` 
**IMPORTANT: This environment file contains important information so the following display is an example on how it should be, not how it is.**

```
OAUTH_SERVER_URL=https://oauthserver.azurewebsites.net

JWT_SECRET_KEY=-----BEGIN PUBLIC KEY-----<Place the obtained public key here without the quotation marks>-----END PUBLIC KEY-----

OAUTH_CLIENT_ID=<The client id obtained before>

OAUTH_CLIENT_SECRET=<The client secret obtained before>

CALLBACK_URL=<The redirectUri chose when creating the client>


JWT_ISSUER = OAuthServer

JWT_AUDIENCE = <The client id obtained before>
``` 

### Run the Client App
Once configurated we can test the Client App accessing the OAuth Server and obtaining the JWT Token, by following the commands:

### Start the app
Once inside the express_client folder, run the following command:
>```
>node server.js
>``` 

### View in browser
Once the app starts running and shows a message saying "Server running on http://localhost:3000", its ready to test. In the browser access http://localhost:3000/login and the OAuth flow will start, requesting permission.


<details>
  <summary><h1>View the API Documentation</summary>

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
<details>