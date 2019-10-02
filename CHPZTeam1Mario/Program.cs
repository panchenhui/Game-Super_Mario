using System;

namespace CHPZTeam1Mario
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SuperMario())
                game.Run();
        }
    }
#endif
}
