using FluentAssertions;

namespace cassidoo_11_24_2025
{
    [TestClass]
    public sealed class MealTests
    {
        [TestMethod]
        public void TestFromEmail()
        {
            MealPlan plan = MealScheduler.MaxMealPrepTasks([
                new MealTask("Make Gravy", 10, 11),
                new MealTask("Mash Potatoes", 11, 12),
                new MealTask("Bake Rolls", 11, 13),
                new MealTask("Prep Salad", 12, 13)
            ]);
            plan.Count.Should().Be(3);
            plan.ChosenTasks.Count.Should().Be(3);
        }

        [TestMethod]
        public void TestBasic()
        {
            MealPlan plan = MealScheduler.MaxMealPrepTasks(new MealTask[] { 
                new MealTask("Wake Up")
            });
            plan.Count.Should().Be(1);
            plan.ChosenTasks.Should().BeEquivalentTo(["Wake Up"]);
        }
    }
}
