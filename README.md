# Project

C# web api whit sqlserver database (docker)

database will store the users and hashed password

this soluction should work whit any standart library OAuth



### User Authentication:

    You provide your credentials (e.g., username and password) to the authentication server.

    The server verifies these credentials.
    Reddit

### Token Issuance:
 
    Upon successful authentication, the server generates a JSON Web Token (JWT).

    This JWT is digitally signed using the server's private key.

    The signed JWT is then sent back to your client application.
    Frontegg+1Curity+1

### Client Stores the Token:

    Your client application stores this JWT, typically in memory or local storage.

    For subsequent requests to backend services, the client includes this JWT in the Authorization header as a Bearer token.

### Backend Service Verification:

    When the backend service receives a request with the JWT, it needs to verify the token's authenticity.​

    To do this, the backend retrieves the public key corresponding to the authentication server's private key.

    This public key is often made available through a JSON Web Key Set (JWKS) endpoint provided by the authentication server.

    Using this public key, the backend service verifies the JWT's signature to ensure it hasn't been tampered with and is indeed issued by the trusted authentication server.



## JWT
for the jwt the ideia is to use a private/public key pair, for the jwt token validation
To verify a JSON Web Token (JWT) signed using asymmetric encryption (e.g., RS256), you need the public key corresponding to the private key that signed the token. This public key is typically provided by the token issuer through a JSON Web Key Set (JWKS) endpoint


