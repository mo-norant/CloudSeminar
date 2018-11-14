import { GameService } from './game.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
 

  lat: number = 51.22;
  lng: number = 4.42;
  points : number = 10;
  playerinput : string;
  players : string[] = []; 
  game : Game;
  data : GameResponse;
  constructor(private gameservice : GameService) {}

  ngOnInit() {
   
  }

  addplayer(){
    this.players.push(this.playerinput);
    this.playerinput = "";
  }

  startGame(){
    this.game = new Game;
    let location = new StartLocation;
    location.lat = this.lat;
    location.lng = this.lng;
    this.game.playersIDs = this.players;
    this.game.startLocation = location;
    this.gameservice.CreateGame(this.game, this.points).subscribe(res => {
        this.data = res;
      
    })
  }

  clear(){
    this.players = [];
    this.game = undefined;
    this.points = 10; 
    this.data = undefined;
  }
}

export class StartLocation {
  locationID: number;
  name: string;
  lat: number;
  lng: number;
}

export class Game {
  startLocation: StartLocation;
  playersIDs: string[] = [];
}

export class PointofInterest {
  isActive: boolean;
  scorePoints: number;
  locationID: number;
  name: string;
  lat: number;
  lng: number;
}

export class Area {
  areaID: number;
  pointofInterests: PointofInterest[];
  name: string;
}

export class Player {
  gamePlayerID: string;
  score: number;
}

export class GameResponse {
  gameID: number;
  area: Area;
  createdAt: Date;
  players: Player[];
}
