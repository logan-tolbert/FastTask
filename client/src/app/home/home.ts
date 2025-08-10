import { Component } from '@angular/core';
import { TasksService } from '../../services/tasks';
import { ITask } from '../abstractions/itask';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  tasks: ITask[] = [];

  constructor(private tasksService: TasksService) {}

  async ngOnInit() {
    try {
      this.tasks = await this.tasksService.getTasks();
    } catch (error) {
      console.error('Error fetching tasks:', error);
    }
  }
}
