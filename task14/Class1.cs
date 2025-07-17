using System.Threading;
namespace task14;

public class DefiniteIntegral
{
    public static double Solve(double a, double b, Func<double, double> function, double step, int threadsnumber)
        {
            double length_for_thread = (b - a) / threadsnumber;
            double[] partial_sums = new double[threadsnumber];

            Parallel.For(0, threadsnumber, i =>
            {
                double x1 = a + i * length_for_thread;
                double x2 = (i == threadsnumber - 1) ? b : x1 + length_for_thread;

                double local_sum = 0;
                for (double x = x1; x < x2; x += step)
                {
                    double x_next = Math.Min(x + step, x2);
                    local_sum += 0.5 * (function(x) + function(x_next)) * (x_next - x);
                }
                partial_sums[i] = local_sum;
            });

            return partial_sums.Sum();
        }



    public static double SolveSingle(double a, double b, Func<double, double> function, double step)
    {
        double result = 0.0;
        for (double x = a; x < b; x += step)
        {
            double next = Math.Min(x + step, b);
            result += 0.5 * (function(x) + function(next)) * (next - x);
        }
        return result;
    }
}
