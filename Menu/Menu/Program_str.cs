using System;

namespace Menu
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MenuScreen game = new MenuScreen())
            {
                game.Run();
            }
        }
    }
#endif
}

