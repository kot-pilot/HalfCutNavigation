using System.Drawing;
using System.Runtime.InteropServices;

namespace Core
{
    public class HalfMoveCaretService
    {
        [DllImport("user32")]
        private extern static int GetCaretPos(out Point p);
        [DllImport("user32")]
        private extern static int SetCaretPos(int x, int y);

        public void HalfMoveRight()
        {
            GetCaretPos(out Point caretPos);
        }

        public void HalfMoveLeft()
        {
        }
    }
}
