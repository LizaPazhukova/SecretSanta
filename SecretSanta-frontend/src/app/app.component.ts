import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from './user';
import { UserService } from './user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SecretSanta-frontend';
  public users: User[];
  show = false;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getUsers();
  }

  submit(form: NgForm) {
    var user: User = new User();
    user.firstName = form.value.firstName;
    user.lastName = form.value.lastName;
    this.userService.addUser(user).subscribe(r => this.getUsers());
    alert(`User with first name: ${user.firstName} successfully added`);
    form.reset();
  }
  getUsers() {
    return this.userService.getUsers().subscribe(r => this.users = r);
  }
  showUsers() {
    this.show = !this.show;
  }
}
