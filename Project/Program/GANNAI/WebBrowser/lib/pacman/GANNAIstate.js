function GANNAIstate() {
  this.direction = null;
  this.identifier = 0;
}

GANNAIstate.prototype = {
  setDirection: function(dir) {
    this.sendPATCH('pacman/' + this.identifier + '/direction',
        { direction: dir });
  },
  sendAjax: function(sub, data, method, callback) {
    data.identifier = this.identifier;

    var response;

    $.ajax({
      type: method,
      url: 'http://127.0.0.1:9292/' + sub,
      data: data,
      dataType: "JSON"
    }).success(function(data) {
      if(callback) {
        callback(data);
      }
    });
    return response;
  },
  sendPOST: function(sub, data, callback) {
    this.sendAjax(sub, data, "POST", callback);
  },
  sendPATCH: function(sub, data, callback) {
    this.sendAjax(sub, data, "PATCH", callback);
  }
}
