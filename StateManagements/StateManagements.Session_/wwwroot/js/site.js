let basketCount = 0;
const basket = document.getElementById("basket-count");
const total = document.getElementById("total-sum");
const sidebarTotal = document.getElementById("sidebar-total");
const sidebar = document.getElementById("sidebar-items");
const remove = document.getElementById("sidebar-remove");
let basketItems = [];
$(() => {

    $('.cart').on('click', (e) => {
        let sum = 0;
        let currentItem = e.currentTarget;


        let itemId = currentItem.parentElement.parentElement.parentElement.parentElement.parentElement.getAttribute("data-id");
        $.ajax({
            url: '/Cart/Add/' + itemId,
            method: 'POST',
            success: (data) => {
                basketItems = data;

                //Increasing the visible basket count
                basket.innerText = basketItems.length;

                //Increasing the visible price total;
                for (let i = 0; i < basketItems.length; i++) {
                    sum += basketItems[i].total;
                }
                total.innerText = "$" + sum;
                sidebarTotal.innerText = "$" + sum;

                console.log(sum);
                console.log(basketItems);

                //Adding to sidebar
                sidebar.innerHTML = ``;
                for (let i = 0; i < basketItems.length; i++) {
                    let listItem = `<li>
                                        <div class="sc-productwrap">
                                            <div class="sc-product-details">
                                                <a href="product_details.html" class="sc-product-ttl">${basketItems[i].name}</a>
                                                <p class="sc-product-sz">Size : Medium</p>
                                            </div>
                                        </div>
                                        <div class="sc-quantity">
                                            ${basketItems[i].count}X <span class="sc-price"> ${basketItems[i].total}</span>
                                        </div>
                                        <a data-id="${basketItems[i].id}" id="sidebar-remove" href="javascript:void(0);" onClick="removeHandler(this)" class="sc-produc-remove">X</a>
                                    </li>`;



                    sidebar.innerHTML += listItem;
                }
            },
            error: (err) => { console.log(err) }
        })

    })


})

function removeHandler(e) {
    let sum = 0;

    let currentItem = e;
    let itemId = currentItem.getAttribute("data-id");


    $.ajax({
        url: '/Cart/Remove/' + itemId,
        method: 'POST',
        success: (data) => {
            basketItems = data;

            //Increasing the visible basket count
            basket.innerText = basketItems.length;

            //Increasing the visible price total;
            for (let i = 0; i < basketItems.length; i++) {
                sum += basketItems[i].total;
            }
            total.innerText = "$" + sum;
            sidebarTotal.innerText = "$" + sum;

            console.log(sum);
            console.log(basketItems);

            //Adding to sidebar
            sidebar.innerHTML = ``;
            for (let i = 0; i < basketItems.length; i++) {
                let listItem = `<li>
                                    <div class="sc-productwrap">
                                        <div class="sc-product-details">
                                            <a href="product_details.html" class="sc-product-ttl">${basketItems[i].name}</a>
                                            <p class="sc-product-sz">Size : Medium</p>
                                        </div>
                                    </div>
                                    <div class="sc-quantity">
                                        ${basketItems[i].count}X <span class="sc-price"> ${basketItems[i].total}</span>
                                    </div>
                                    <a data-id="${basketItems[i].id}" href="javascript:void(0);" class="sc-produc-remove">X</a>
                                </li>`;

                sidebar.innerHTML += listItem;
            }
        },
        error: (err) => { console.log(err) }
    })
}

//let currentItem = e.currentTarget;

//let itemId = currentItem.getAttribute("data-id");

//$.ajax({
//    url: '/Cart/Remove/' + itemId,
//    method: 'GET',