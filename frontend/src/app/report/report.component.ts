import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { projectsByState } from '../projectsByState';
import { projectsByType } from '../projectsByType';

@Component({
  selector: 'app-report',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './report.component.html',
  styleUrl: './report.component.css'
})
export class ReportComponent implements OnInit {
  constructor() { }

  projectsByStates: projectsByState[] = []
  projectsByTypes: projectsByType[] = []

  async ngOnInit() {
    this.projectsByStates = await this.getProjectsByStates()
    this.projectsByTypes = await this.getProjectsByTypes()
  }

  async getProjectsByStates() {
    const response = await fetch('http://localhost:4000/api/project/byStates')
    if (response.ok) {
      const data = await response.json()
      return data.result
    } else {
      return []
    }
  }

  async getProjectsByTypes() {
    const response = await fetch('http://localhost:4000/api/project/byTypes')
    if (response.ok) {
      const data = await response.json()
      return data.result
    } else {
      return []
    }
  }

  async archiveProjects() {
    const response = await fetch('http://localhost:4000/api/project/archive', {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      }
    })
    const data = await response.json()
    if (response.ok) {
      alert(data.message)
    } else {
      alert(data.message)
    }
  }
}
