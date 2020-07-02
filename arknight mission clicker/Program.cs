using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arknight_mission_clicker
{
    class Program
    {

        public static void beginIGuess ()
        {

            logic l = new logic();

            Console.WriteLine("");
            Console.WriteLine("launch arknights in your noxPlayer and go to the main menu");
            Console.WriteLine("");
            Console.WriteLine("move your mouse to your main screen, itll start clicking randomly and crash otherwise");
            Console.WriteLine("");
            Console.WriteLine("warning: -this will resize your noxPlayer window to 960x572");
            Console.WriteLine(@"         -this requires the noxPlayer to allways be on top as well as control of your mouse");
            Console.WriteLine(@"          so basically go take a shower or something, idling 0-1 30 times can take between 30 to 45 minutes");
            Console.WriteLine("");
            Console.WriteLine("if youre worried about security, you can check the code on github where you downloaded this");
            Console.WriteLine("");
            Console.WriteLine("if youre worried about an account ban, then theres probably nothing to worry about");
            Console.WriteLine("this app simulates real user input and doesnt modify any game data");
            Console.WriteLine("its really just a complex timer that moves and clicks your mouse");
            Console.WriteLine("");

        Question:
            Console.WriteLine("");
            Console.WriteLine("press:");
            Console.WriteLine("b - begin farming");
            Console.WriteLine("u - unset allways on top");
            Console.WriteLine("i - more info");
            Console.WriteLine("q - quit");

            char c = Console.ReadKey().KeyChar;

            switch (c)
            {
                case 'b':
                    l.beginFarming(true);
                    break;
                case 'q':
                    Environment.Exit(0);
                    break;
                case 'u':
                    new WindowManager().UnsetTopMost(100, 100);
                    Console.Clear();
                    Console.WriteLine("NoxPlayer will no longer remain on top");
                    goto Question;
                case 'i':
                    WriteMoreInfo();
                    goto Question;
                default:
                    Console.Clear();
                    goto Question;
            }

        }

        static void WriteMoreInfo()
        {
            Console.WriteLine("So I saw a post on reddit that said you can farm friends with plans on 0-1");
            Console.WriteLine("But farming it by hand got really boring after a second");
            Console.WriteLine("So I thought \"Hey, that looks pretty easy to automate\"");
            Console.WriteLine("And thus this fragile piece of spaghetti code was made");
            Console.WriteLine("");
            Console.WriteLine("How it works?");
            Console.WriteLine("a mix of color recognition and character recognition(OCR)");
            Console.WriteLine("It will move your mouse and click on buttons that launch planning 0-1 untill you run out of plans");
            Console.WriteLine("no need to worry about your sanity");
            Console.WriteLine("");
            Console.WriteLine("What is NoxPlayer and can I eat it?");
            Console.WriteLine("No you cant");
            Console.WriteLine("Its an emulator that allows you to play mobile games on desktop");
            Console.WriteLine("you can dowload it here");
            Console.WriteLine("https://www.bignox.com/appcenter/game_management/play-arknights-on-pc-with-noxplayer/");
            Console.WriteLine("");
            Console.WriteLine("Can I use a different emulator?");
            Console.WriteLine("Yes, but with difficulty. This app wont be able to set other emulators to allways stay on top and will probably crash");
            Console.WriteLine("Change the size of the emulator window to 960x572 and position it so that the actual game (emulator content) is at 102x 132y on your screen");
            Console.WriteLine("There are some tolerances, but they are couple pixels at most");
            Console.WriteLine("");
            Console.WriteLine("How do I position a different emulator to 102x 132y");
            Console.WriteLine("Yes, good luck");
            Console.WriteLine("");
            Console.WriteLine("The app crashed or I closed it early and now its stuck as allways on top");
            Console.WriteLine("launch the app again and press \"U\" ");
            Console.WriteLine("");

        }

        static void Main(string[] args)
        {
            beginIGuess();

            new WindowManager().UnsetTopMost(100, 100);

            AppDomain.CurrentDomain.ProcessExit += AppDomain_ProcessExit;
        }

        public Program ()
        {

        }


        private static void AppDomain_ProcessExit(object sender, EventArgs e)
        {
            new WindowManager().UnsetTopMost(100, 100);
        }
    }
}
