const express = require('express');
const passport = require('passport');
const OAuth2Strategy = require('passport-oauth2').Strategy;
const jwt = require('jsonwebtoken');
const dotenv = require('dotenv');

// Load environment variables
dotenv.config();

const app = express();
app.use(express.json());
app.use(passport.initialize()); // No session management

const PORT = process.env.PORT || 3000;
const OAUTH_SERVER_URL = process.env.OAUTH_SERVER_URL || 'http://localhost:5150';

// Store the state parameter temporarily
let oauthState = '';

passport.use(
    new OAuth2Strategy(
      {
        authorizationURL: `${OAUTH_SERVER_URL}/api/oauth/authorizepage`,
        tokenURL: `${OAUTH_SERVER_URL}/api/oauth/Token`,
        clientID: process.env.OAUTH_CLIENT_ID,
        clientSecret: process.env.OAUTH_CLIENT_SECRET,
        callbackURL: process.env.CALLBACK_URL || 'http://localhost:3000/callback',
        debug: true,
      },
      (accessToken, refreshToken, params, profile, done) => {
        // Log the OAuth2 flow details
        console.log('OAuth2 Token Request:');
        console.log('Access Token:', accessToken);
        console.log('Refresh Token:', refreshToken);
        console.log('Params:', params);  // Log all parameters returned by OAuth2 server
  
        // Check for any specific error response (e.g., error_code, error_description)
        if (params.error) {
          console.error('OAuth2 Error:', params.error);
          console.error('Error Description:', params.error_description);
        }
  
        // Process the successful response
        return done(null, { accessToken });
      }
    )
);

// Route to initiate OAuth2 login
app.get('/login', (req, res, next) => {
  console.log("Initiating OAuth2 login...");
  passport.authenticate('oauth2', { session: false })(req, res, next); // Disable session here
});

// OAuth2 callback endpoint
app.get(
  '/callback',
  (req, res, next) => {
    console.log("Callback received. Handling OAuth2 callback...");
    next();
  },
  passport.authenticate('oauth2', { failureRedirect: '/login', session: false }), // Disable session here
  (req, res) => {
    console.log("OAuth2 Authentication completed successfully.");
    const { accessToken } = req.user;
    console.log("Access Token received in callback:", accessToken);
    res.json({ message: 'Authentication successful', accessToken });
  }
);

// Middleware to protect routes and log details
function authenticateJWT(req, res, next) {
  const token = req.headers['authorization']?.split(' ')[1];

  if (!token) {
    console.error("No token provided in the request.");
    return res.status(403).json({ error: 'No token provided' });
  }

  console.log("Verifying JWT...");
  jwt.verify(token, process.env.JWT_SECRET_KEY || 'your-jwt-secret-key', (err, user) => {
    if (err) {
      console.error("Invalid token:", err.message);
      return res.status(403).json({ error: 'Invalid token' });
    }

    console.log("JWT verified. User:", user);
    req.user = user;
    next();
  });
}

// Protected route
app.get('/protected-endpoint', authenticateJWT, (req, res) => {
  console.log("Accessing protected endpoint...");
  res.json({ message: 'This is a protected endpoint!', user: req.user });
});

// Log when the server starts
app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
