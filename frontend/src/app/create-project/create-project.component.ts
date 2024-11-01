import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Project } from '../project';
import { Engineer } from '../engineer';
import { ProjectType } from '../projecttype';

@Component({
  selector: 'app-create-project',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './create-project.component.html',
  styleUrl: './create-project.component.css'
})
export class CreateProjectComponent implements OnInit {
  engineers: Engineer[] = [];
  projectTypes: ProjectType[] = []

  createProjectForm = new FormGroup({
    name: new FormControl(''),
    location: new FormControl(''),
    type: new FormControl(''),
    cost: new FormControl(0),
    engineerId: new FormControl('')
  });

  async ngOnInit() {
    this.engineers = await this.getEngineers();
    this.projectTypes = await this.getProjectTypes();
  }

  async submitProject() {
    if (this.createProjectForm.invalid) {
      return;
    }
    const body = {
      name: this.createProjectForm.value.name,
      location: this.createProjectForm.value.location,
      type: this.createProjectForm.value.type,
      cost: this.createProjectForm.value.cost,
      engineerId: parseInt(this.createProjectForm.value.engineerId || '0'),
      state: 1
    }
    const response = await fetch('http://localhost:4000/api/project/create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(body)
    });

    if (response.ok) {
      alert('Proyecto creado correctamente');
    } else {
      alert('Error al crear el proyecto');
    }
  }

  async getEngineers() {
    const response = await fetch('http://localhost:4000/api/engineer/all');
    if (response.ok) {
      const engineers = await response.json();
      return engineers.result;
    } else {
      return [];
    }
  }

  async getProjectTypes() {
    const response = await fetch('http://localhost:4000/api/project/types');
    if (response.ok) {
      const projectTypes = await response.json();
      return projectTypes.result;
    } else {
      return [];
    }
  }
}
