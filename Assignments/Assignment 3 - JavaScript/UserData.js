// Function to toggle between Signup and Login forms
function toggleForm() {
    const signupForm = document.getElementById('signup-form');
    const loginForm = document.getElementById('login-form');
    
    if (signupForm.style.display === 'none') {
      signupForm.style.display = 'block';
      loginForm.style.display = 'none';
    } else {
      signupForm.style.display = 'none';
      loginForm.style.display = 'block';
    }
  }
  
  // Function to sign up a new user
  function signUp() {
    const username = document.getElementById('signup-username').value;
    const password = document.getElementById('signup-password').value;
  
    if (username && password) {
      // Store user data in localStorage
      localStorage.setItem(username, password);
      alert('Signup successful! You can now log in.');
      toggleForm(); // Switch to login form
    } else {
      alert('Please fill in both fields.');
    }
  }
  
  // Function to log in an existing user
  function logIn() {
    const username = document.getElementById('login-username').value;
    const password = document.getElementById('login-password').value;
  
    if (username && password) {
      const storedPassword = localStorage.getItem(username);
  
      if (storedPassword === password) {
        alert('Login successful!');
      } else {
        alert('Invalid username or password.');
      }
    } else {
      alert('Please fill in both fields.');
    }
  }
  