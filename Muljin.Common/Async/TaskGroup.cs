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

        private List<Task> _tasksList { get; set; }

        public void Add(Task task)
        {
            _tasksList.Add(task);
        }

        public void Add(Func<Task> func)
        {
            _tasksList.Add(func.Invoke());
        }

        public async Task WaitAll()
        {
            await Task.WhenAll(_tasksList);
            _tasksList.Clear();
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return _tasksList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _tasksList.GetEnumerator();
        }
    }
}
