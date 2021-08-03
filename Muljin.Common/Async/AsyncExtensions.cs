using System.Threading.Tasks;

namespace Muljin
{
    public static class AsyncExtensions
    {
        public static async Task<(T1, T2)> WhenAllReturnAsync<T1, T2>(Task<T1> t1, Task<T2> t2)
        {
            await Task.WhenAll(t1, t2);
            return (t1.Result, t2.Result);
        }

        public static async Task<T1> WhenAllReturnAsync<T1>(Task<T1> t1, Task t2)
        {
            await Task.WhenAll(t1, t2);
            return t1.Result;
        }

        public static async Task<(T1, T2, T3)> WhenAllReturnAsync<T1, T2, T3>(Task<T1> t1, Task<T2> t2, Task<T3> t3)
        {
            await Task.WhenAll(t1, t2, t3);
            return (t1.Result, t2.Result, t3.Result);
        }

        public static async Task<(T1, T2, T3, T4)> WhenAllReturnAsync<T1, T2, T3, T4>(Task<T1> t1, Task<T2> t2, Task<T3> t3, 
            Task<T4> t4)
        {
            await Task.WhenAll(t1, t2, t3, t4);
            return (t1.Result, t2.Result, t3.Result, t4.Result);
        }

        public static async Task<(T1, T2, T3, T4, T5)> WhenAllReturnAsync<T1, T2, T3, T4, T5>(Task<T1> t1, Task<T2> t2, Task<T3> t3,
            Task<T4> t4, Task<T5> t5)
        {
            await Task.WhenAll(t1, t2, t3, t4, t5);
            return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result);
        }

        public static async Task<(T1, T2, T3, T4, T5, T6)> WhenAllReturnAsync<T1, T2, T3, T4, T5, T6>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3,
            Task<T4> t4, Task<T5> t5, Task<T6> t6)
        {
            await Task.WhenAll(t1, t2, t3, t4, t5, t6);
            return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result);
        }
    }
}
