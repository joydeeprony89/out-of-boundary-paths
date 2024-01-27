namespace out_of_boundary_paths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ans = solution.FindPaths(1, 3, 3, 0, 1);
            Console.WriteLine(ans);
        }
    }

    public class Solution
    {
        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            int mod = 1000000007;

            var cache = new Dictionary<(int, int, int), int>();
            int Dfs(int i, int j, int move)
            {
                // base case
                var key = (i, j, move);
                if (cache.ContainsKey(key)) return cache[key];
                if (move == 0) 
                {
                    if (i < 0 || j < 0 || i >= m || j >= n) return 1; else return 0;
                } 
                if (i < 0 || j < 0 || i >= m || j >= n)
                {
                    return 1;
                }

                int up = i - 1;
                int left = j - 1;
                int down = i + 1;
                int right = j + 1;

                move -= 1;
                int ans = 0;
                ans = (ans + Dfs(up, j, move)) % mod; 
                ans = (ans + Dfs(i, left, move)) % mod; 
                ans = (ans + Dfs(down, j, move)) % mod; 
                ans = (ans + Dfs(i, right, move)) % mod;
                cache[key] = ans;
                return ans;
            }
            var ans = Dfs(startRow, startColumn, maxMove);
            return ans;
        }
    }
}
