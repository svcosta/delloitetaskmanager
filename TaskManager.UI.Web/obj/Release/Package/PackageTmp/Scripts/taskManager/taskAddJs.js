
if (localStorage.token === "" || localStorage.token === undefined) {
    document.location.replace('/home/index');
}


var model = {
    ddPriority: $('#ddPriority'),
    ddStatus: $('#ddStatus'),
    title: $("#title"),
    description: $("#description"),
    button: $("#btnSubmit"),
    msg: $("#erroMessage")
}


model.msg.hide();


model.button.click(function (e) {

    e.preventDefault();

    if (model.title.val() === "") {
        model.msg.addClass("alert-danger").text("Please,The field Title is obligatory").fadeIn("slow");
        return false;
    }

    if (model.description.val() === "") {
        model.msg.addClass("alert-danger").text("Please,The field Description is obligatory").fadeIn("slow");
        return false;
    }   
   
      $.ajax({
          url: '/Task/Create',
          data: JSON.stringify({
              UserId: localStorage.userId,
              Priority: model.ddPriority.val(),
              Status: "Open",
              Title: model.title.val(),
              Description: model.description.val(),         

          }),
          dataType: 'json',
          contentType: "application/json; charset=utf-8",
          headers: { "Authorization": localStorage.token },
          type: 'POST',
          cache: false,
          success: function (data) {
  
              if (data.result) {                 
                  model.msg.removeClass("alert-danger").addClass("alert-success").text(data.msg).fadeIn("slow");

                  model.title.val("");
                  model.description.val("");

              } else {
                  model.msg.addClass("alert-danger").text(data.msg).fadeIn("slow");
              }  
          }        
      });
    
});

