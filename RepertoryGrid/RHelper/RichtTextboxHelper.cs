using System.Drawing;
using System.Windows.Forms;

namespace org.lime.tree.controls.helper
{
    public static class RichtTextboxHelper
    {

        /// <summary>
        /// http://dotnet-snippets.de/snippet/farbigen-text-zu-richtextbox-hinzufuegen/1697
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="txt"></param>
        /// <param name="col"></param>
        public static void AddText(RichTextBox rtb, string txt, Color col, bool appendNewline = true)
        {
            int pos = rtb.TextLength;
            rtb.AppendText(txt);
            rtb.Select(pos, txt.Length);
            rtb.SelectionColor = col;
            rtb.Select();
            if (appendNewline) rtb.AppendText("\n");
        }

        public static void AddText(RichTextBox rtb, string txt)
        {
            AddText(rtb, txt, rtb.ForeColor);
        }



    }
}
