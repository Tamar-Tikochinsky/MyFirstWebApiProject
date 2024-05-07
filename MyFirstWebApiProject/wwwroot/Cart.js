const drawCart = () => {
    var arr = JSON.parse(sessionStorage.getItem("cart"));
    var sum = 0;
    for (let i = 0; i < arr.length; i++) {
        temp = document.getElementById("temp-row");
        var clonProduct = temp.content.cloneNode(true);
        clonProduct.querySelector(".imageColumn").src = arr[i].picture;
        clonProduct.querySelector(".itemName").innerText = arr[i].productName;
        clonProduct.querySelector(".price").innerText = arr[i].price + "$";
        clonProduct.querySelector(".totalColumn").addEventListener("click", () => {
            arr.splice(i, 1);
            sessionStorage.setItem("cart", JSON.stringify(arr));
            document.getElementById("itemBody").replaceChildren([]);
            drawCart();
        });
        sum += arr[i].price;
        document.getElementById("itemBody").appendChild(clonProduct);
    }
    document.getElementById("itemCount").innerText = arr.length;
    document.getElementById("totalAmount").innerText = sum;
}

const placeOrder = async () => {
    if (!(JSON.parse(sessionStorage.getItem("user"))))
        window.location.href = "Login.html"

    let productsArray = JSON.parse(sessionStorage.getItem("cart"));
    let orderItemsArray = [];
    for (let i = 0; i < productsArray.length; i++) {
        orderItem = {
            productId: productsArray[i].productId,
            quantity: 1
        }
        orderItemsArray.push(orderItem);
    }

    order = {
        orderDate: new Date(),
        orderSum: parseFloat(document.getElementById("totalAmount").innerText),
        userId: JSON.parse(sessionStorage.getItem("user")).userId,
        orderItems: orderItemsArray
    }

    try {
        const response = await fetch('/api/Order',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            })

        const resOrder = await response.json()
        console.log("the order", resOrder);
        alert("order num: "+resOrder?.orderId+" created succesfuly!!");
    } catch (error) { alert(error, "error") }
    let cart = [];
    sessionStorage.setItem("cart", JSON.stringify(cart))
    location.href="Products.html"
}