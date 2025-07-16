namespace task14;

public class DefiniteIntegral
{
    public static double Solve(double a, double b, Func<double, double> function, double step, int threadsnumber)
    {
        double result = 0.0;
        double stepSize = (b - a) / threadsnumber;
        Object lockObj = new Object();

        using Barrier barrier = new Barrier(threadsnumber + 1);

        Thread[] threads = new Thread[threadsnumber];

        for (int i = 0; i < threadsnumber; i++) {

            int threadId = i;

            new Thread(() => 
            {
                double localStart = a + threadId * stepSize;
                double localEnd = (threadId == threadsnumber - 1) ? b : localStart + stepSize;

                double _res = 0.0;

                for (double j = localStart; j < localEnd; j+=step ) {
                    
                    double Next = Math.Min(j+step, localEnd);
                    _res += 0.5 * (function(j) + function(Next)) * (Next - j);
                }

                lock (lockObj) { result += _res; }

                barrier.SignalAndWait();
            }).Start();
        }

        barrier.SignalAndWait();

        return result;
    }
}
