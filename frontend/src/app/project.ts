import { Engineer } from "./engineer";
import { ProjectState } from "./projectstate";
import { ProjectType } from "./projecttype";

export interface Project {
    id: number,
    name: string,
    location: string,
    type: number,
    cost: number,
    engineerId: number,
    state: number,
    projectState?: ProjectState,
    projectType?: ProjectType,
    engineer?: Engineer,
}
