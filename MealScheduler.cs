using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cassidoo_11_24_2025
{
	public class MealTask(string name, int start, int end)
	{
		public string Name = name;
		public int StartTime = start;
		public int Endtime = end;
	}
	public class MealPlan(int count, string[] chosen)
	{
		public int Count = count;
		public string[] ChosenTasks = chosen;
	}

	public class MealScheduler
	{
		public static MealPlan MaxMealPrepTasks(MealTask[] meals)
		{
			return new MealPlan(0, []);
		}
	}
}
