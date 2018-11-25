var model = {
    userName: $('#userName'),
    password: $('#password'),
    button: $("#btnLogin"),
    msg: $("#erroMessage")
}

model.msg.hide();

model.button.click(function (e) {

    e.preventDefault();

    if (model.userName.val() === "") {
        model.msg.fadeIn("slow");
        return false;
    }

    if (model.password.val() === "") {
        model.msg.fadeIn("slow");
        return false;
    }
  
    $.ajax({
        url: '/User/GetToken',
        data: JSON.stringify({
            userName: model.userName.val(),
            password: model.password.val()
        }),

        contentType: "application/json; charset=utf-8",
        type: 'POST',
        cache: false,
        success: function (data) {          
            if (data.token) {
                //storage user id
                localStorage.userId = data.id;
                //storage token
                localStorage.token = data.token;
                //redirect page 
                document.location.replace('/task/index');

            } else {
                model.msg.text(data.msg)
                model.msg.fadeIn("slow");
            }
        }       
    });


});

