require 'sinatra/base'
#require 'sinatra/respond_with'
#require 'sinatra/json'
require 'json'
require './game_state'

class PacmanReader < Sinatra::Base

  disable :protection

  post '/pacman/new' do
    response['Access-Control-Allow-Origin'] = '*'

    puts params.inspect

    gs = GameState.new

    puts gs.getID

    content_type :json

    { id: gs.getID }.to_json
  end

  get '/pacman/:id/direction.json' do
    response['Access-Control-Allow-Origin'] = '*'

    @gs = GameState.find(params[:id])

    content_type :json
    {direction: @gs.direction}.to_json
  end

  get '/pacman/:id/direction' do
    @gs = GameState.find(params[:id])

    body direction

  end

  patch '/pacman/:id/direction' do
    puts params
    # Circumvent same-origin policy 
    response['Access-Control-Allow-Origin'] = '*'

    @gs = GameState.find(params[:id])
    puts @gs.inspect
    @gs.direction = params[:direction]
  end
end
