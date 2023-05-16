using System;

namespace WonkmyGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new CowBullishGame())
                game.Run();
        }
    }
}
