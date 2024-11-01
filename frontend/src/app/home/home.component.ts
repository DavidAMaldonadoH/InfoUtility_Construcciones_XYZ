import { Component, OnInit } from '@angular/core';
import { Project } from '../project';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  constructor(private router: Router) { }
  title = 'homes'
  projects: Project[] = []

  goToProject(id: number) {
    this.router.navigate(['/proyecto', id])
  }

  async ngOnInit() {
    this.projects = await this.getProjects()
    console.log(this.projects)
  }

  async getProjects() {
    const response = await fetch('http://localhost:4000/api/project/all')
    if (response.ok) {
      const data = await response.json()
      return data.result
    } else {
      return []
    }
  }
}
