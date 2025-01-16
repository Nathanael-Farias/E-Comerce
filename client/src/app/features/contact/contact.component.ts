import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact',
  imports: [CommonModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent implements OnInit {
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
