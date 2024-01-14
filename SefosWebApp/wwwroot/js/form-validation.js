document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector("form");
    const sendButton = document.getElementById("sendButton");

    form.addEventListener("submit", function (event) {
        const email = document.getElementById("email").value;
        const subject = document.getElementById("subject").value;
        const message = document.getElementById("message").value;

        //if (email === "" || subject === "" || message === "") {
        //    alert("All fields are required!");
        //    event.preventDefault(); //form  göndermeyi engeller dha sonra bakalim
        //}
    });
});
