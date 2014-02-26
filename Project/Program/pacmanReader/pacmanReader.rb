require 'sinatra'
#require 'sinatra/respond_with'
#require 'sinatra/json'
require 'json'

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

post '/pacman/new' do
  puts params.inspect
  
  gs = GameState.new

  content_type :json

  { id: gs.object_id }.to_json
end

get '/pacman/:id/direction.json' do
  @gs = GameState.find(params[:id])

  content_type :json
  {direction: @gs.direction}.to_json
end

get '/pacman/:id/direction' do
  @gs = GameState.find(params[:id])

  body direction

end

post '/pacman/:id/direction' do
  puts params
  # Circumvent same-origin policy 
  response['Access-Control-Allow-Origin'] = '*'

  @gs = GameState.find(params[:id])
  @gs.direction = params[:direction]

  body "It works!"
end
