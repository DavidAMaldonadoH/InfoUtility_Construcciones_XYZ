import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-register-engineer',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register-engineer.component.html',
  styleUrl: './register-engineer.component.css'
})
export class RegisterEngineerComponent {
  registerEngineerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
  });

  constructor(private formBuilder: FormBuilder) {
    this.registerEngineerForm = this.formBuilder.group({
      firstName: ['', Validators.required, Validators.minLength(2)],
      lastName: ['', Validators.required, Validators.minLength(2)]
    });
  }

  async submitEngineer() {
    if (this.registerEngineerForm.invalid) {
      alert('Por favor, llena todos los campos');
      return;
    }

    const response = await fetch('http://localhost:4000/api/engineer/create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        firstName: this.registerEngineerForm.value.firstName,
        lastName: this.registerEngineerForm.value.lastName
      })
    });

    if (response.ok) {
      alert('Ingeniero creado correctamente');
    } else {
      alert('Error al crear el ingeniero');
    }
  }

}
