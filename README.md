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
First, we can remove any tasks that contain within their timebounds 2 or more other tasks.

Once we've done that, we can greedily grab tasks that don't overlap and call it good.