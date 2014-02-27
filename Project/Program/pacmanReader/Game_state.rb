class GameState
  attr_accessor :direction

  def initialize
  end

  def getID
    object_id
  end

  def getDirection 
    dirTo_s(@direction)
  end
  
  private

  def dirTo_s(dir)
    if dir == "0"
      "up"
    elsif dir == "1"
      "left"
    elsif dir == "2"
      "down"
    elsif dir == "3"
      "right"
    else
      "none"
    end
  end
end
