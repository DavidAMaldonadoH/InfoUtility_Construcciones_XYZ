import { Routes } from '@angular/router';
import { CreateProjectComponent } from './create-project/create-project.component';
import { RegisterEngineerComponent } from './register-engineer/register-engineer.component';
import { HomeComponent } from './home/home.component';
import { UpdateProjectComponent } from './update-project/update-project.component';
import { ReportComponent } from './report/report.component';

export const routes: Routes = [
    {
        path: '', component: HomeComponent
    },
    {
        path: 'crear-proyecto', component: CreateProjectComponent
    },
    {
        path: 'registrar-ingeniero', component: RegisterEngineerComponent
    },
    {
        path: 'proyecto/:id', component: UpdateProjectComponent
    },
    {
        path: 'cuadre', component: ReportComponent
    }
];
