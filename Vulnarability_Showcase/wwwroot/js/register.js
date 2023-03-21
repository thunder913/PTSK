const registerButton = document.querySelector('#register');


registerButton.onclick = function (e) {
    e.preventDefault();

    let username = document.querySelector('#username').value;
    let password = document.querySelector('#password').value;
    let confirmPassword = document.querySelector('#confirm-password').value;
    let firstName = document.querySelector('#first-name').value;
    let lastName = document.querySelector('#last-name').value;
    let egn = document.querySelector('#egn').value;
    let address = document.querySelector('#address').value;
    const egnRegex = /^\d{10}$/;

    if (username.length < 3 || username.length > 32) {
        alert('Username must be between 3 and 32 characters long.');
        return;
    } else if (password != confirmPassword) {
        alert('Passwords do not match.');
        return;
    } else if (password.length < 8) {
        alert('Password must be at least 8 characters long.');
        return;
    } else if (firstName.length < 2) {
        alert('First name must be at least 2 characters long.');
        return;
    } else if (lastName.length < 2) {
        alert('Last name must be at least 2 characters long.');
        return;
    } else if (!egnRegex.test(egn)) {
        alert('The egn must be exactly 10 numbers!')
        return;
    } else if (!address) {
        alert('Address cannot be empty!');
        return;
    }

    fetch('/Account/Register', {
        method: 'POST',
        body: JSON.stringify({ username, password, confirmPassword, firstName, lastName, egn, address }),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(res => res.json())
        .then(data => {
            console.log(data);
            if (data) {
                alert('Registration successful!');
                document.location.href = '/Login';
            } 
        })
        .catch(_ => {
            alert('There was an error!')
        })
}