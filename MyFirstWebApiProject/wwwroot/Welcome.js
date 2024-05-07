// Function to display custom alert
const showCustomAlert = (message) => {
    const modal = document.getElementById('customAlert');
    const alertMessage = document.getElementById('alertMessage');

    alertMessage.innerHTML = message;
    modal.style.display = 'block';
}

// Function to close custom alert
const closeCustomAlert = () => {
    const modal = document.getElementById('customAlert');
    modal.style.display = 'none';
}

const checkPassword = () => {
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var password = document.getElementById("passInput").value;
    var progress = document.getElementById("password-strength-progress");
    var text = document.getElementById('password-strength-text');

    var result = zxcvbn(password);
    if (result.score <= 2) {
        showCustomAlert("Your password is weak! Please try again.");
        //document.getElementById("passInput").value = null;
    }

    // Update the password strength progress
    progress.value = result.score;

    // Update the text indicator
    if (password !== "") {
        text.innerHTML = "Strength: " + strength[result.score];
    } else {
        text.innerHTML = "";
    }
}

const registerFunc = async () => {
    const user = {
        Email: document.getElementById("emailInput").value,
        LastName: document.getElementById("lnInput").value,
        FirstName: document.getElementById("fnInput").value,
        UserName: document.getElementById("usInput").value,
        Password: document.getElementById("passInput").value
    }

    try {
        const response = await fetch('/api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        if (response.status != 200) {
            if (response.status == 204) {
                showCustomAlert("Password is too weak. Please choose a stronger password.");
            } else {
                showCustomAlert("User not added. Please try again.");
            }
        } else {
            const DataPost = await response.json();
            showCustomAlert("User successfully created!");
            console.log("New user created ->", DataPost);
        }

    } catch (error) {
        showCustomAlert("An error occurred. Please try again later.");
        console.error(error);
    }
}

const loginFunc = async () => {
    userToLogin = {
        UserName: document.getElementById("usLogiInput").value,
        Password: document.getElementById("passLoginInput").value
    }

    try {
        const response = await fetch('/api/Users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userToLogin)
        });

        if (response.status != 200) {
            showCustomAlert("User not found. Please check your credentials.");
            return;
        } else {
            const resUser = await response.json();
            showCustomAlert("Login successful!");
            console.log("User:", resUser);
            sessionStorage.setItem("user", JSON.stringify(resUser));
            window.location.href = "Products.html";
        }
    } catch (error) {
        showCustomAlert("An error occurred. Please try again later.");
        console.error(error);
    }
}

const updateFunc = async () => {
    if (!(JSON.parse(sessionStorage.getItem("user")))) {
        window.location.href = "Login.html";
    } else {
        const user = {
            email: document.getElementById("emailInput").value,
            lastname: document.getElementById("lnInput").value,
            firstname: document.getElementById("fnInput").value,
            username: document.getElementById("usInput").value,
            password: document.getElementById("passInput").value,
        }

        try {
            const id = (JSON.parse(sessionStorage.getItem("user"))).userId
            const response = await fetch(`/api/Users/${id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });
            const responseBody = await response.json();
            if (response.ok && responseBody.message === "Success!") {
                showCustomAlert("User successfully updated!");
            }
            else if (response.status === 400 && responseBody.message ==="Your password is too weak") { 
                showCustomAlert("password's too weak!")
            }else
                showCustomAlert("An error occurred. Please try again later.");
            
        } catch (error) {
            console.error(error);
        }
    }
}
