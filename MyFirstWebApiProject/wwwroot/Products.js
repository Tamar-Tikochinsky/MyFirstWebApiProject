const fetchProducts = async (url='') => {
    try {
        const response = await fetch(`/api/Products${url}`,
            {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            })

        const products = await response.json()
        console.log("products", products);
        for (var i = 0; i < products.length; i++) {
            drawProduct(products[i]);
        }
    } catch (error) { alert(error, "error") }
    
}

const drawProduct = (product) => {
    if (!(JSON.parse(sessionStorage.getItem("user")))
        && !(JSON.parse(sessionStorage.getItem("cart")))) {
        let cart = [];
        sessionStorage.setItem("cart", JSON.stringify(cart));
    }
    temp = document.getElementById("temp-card");
    var clonProducts = temp.content.cloneNode(true);
    clonProducts.querySelector("img").src = product.picture;
    clonProducts.querySelector("h1").innerText = product.productName;
    clonProducts.querySelector(".price").innerText = product.price + "$";
    clonProducts.querySelector(".description").innerText = product.description;
    clonProducts.querySelector("button").addEventListener("click", () => {

        //פונקציה של הוספה לסל
        var sessionStorageArr = [];
        sessionStorageArr = JSON.parse(sessionStorage.getItem('cart')) || [];
        sessionStorageArr.push(product);
        sessionStorage.setItem('cart', JSON.stringify(sessionStorageArr));
        console.log(sessionStorage.getItem("cart"));
        document.getElementById("ItemsCountText").innerText = sessionStorageArr.length;
    });
    document.getElementById("ProductList").appendChild(clonProducts);
    document.getElementById("ItemsCountText").innerText = (JSON.parse(sessionStorage.getItem("cart"))?.length)
}

const fetchCategory =async () => {
    try {
        const response = await fetch(`/api/Category`,
            {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            })

        const category = await response.json()
        console.log("products", category);
        for (var i = 0; i < category.length; i++) {
            displayCategory(category[i]);
        }
    } catch (error) { alert(error, "error") }
}

var idOfCategory = [];
const displayCategory = (category) => {
    temp = document.getElementById("temp-category");
    var clonCategory = temp.content.cloneNode(true);
    clonCategory.querySelector(".OptionName").innerText = category.categoryName;
    var a = clonCategory.querySelector(".opt")
    a.addEventListener("change", () => {
        if (a.checked) {
            idOfCategory.push(category.categoryId)
            console.log("categoriesAdd", idOfCategory)
        }
        else {
            for (var i = 0; i < idOfCategory.length; i++) {
                if (idOfCategory[i] == category.categoryId)
                {
                    idOfCategory.splice(i, 1);
                    console.log("categoriesReduce", idOfCategory);
                }
            }
        }
        if (idOfCategory.length == 0) fetchProducts();
        const urlCategory = `${encodeURIComponent(idOfCategory)}`;
        filterProducts(idOfCategory);
    });

    document.getElementById("categoryList").appendChild(clonCategory);
}

async function filterProducts(idOfCategory = []) {
    var description = document.getElementById('nameSearch').value;
    var url = `?desc=${encodeURIComponent(description)}`;
    var maxPrice = document.getElementById("maxPrice").value;
    var minPrice = document.getElementById("minPrice").value;
    url +=`&minPrice=${minPrice}&maxPrice=${maxPrice}`;
    for (var j = 0; j < idOfCategory.length; j++)
        { url +=`&categoryIdys=${idOfCategory[j]}` }
    document.getElementById("ProductList").innerHTML = "";
    fetchProducts(url);
}





