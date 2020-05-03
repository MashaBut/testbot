import { Injectable } from '@angular/core';
import { Message } from "../models/message";
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SendService {

  private message: Message;
  private readonly rootURL = 'https://localhost:5001/api';
  constructor(private http: HttpClient) {
    this.message = new Message();
  }

  public sendMessage(text: string) {
    this.message = new Message();
    this.message.text = text;
    return this.http.post(this.rootURL, this.message);
  }
}
