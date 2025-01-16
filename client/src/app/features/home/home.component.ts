import { Component, OnInit } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  imports: [MatButton, MatIcon, FormsModule, RouterLink, CommonModule],
  standalone: true,
})
export class HomeComponent implements OnInit {
  isVisible: boolean = false;
  isContentReady: boolean = false;

  ngOnInit(): void {
    setTimeout(() => {
      this.isVisible = true;
    }, 500);

    setTimeout(() => {
      this.isContentReady = true;
    }, 100);
  }
}
