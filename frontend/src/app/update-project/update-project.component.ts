import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Project } from '../project';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ProjectState } from '../projectstate';

@Component({
  selector: 'app-update-project',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './update-project.component.html',
  styleUrl: './update-project.component.css'
})
export class UpdateProjectComponent implements OnInit {
  id: string | null = null;
  project: Project | null = null;
  projectStates: ProjectState[] = [];
  updateProjectForm = new FormGroup({
    id: new FormControl(0),
    state: new FormControl(''),
    cost: new FormControl(0),
  });

  constructor(private route: ActivatedRoute) { }

  async ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.project = await this.getProject();
    this.projectStates = await this.getProjectStates();
    this.updateProjectForm.setValue({
      id: parseInt(this.id || '0'),
      state: this.project?.state.toString() || '',
      cost: this.project?.cost || 0,
    });
  }

  async getProject() {
    const response = await fetch(`http://localhost:4000/api/project/get/${this.id}`);
    if (response.ok) {
      const data = await response.json();
      return data.result;
    } else {
      return null;
    }
  }

  async getProjectStates() {
    const response = await fetch(`http://localhost:4000/api/project/states`);
    if (response.ok) {
      const data = await response.json();
      return data.result;
    } else {
      return null;
    }
  }

  async updateProject() {
    const project = this.updateProjectForm.value;

    const response = await fetch('http://localhost:4000/api/project/update', {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(project)
    });

    if (response.ok) {
      alert('Proyecto actualizado correctamente');
    } else {
      alert('Error al actualizar el proyecto');
    }
  }

}
