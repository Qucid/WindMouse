using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WindMouse
{
    /// <summary>
    /// MouseAPI class
    /// </summary>
    public static class MouseAPI
    {
        /// <summary>
        /// An wrap WinAPI GetCursorPos, returns Point
        /// </summary>
        /// <returns></returns>
        public static Point GetMouseLocation()
        {
            Point result = new Point(0, 0);
            GetCursorPos(ref result);
            return result;
        }

        /// <summary>
        /// Realistic mouse movement using the WindMouse algorithm, provides many calls WinAPI function SetCursorPos
        /// </summary>
        /// <param name="DestinationLocation">Destination coords</param>
        /// <param name="GravitationalForce">Magnitude of the gravitational force</param>
        /// <param name="WindForce">Magnitude of the wind force fluctuations</param>
        /// <param name="MaximumStepSize">Maximum step size (velocity clip threshold)</param>
        /// <param name="Distance">Distance where wind behavior changes from random to damped</param>
        /// <param name="Delay">Delay to set pix (ms), random mode if -1 </param>
        public static void MoveMouseWind(Point DestinationLocation, double GravitationalForce = 9, double WindForce = 3,
            double MaximumStepSize = 30, double Distance = 15, int Delay = 2)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Point CurrentLocation = GetMouseLocation();
            double StartX = CurrentLocation.X;
            double StartY = CurrentLocation.Y;
            double v_x = 0, v_y = 0, W_x = 0, W_y = 0;
            double dist = 2;
            
            while((dist = Hypot(DestinationLocation.X - StartX, DestinationLocation.Y - StartY)) >= 1)
            {
                CurrentLocation = GetMouseLocation();
                double W_mag = Math.Min(WindForce, dist);
                if(dist >= Distance)
                {
                    W_x = W_x / sqrt3 + (2 * RandomDouble()-1) * W_mag / sqrt5;
                    W_y = W_y / sqrt3 + (2 * RandomDouble()-1) * W_mag / sqrt5;
                }
                else
                {
                    W_x /= sqrt3;
                    W_y /= sqrt3;
                    if (MaximumStepSize < 3)
                        MaximumStepSize = RandomDouble() * 3 + 3;
                    else
                        MaximumStepSize /= sqrt5;
                }
                v_x += W_x + GravitationalForce * (DestinationLocation.X - StartX) / dist;
                v_y += W_y + GravitationalForce * (DestinationLocation.Y - StartY) / dist;
                double v_mag = Hypot(v_x, v_y);
                if(v_mag > MaximumStepSize)
                {
                    double v_clip = MaximumStepSize / 2 + RandomDouble() * MaximumStepSize / 2;
                    v_x = (v_x / v_mag) * v_clip;
                    v_y = (v_y / v_mag) * v_clip;
                }
                StartX += v_x;
                StartY += v_y;

                Point MoveLocation = new((int)StartX, (int)StartY);
                
                if(CurrentLocation.X != MoveLocation.X || CurrentLocation.Y != MoveLocation.Y)
                {
                    if(Delay != - 1)
                        Thread.Sleep(Delay);
                    else
                    {
                        int x = rd.Next(1, 500);
                        if (x > 250)
                            Thread.Sleep(2);
                        else
                            Thread.Sleep(1);
                    }
                    SetCursorPos(MoveLocation.X, MoveLocation.Y);
                }
                if (CurrentLocation.X == DestinationLocation.X && CurrentLocation.Y == DestinationLocation.Y)
                    break;
            }

            sw.Stop();
            Debug.WriteLine($"Time to move mouse: {sw.ToString()}");
            
        }
        static Random rd = new Random();
        static double RandomDouble()
        {
            Random rd = new Random();
            int precision = 1000;
            return (rd.Next(0, precision + 1)) / ((double)precision);
        }

        static double Hypot(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        static double sqrt3 = Math.Sqrt(3);
        static double sqrt5 = Math.Sqrt(5);

        /// <summary>
        /// Realistic mouse movement using the WindMouse algorithm, provides many calls WinAPI function SetCursorPos
        /// </summary>
        /// <param name="DestinationLocation">Destination coords</param>
        /// <param name="GravitationalForce">Magnitude of the gravitational force</param>
        /// <param name="WindForce">Magnitude of the wind force fluctuations</param>
        /// <param name="MaximumStepSize">Maximum step size (velocity clip threshold)</param>
        /// <param name="Distance">Distance where wind behavior changes from random to damped</param>
        /// <param name="Delay">Delay to set pix (ms), random mode if -1 </param>
        public static Task MoveMouseWindAsync(Point DestinationLocation, double GravitationalForce = 9, double WindForce = 3,
            double MaximumStepSize = 30, double Distance = 15, int Delay = 2)
        {
            return Task.Run(() =>
            {
                MoveMouseWind(DestinationLocation, GravitationalForce, WindForce, MaximumStepSize, Distance, Delay);
            });
        }

            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, UIntPtr dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        static extern void GetCursorPos(ref System.Drawing.Point p);
        [Flags]
        enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            MouseWheel = 0x0800

        }
        const int SCROLLDOWN = -120;
        const int SCROLLUP = 120;
        
        /// <summary>
        /// WinAPI function to set cursor postion
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        /// <summary>
        /// One time scroll up. If you need that method, you may need set delay param.
        /// </summary>
        /// <param name="delay">Delay after wheel (Thread.Sleep) </param>
        public static void MouseWheelUp(int delay = 0)
        {
            mouse_event((int)MouseEventFlags.MouseWheel, 0, 0, SCROLLUP, 0);
            Thread.Sleep(delay);
        }
        /// <summary>
        /// One time scroll down. If you need that method, you may need set delay param.
        /// </summary>
        /// <param name="delay">Delay after wheel (Thread.Sleep) </param>
        public static void MouseWheelDown(int delay = 50)
        {
            mouse_event((int)MouseEventFlags.MouseWheel, 0, 0, SCROLLDOWN, 0);
            Thread.Sleep(delay);
        }
        /// <summary>
        /// Send instantly right click (down and up)
        /// </summary>
        /// <param name="p"></param>
        public static void SendMouseRightClick(System.Drawing.Point p)
        {
            mouse_event((int)MouseEventFlags.RIGHTDOWN | (int)MouseEventFlags.RIGHTUP, p.X, p.Y, 0, 0);
        }
        /// <summary>
        /// Send left mouse double click, delay is time between clicks
        /// </summary>
        /// <param name="p"></param>
        /// <param name="delay"></param>
        public static void SendMouseDoubleClick(System.Drawing.Point p, int delay = 150)
        {
            mouse_event((int)MouseEventFlags.LEFTDOWN | (int)MouseEventFlags.LEFTUP, p.X, p.Y, 0, 0);
            Thread.Sleep(delay);
            mouse_event((int)MouseEventFlags.LEFTDOWN | (int)MouseEventFlags.LEFTUP, p.X, p.Y, 0, 0);
        }

        static void SendMouseDown(System.Drawing.Point p)
        {
            mouse_event((int)MouseEventFlags.LEFTDOWN, p.X, p.Y, 0, 0);
        }
        static void SendMouseUp(System.Drawing.Point p)
        {
            mouse_event((int)MouseEventFlags.LEFTUP, p.X, p.Y, 0, 0);
        }
        /// <summary>
        /// Move mouse from the current coords (WinAPI)
        /// </summary>
        /// <param name="p"></param>
        static void MoveMouseWinAPI(System.Drawing.Point p)
        {
            mouse_event((int)MouseEventFlags.MOVE, p.X, p.Y, 0, 0);
        }
        /// <summary>
        /// Send left mouse click
        /// </summary>
        /// <param name="p"></param>
        /// <param name="delay">Time betweent down and up button</param>
        public static void sendMouseLeftClick(System.Drawing.Point p, int delay = 25)
        {
            SendMouseDown(new(50, 50));
            Thread.Sleep(delay);
            SendMouseUp(new(50, 50));
        }
    }
}
