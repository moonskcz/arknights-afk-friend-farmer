using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace arknight_mission_clicker
{
    class logic
    {

        private ImageProcessor IP = new ImageProcessor();
        private WindowManager WM = new WindowManager();
        private MouseController MC;

        private int planCount;
        private bool _annoyingMode;
        private int friendTry = 1;

        public void beginFarming (bool annoyingMode = false)
        {

            _annoyingMode = annoyingMode;

            if (annoyingMode)
            {
                MC = new AnnoyingMouseController();
            } else
            {
                MC = new RegularMouseController();
            }

            if (IsMainMenu())
            {
                NavigateToCombatFromMainMenu();
            } else
            {
                NavigateToCombatFromTopMenu();
            }

            NavigateToFirstChapter();
            NavigateToFirstMission();
            CheckPlanCount();
            RunMissionTillNoPlans();

        }

        public bool IsMainMenu ()
        {
            if (_annoyingMode)
            {
                WM.setWindowPosTop(100, 100);
            } else
            {
                WM.setWindowPos(100, 100);
            }

            Bitmap combatSnippet = IP.GetScreenshot(677, 120, 110, 42);
            string text = IP.GetTextFromBitmap(combatSnippet);
            if (text.Equals("Combat"))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void NavigateToCombatFromMainMenu ()
        {
            MC.SetMouse(820, 250);
            MC.Click();
            Thread.Sleep(1000);
        }

        public void NavigateToCombatFromTopMenu ()
        {
            MC.SetMouse(260, 155);
            MC.Click();
            Thread.Sleep(600);
            MC.SetMouse(500, 275);
            MC.Click();
            Thread.Sleep(1000);
        }

        public void NavigateToFirstChapter ()
        {
            MC.SetMouse(150, 620);
            MC.Click();
            Thread.Sleep(250);
            //slide to the left to see first chapter
            for (int i = 0; i < 4; i++)
            {
                MC.SetMouse(400, 400);
                MC.Press();
                Thread.Sleep(100);
                for (int x = 0; x < 20; x++)
                {
                    MC.SetMouse(400 + x * 20, 400);
                    Thread.Sleep(6);
                }
                MC.Release();
                Thread.Sleep(250);
            }

            //Thread.Sleep(1000);
            MC.SetMouse(400, 400);
            MC.Click();
            Thread.Sleep(1250);
        }

        public void NavigateToFirstMission ()
        {

            MC.SetMouse(580, 388);
            MC.Click();
            Thread.Sleep(600);

        }

        public void CheckPlanCount()
        {

            Bitmap snippet = IP.GetScreenshot(679, 47, 40, 32);
            snippet = IP.InvertImage(snippet);
            IP.DEBUGsave(snippet);
            string text = IP.GetNumbersFromBitmap(snippet);

            //the ocr library I use sometimes goes full acoustic, and wont recognize shit properly, and yes it throws this random shit even when restricted to only read numbers. Thats also the reason I invert the picture, to make it black on white, not white on black
            switch(text)
            {
                case "ll?":
                    planCount = 12;
                    break;
                default:
                    planCount = int.Parse(text);
                    break;
            }

        }

        public void RunMissionTillNoPlans ()
        {
            while (planCount > 0)
            {

                //click on add support
                MC.SetMouse(800, 620);
                MC.Click();
                Thread.Sleep(1200);

                MC.SetMouse(930, 280);
                MC.Click();
                Thread.Sleep(2000);
                

                //slide to the right to see recomended supports
                for (int i = 0; i < 4; i++)
                {
                    MC.SetMouse(900, 400);
                    MC.Press();
                    Thread.Sleep(100);
                    for (int x = 0; x < 20; x++)
                    {
                        MC.SetMouse(900 - x * 20, 400);
                        Thread.Sleep(6);
                    }
                    MC.Release();
                    Thread.Sleep(250);
                }


                Bitmap snippet = IP.GetScreenshot(0, 0, 960, 572);
                IP.DEBUGsave(snippet);
                //what an ugly monstrosity

                CaseTree:
                switch(friendTry)
                {
                    case 1:
                        if (snippet.GetPixel(500, 150).R == 205)
                        {
                            MC.SetMouse(600, 250);
                            MC.Click();
                            friendTry++;
                        }
                        else goto case 2;
                        break;
                    case 2:
                        if (snippet.GetPixel(500, 280).R == 205)
                        {
                            MC.SetMouse(600, 380);
                            MC.Click();
                            friendTry++;
                        }
                        else goto case 3;
                        break;
                    case 3:
                        if (snippet.GetPixel(500, 420).R == 205)
                        {
                            MC.SetMouse(600, 520);
                            MC.Click();
                            friendTry++;
                        }
                        else goto case 4;
                        break;
                    case 4:
                        if (snippet.GetPixel(920, 150).R == 205)
                        {
                            MC.SetMouse(1020, 250);
                            MC.Click();
                            friendTry++;
                        }
                        else goto case 5;
                        break;
                    case 5:
                        if (snippet.GetPixel(920, 280).R == 205)
                        {
                            MC.SetMouse(1020, 380);
                            MC.Click();
                            friendTry++;
                        }
                        else goto case 6;
                        break;
                    case 6:
                        if (snippet.GetPixel(920, 420).R == 205)
                        {
                            MC.SetMouse(1020, 520);
                            MC.Click();
                            friendTry++;
                        }
                        else goto default;
                        break;
                    default:
                        MC.SetMouse(980, 150);
                        MC.Click();
                        Thread.Sleep(2000);
                        friendTry = 1;
                        goto CaseTree;
                }

                //launch mission
                Thread.Sleep(600);
                MC.SetMouse(930, 500);
                MC.Click();

                //sleep through loading
                Thread.Sleep(14000);
                //check if 2x speed is enabled
                snippet = IP.GetScreenshot(798, 50, 46, 26);
                IP.DEBUGsave(snippet);
                string speed = IP.GetTextFromBitmap(snippet);
                if (speed.Equals("1X"))
                {
                    MC.SetMouse(898, 150);
                    MC.Click();
                }

                //keep checking if mission is finished
                //a mission usualy takes about 50 sec
                Thread.Sleep(38000);

                CaseCheckFriend:

                Thread.Sleep(1000);
                snippet = IP.GetScreenshot(907, 250, 20, 20);
                if (snippet.GetPixel(10, 10).R != 66)
                    goto CaseCheckFriend;


                //accept friend
                MC.SetMouse(1015, 350);
                MC.Click();
                Thread.Sleep(4000);
                //go back to mission screen
                MC.Click();
                Thread.Sleep(7000);

                //select the mission again
                MC.SetMouse(580, 388);
                MC.Click();
                Thread.Sleep(600);

                planCount--;

            }
        }

    }
}
