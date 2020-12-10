// ************************************************
// Shopping Cart API
// ************************************************
var shoppingCart = (function () {
    // =============================
    // Private methods and propeties
    // =============================
    cart = [];

    // Constructor
    function Item(name, price, amountnight, roomtypeid) {
        this.name = name;
        this.price = price;
        this.amountnight = amountnight;
        this.roomtypeid = roomtypeid;
    }

    // Constructor current roomtype
    function CurrentRoomtype(limitamountroom, roomtypeidcurrent) {
        this.limitamountroom = limitamountroom;
        this.roomtypeidcurrent = roomtypeidcurrent;
    }

    // Save cart 
    function saveCart() {
        sessionStorage.setItem('shoppingCart', JSON.stringify(cart));
    }

    // Load cart 
    function loadCart() {
        cart = JSON.parse(sessionStorage.getItem('shoppingCart'));
    }
    if (sessionStorage.getItem("shoppingCart") != null) {
        loadCart();
    }


    // =============================
    // Public methods and propeties
    // =============================
    var obj = {};

    // Add to cart
    obj.addItemToCart = function (name, price, amountnight, roomtypeid) {
       
        var item = new Item(name, price, amountnight, roomtypeid);
        cart.push(item);
        saveCart();
    }

    //save currentroomtype
    obj.savecurrentroomtype = function (limitamountroom, roomtypeidcurrent) {
        var currentroomtype = new CurrentRoomtype(limitamountroom, roomtypeidcurrent);
        sessionStorage.setItem('currentroomtype', JSON.stringify(currentroomtype));
    }

    //check over limit
    obj.isoverlimit = function (roomtypeid) {
        var currentroomtype = JSON.parse(sessionStorage.getItem("currentroomtype"));
        if (currentroomtype == null) {
            return true;
        }
        var countroomtype = 0;

        for (var item in cart) {
            if (cart[item].roomtypeid == roomtypeid) {
                countroomtype++;
            }
        }
        console.log(countroomtype);
        if (countroomtype < currentroomtype.limitamountroom) {
            return true;
        }
        return false;
    }

    // Remove all items from cart
    obj.removeItemFromCartAll = function (roomtypeid) {
        for (var item in cart) {
            if (cart[item].roomtypeid == roomtypeid) {
                cart.splice(item, 1);
                break;
            }
        }
        saveCart();
    }

    // Clear cart
    obj.clearCart = function () {
        cart = [];
        saveCart();
    }

    // Count cart 
    obj.totalCount = function () {
        return cart.length;
    }

    //format currency vnd style
    obj.formatcurrency = function (money) {
        return money.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
    }

    // Total cart
    obj.totalCart = function () {
        var totalCart = 0;
        for (var item in cart) {
            totalCart += cart[item].price * cart[item].amountnight;
        }
        return this.formatcurrency(totalCart);
    }

    // List cart copy from cart and create properties total = item.price * item.count
    obj.listCart = function () {
        var cartCopy = [];
        for (i in cart) {
            item = cart[i];
            itemCopy = {};
            for (p in item) {
                itemCopy[p] = item[p];
            }
            itemCopy.total = item.price * item.amountnight;
            cartCopy.push(itemCopy)
        }
        return cartCopy;
    }

    // cart : Array
    // Item : Object/Class
    // addItemToCart : Function
    // removeItemFromCart : Function
    // removeItemFromCartAll : Function
    // clearCart : Function
    // countCart : Function
    // totalCart : Function
    // listCart : Function
    // saveCart : Function
    // loadCart : Function
    return obj;
})();

var bookingdate = {};

bookingdate.title = "";
bookingdate.amountnight = 0;
bookingdate.checkindate = new Date();
bookingdate.checkoutdate = new Date();

bookingdate.savebookingdate = function (checkin, checkout) {

    bookingdate.title = checkin + " Đến ngày " + checkout;
    bookingdate.checkindate = new Date(checkin);
    bookingdate.checkoutdate = new Date(checkout);

    var millisecondsPerDay = 1000 * 60 * 60 * 24;
    var millisBetween = bookingdate.checkoutdate.getTime() - bookingdate.checkindate.getTime();
    var days = millisBetween / millisecondsPerDay;
    bookingdate.amountnight = Math.floor(days);
    sessionStorage.setItem('bookingdate', JSON.stringify(bookingdate));
}


// *****************************************
// Triggers / Events
// ***************************************** 
// Add item
$('.add-to-cart').click(function (event) {
    event.preventDefault();
    debugger
    var name = $(this).data('name');
    var price = Number($(this).data('price'));
    var roomtypeid = Number($(this).data('roomtypeid'));
    if (shoppingCart.isoverlimit(roomtypeid) == true) {
        var bookingdatecopy = JSON.parse(sessionStorage.getItem('bookingdate'));
        shoppingCart.addItemToCart(name, price, bookingdatecopy.amountnight, roomtypeid);
        displayCart();
    } else {
        bootbox.alert("Đả hết phòng trống!");
    }
});

// Clear items
$('.clear-cart').click(function () {
    shoppingCart.clearCart();
    displayCart();
});

//title for cart modal
$(document).ready(function () {
    var bookingdatecopy = JSON.parse(sessionStorage.getItem('bookingdate'));
    if (bookingdatecopy == null) {
        checkin = $("#date-in").val();
        checkout = $("#date-out").val();
        bookingdate.savebookingdate(checkin, checkout);
        $("#exampleModalLabel").html(bookingdate.title);
    } else {
        $("#exampleModalLabel").html(bookingdatecopy.title);
    }
    var currentroomtypecopy = JSON.parse(sessionStorage.getItem('currentroomtype'));
    var limitamountroom = $("#limitamountroom").data("limitamount");
    var roomtypeidcurrent = $("#limitamountroom").data("roomtypeidcurrent");

    if (currentroomtypecopy == null && limitamountroom != undefined) {
        shoppingCart.savecurrentroomtype(limitamountroom, roomtypeidcurrent);
    }
    if (limitamountroom != undefined) {
        shoppingCart.savecurrentroomtype(limitamountroom, roomtypeidcurrent);
    }
});

$(".date-input").on("change", function () {
    var checkin = $("#date-in").val();
    var checkout = $("#date-out").val();
    bookingdate.savebookingdate(checkin, checkout);
    $("#exampleModalLabel").html(bookingdate.title);
});
//end title for cart modal


function displayCart() {
    var cartArray = shoppingCart.listCart();
    var bookingdateinfo = JSON.parse(sessionStorage.getItem('bookingdate'));
    var output = "";
    $("#exampleModalLabel").html(bookingdateinfo.title);
    for (var i in cartArray) {
        output += "<tr rowspan='2'>"
            + "<td >" + cartArray[i].name + "</td>"
            + "<td>" + shoppingCart.formatcurrency(cartArray[i].price ) + "</td>"
            + "<td>" + cartArray[i].amountnight + "</td>"
            + "<td>" + shoppingCart.formatcurrency(cartArray[i].total) + "</td>"
            + `<td><button class='delete-item btn btn-danger' data-roomtypeid=${cartArray[i].roomtypeid} >X</button></td>`
            + "</tr>";
    }
    $('.show-cart>tbody').html(output);
    $('.total-cart').html(shoppingCart.totalCart());
    $('.total-count').html(shoppingCart.totalCount());
}

// Delete item button

$('.show-cart').on("click", ".delete-item", function (event) {
    var roomtypeid = $(this).data("roomtypeid");
    shoppingCart.removeItemFromCartAll(roomtypeid);
    displayCart();
})

$("#clearcart").on("click", function () {
    shoppingCart.clearCart();
    displayCart();
})

// Item count input
$('.show-cart').on("change", ".item-count", function (event) {
    var name = $(this).data('name');
    var count = Number($(this).val());
    shoppingCart.setCountForItem(name, count);
    displayCart();
});
