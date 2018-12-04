import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { Title as TitleService } from '@angular/platform-browser';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Input() title: string;
  @Input() bigTitle: boolean;
  @Input() version: string;


  @Input() headerTemplate: TemplateRef<any>;

  constructor(private titleService: TitleService) {

  }

  ngOnInit() {
    this.title = this.title;
    this.version = `v ${this.version}`;
    this.titleService.setTitle(this.title);
  }

}
