//////////////////////////////////////////////////////////////////////////////////////
// Entry Point
var GAME_STATE = Object.create(GANNAIstate.prototype);
GAME_STATE.sendPOST("pacman/new", {}, function(data) {
  GAME_STATE.identifier = data.id;
});

window.addEventListener("load", function() {
  loadHighScores();
  initRenderer();
  atlas.create();
  initSwipe();
  var anchor = window.location.hash.substring(1);
  if (anchor == "learn") {
    switchState(learnState);
  }
  else if (anchor == "cheat_pac" || anchor == "cheat_mspac") {
    gameMode = (anchor == "cheat_pac") ? GAME_PACMAN : GAME_MSPACMAN;
    practiceMode = true;
    switchState(newGameState);
    for (var i=0; i<4; i++) {
      ghosts[i].isDrawTarget = true;
      ghosts[i].isDrawPath = true;
    }
  }
  else {
    switchState(homeState);
  }
  executive.init();

});
