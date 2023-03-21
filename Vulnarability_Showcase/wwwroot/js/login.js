const loginButton = document.querySelector('#login');

loginButton.onclick = function (e) {
    e.preventDefault();

    let username = document.querySelector('#username').value;
    let password = document.querySelector('#password').value;
    
    fetch('/Account/Login', {
        method: 'POST',
        body: JSON.stringify({ username, password }),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(res => res.json())
        .then(data => {
            console.log(data);
            if (data) {
                alert('Login successful!');
                document.location.href = '/Home';
                document.cookie = `username=${data.username}`;
            }
        })
        .catch(_ => {
            alert('There was an error!')
        })
}