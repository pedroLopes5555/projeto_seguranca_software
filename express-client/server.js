const express = require('express');
const passport = require('passport');
const OAuth2Strategy = require('passport-oauth2').Strategy;
const jwt = require('jsonwebtoken');
const dotenv = require('dotenv');
const crypto = require('crypto'); // To generate a random state

// Load environment variables from .env
dotenv.config();

const app = express();
app.use(express.json()); // To parse JSON request bodies
app.use(passport.initialize());

const PORT = process.env.PORT || 3000;
const OAUTH_SERVER_URL = process.env.OAUTH_SERVER_URL || 'http://localhost:5150';  // Your OAuth server URL

// Store the state parameter temporarily
let oauthState = ''; // Temporary storage for state (you could store this in a session or database)

// Setup the OAuth2 strategy for Passport
passport.use(
  new OAuth2Strategy(
    {
      authorizationURL: `${OAUTH_SERVER_URL}/api/oauth/authorize`,  // OAuth authorization URL
      tokenURL: `${OAUTH_SERVER_URL}/api/oauth/token`,  // OAuth token URL
      clientID: process.env.OAUTH_CLIENT_ID,  // OAuth client ID from .env
      clientSecret: process.env.OAUTH_CLIENT_SECRET,  // OAuth client secret from .env
      callbackURL: process.env.CALLBACK_URL || 'http://localhost:3000/callback',  // Callback URL
    },
    (accessToken, refreshToken, profile, done) => {
      return done(null, { accessToken, profile });
    }
  )
);

// Route to initiate the OAuth flow
app.get('/login', (req, res) => {
  // Generate a random state and store it temporarily (for demonstration purposes)
  oauthState = crypto.randomBytes(16).toString('hex');
  
  // Redirect the user to the OAuth provider's authorization endpoint
  const authorizationURL = `${OAUTH_SERVER_URL}/api/oauth/authorizepage?response_type=code&client_id=${process.env.OAUTH_CLIENT_ID}&redirect_uri=${process.env.CALLBACK_URL}&state=${oauthState}`;

  // Redirect to the OAuth authorization URL
  res.redirect(authorizationURL);
});

// Callback route for OAuth redirect
app.get(
  '/callback',
  passport.authenticate('oauth2', { failureRedirect: '/login' }),
  async (req, res) => {
    const { accessToken, profile } = req.user;
    const state = req.query.state;

    // Verify that the state parameter matches the one we sent initially
    if (state !== oauthState) {
      return res.status(400).json({ error: 'Invalid state parameter' });
    }

    // Generate a JWT token after successful OAuth authentication
    const jwtToken = jwt.sign({ user: profile }, process.env.JWT_SECRET_KEY || 'your-jwt-secret-key', {
      expiresIn: '1h', // Set JWT expiration time
    });

    res.json({ message: 'Authentication successful', token: jwtToken });
  }
);

// Middleware to protect routes with JWT
function authenticateJWT(req, res, next) {
  const token = req.headers['authorization']?.split(' ')[1];

  if (!token) {
    return res.status(403).json({ error: 'No token provided' });
  }

  jwt.verify(token, process.env.JWT_SECRET_KEY || 'your-jwt-secret-key', (err, user) => {
    if (err) {
      return res.status(403).json({ error: 'Invalid token' });
    }
    req.user = user;
    next();
  });
}

// Protected route
app.get('/protected-endpoint', authenticateJWT, (req, res) => {
  res.json({ message: 'This is a protected endpoint!', user: req.user });
});

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
