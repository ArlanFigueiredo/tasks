using System.ComponentModel;

namespace SystemTasks.Enums {
    public enum StatusTasks {

        [Description("Task to do")]
        Todo = 1,
        [Description("Task in Progress")]
        InProgress = 2,
        [Description("Task completed")]
        completed = 3,
    }
}
