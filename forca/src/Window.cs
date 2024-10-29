namespace Forca
{
    using System;
    using System.Text;
    using static System.Console;

    class Window
    {
        public static void WriteCenter(string str, int yAdd)
        {
            SetCursorPosition(WindowWidth/2-str.Length/2,WindowHeight/2+yAdd);
            Write(str);
        }

        public static void ClearCenter(int windowWidth, int windowHeight)
        {   
            for (int le = 1; le<windowHeight; le++) 
            {
                SetCursorPosition(WindowWidth/2-windowWidth/2+1,WindowHeight/2-windowHeight/2+le);
                for (int x = 0; x < windowWidth-2; x++) 
                {
                    Write(" ");
                }
            }
        }

        public static void ClearPos(int x, int y, int length) 
        {
            SetCursorPosition(x,y);
            Write(new string(' ',length));
        }

        public static void DrawBG(ConsoleColor color = ConsoleColor.Blue) 
        {
            BackgroundColor = color;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < WindowWidth; i++)
            {
                for (int j = 0; j < WindowHeight; j++)
                {
                    sb.Append(" ");
                }
                sb.AppendLine();
            }
            
            Console.Write(sb.ToString());
        }

        public static void Draw(int width, int height, char borda, ConsoleColor fg = ConsoleColor.White)
        {
            /**
            *   vl = vertical line
            *   hl = horizontal line
            *   trc = top-right corner
            *   tlc = top-left corner
            *   brc = bottom-right corner
            *   blc = bottom-left corner
            **/

            char vl = ' ', hl = ' ', trc = ' ', tlc = ' ', brc = ' ', blc = ' ';
            switch (borda)
            {
                case 'd':
                    vl = '║';
                    trc = '╗';
                    brc = '╝';
                    tlc = '╔';
                    blc = '╚';
                    hl = '═';
                    break;
                case 's':
                    vl = '│'; // 179
                    trc = '┐'; //191
                    brc = '┘'; //217
                    tlc = '┌'; //218
                    blc = '└'; // 192
                    hl = '─'; // 196
                    break;
                default:
                    break;
            }

            //Top line
            SetCursorPosition((WindowWidth/2)-(width/2),WindowHeight/2-height/2);
            for (int x = 0; x < width; x++) 
            {
                ForegroundColor = fg;
                Write(hl);
                ForegroundColor = ConsoleColor.White;
            }

            //Columns
            for (int y = 0; y < height; y++)
            {
                ForegroundColor = fg;
                SetCursorPosition(WindowWidth/2-width/2,WindowHeight/2-height/2+y); Write(vl);
                ForegroundColor = ConsoleColor.White;
                ForegroundColor = fg;
                SetCursorPosition(WindowWidth/2+width/2,WindowHeight/2-height/2+y); Write(vl);
                ForegroundColor = ConsoleColor.White;
            }

            //Bottom Line
            SetCursorPosition(WindowWidth/2-(width/2),WindowHeight/2+height/2);
            for (int x = 0; x < width; x++) 
            {
                ForegroundColor = fg;
                Write(hl);
                ForegroundColor = ConsoleColor.White;
            }

            //Corners
            SetCursorPosition(WindowWidth/2-(width/2),WindowHeight/2-height/2);
            ForegroundColor = fg;
            Write(tlc);
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(WindowWidth/2+width/2,WindowHeight/2-height/2);
            ForegroundColor = fg;
            Write(trc);
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(WindowWidth/2-(width/2),WindowHeight/2+height/2);
            ForegroundColor = fg;
            Write(blc);
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(WindowWidth/2+width/2,WindowHeight/2+height/2);
            ForegroundColor = fg;
            Write(brc);
            ForegroundColor = ConsoleColor.White;
        }
    }
}