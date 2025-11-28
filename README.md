# cassidoo-11-24-2025
Solution for the interview question in the cassidoo 11-24-2025 newsletter.

## Problem statement

Given an array of meal prep tasks for Thanksgiving, where each task is represented as `[taskName, startTime, endTime]`, return the maximum number of non-overlapping tasks you can complete, along with the names of the chosen tasks in the order they were selected.

### Example
```
const tasks = [
  ["Make Gravy", 10, 11],
  ["Mash Potatoes", 11, 12],
  ["Bake Rolls", 11, 13],
  ["Prep Salad", 12, 13]
];

maxMealPrepTasks(tasks)
> {
    count: 3,
    chosen: ["Make Gravy", "Mash Potatoes", "Prep Salad"]
  }
```

## Solution
First step is to sort by start time ascending, then end time ascending.
Then, we can remove any tasks that contain within their timebounds another task. Why select a task that goes from 4-8, for instance, if there's a task that goes 5-7? Or 5-6?
Once we've done that, given our sort, we can greedily grab tasks that don't overlap and call it good.