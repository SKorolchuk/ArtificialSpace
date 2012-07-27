using System;

namespace ASpace
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MenuGameLayer game = new MenuGameLayer())
            {
              game.Run();
            }
        }
    }
#endif
}

