import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-rate-calculator',
  templateUrl: './payment-plan-calculator.component.html',
  styleUrls: ['./payment-plan-calculator.component.css']
})
export class PaymentPlanCalculatorComponent implements OnInit{
  loanTypes = ['Housing', 'Personal', 'Education'];
  loanForm: FormGroup;
  formSubmitted = false;

  public paymentPlan: PaymentDetails[];
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.loanForm = new FormGroup({
      'amount': new FormControl(null, [Validators.required, Validators.max(100000), Validators.min(1000)]),
      'term': new FormControl(null, [Validators.required, Validators.max(30), Validators.min(1)]),
      'loanType': new FormControl('Personal')
    });
  }

  onSubmit() {
    console.log(this.loanForm);
    let params = new URLSearchParams();
    params.append('amount', this.loanForm.get('amount').value);
    params.append('term', this.loanForm.get('term').value);
    params.append('loanType', this.loanForm.get('loanType').value);

    this.http.get<PaymentDetails[]>(this.baseUrl + 'paymentplancalculator', {
      params: {
        amount: this.loanForm.get('amount').value,
        term: this.loanForm.get('term').value,
        loanType: this.loanForm.get('loanType').value
      }
    }).subscribe(result => {
      this.paymentPlan = result;
    }, error => console.error(error));

    this.formSubmitted = true;
  }
}

interface PaymentDetails {
  date: string;
  total: number;
  interest: number;
  principal: number;
  balance: number;
}
