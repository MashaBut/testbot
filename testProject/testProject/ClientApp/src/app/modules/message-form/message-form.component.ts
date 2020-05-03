import { Component } from '@angular/core';
import { SendService } from '../../services/send.service';
import { Message } from 'src/app/models/message';

@Component({
  selector: 'app-message-form',
  templateUrl: './message-form.component.html',
  styleUrls: ['./message-form.component.css']
})
export class MessageFormComponent {
  public text: string = null;
  constructor(public sendService: SendService) { }

  public sendMessage(): void {
    if (this.text === null) {
      alert("You need to write msg!");
    }
    else {
      this.sendService.sendMessage(this.text).subscribe(
        (data: Message) => {
          this.text = data.text
        },
        error => console.log(error)
      )
      this.text = null;
    }
  }
}
