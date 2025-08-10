import { Injectable } from '@angular/core';
import { ITaskList } from '../app/abstractions/itaskList';
import { ITask } from '../app/abstractions/itask';

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  constructor() {}

  async getTasks(): Promise<ITask[]> {
    const response = await fetch('http://localhost:5275/tasks');

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const data: ITaskList = await response.json();

    return data.taskList.map((task) => ({
      ...task,
      createdDate: new Date(task.createdDate),
      updatedDate: new Date(task.updatedDate),
    }));
  }
}
