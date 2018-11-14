import { Game, GameResponse } from './home.component';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private LINK = "https://localhost:44332/api/Game?difficulty="

  constructor(public http : HttpClient) { }


  public CreateGame(game : Game, points: number){
    let temp = this.LINK + points; 
      return this.http.post<GameResponse>(temp, game);
  }
}
