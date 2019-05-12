import { Component } from '@angular/core';
import { GetAvatarService } from './Services/getAvatar.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(avatarService: GetAvatarService) {
    this.avatarString= avatarService.getAvatar();
  }

  title = 'ClientApp';
  avatarString = '';
  navbarPic='api/index/GetNavbarPic';
}
