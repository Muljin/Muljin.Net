using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muljin.Async
{
    /// <summary>
    /// Groups multiple tasks together
    /// </summary>
    public class TaskGroup : IEnumerable<Task>
    {

        private List<Task> TasksList { get; set; } = new List<Task>();

        public void Add(Task task)
        {
            TasksList.Add(task);
        }

        public void Add(Func<Task> func)
        {
            TasksList.Add(func.Invoke());
        }

        public async Task WaitAll()
        {
            await Task.WhenAll(TasksList);
            TasksList.Clear();
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return TasksList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return TasksList.GetEnumerator();
        }
    }
}
