import { Component, OnInit } from '@angular/core';
import { CurrencyService } from '../services/currency.service';
import { Currency } from '../models/currency.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private currencyService: CurrencyService) {
  }

  currency: Currency;

  tabChangeEvent() {
    console.log('change is active');
  }

  ngOnInit() {
    this.currencyService.get('').subscribe(x => this.currency = x);
  }
}
