function GANNAIstate() {
  this.direction = null;
  //this.identifier = this.sendPOST('pacman/new', {});
  this.identifier = "7";
}

GANNAIstate.prototype = {
  setDirection: function(dir) {
    this.sendPATCH('pacman/' + this.identifier + '/direction', { direction: dir });
  },
  sendPOST: function(sub, data, type) {
    $.post("http://127.0.0.1:4567/pacman/new");
    //return this.sendAjax(sub, data, "POST", type);
  },
  sendAjax: function(sub, data, method, type) {
    data.identifier = this.identifier;

    var response;

    $.ajax({
      type: method,
      url: 'http://127.0.0.1:4567/' + sub,
      data: data,
      dataType: type
    }).success(function(data) {
      response = data;
    });
    return response;
  },
  sendPATCH: function(sub, data) {
    return this.sendAjax(sub, data, "PATCH", "JSON");
  }
}
