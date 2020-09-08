using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace doc_reviewer_1._2
{
    class SuperLinkLabel : LinkLabel
    {
        public bool IgnoreCase { get; set; }

        private string keyWord = "";

        public string Keyword
        {
            get { return keyWord; }
            set { keyWord = value; this.Invalidate(); }
        }

        public Color KeywordColor { get; set; }

        public SuperLinkLabel()
        {
            if (keyWord == "")
            {
                KeywordColor = Color.Green;
            }
            else
            {
                KeywordColor = Color.Red;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), e.ClipRectangle);
            StringFormat stringFormat = new StringFormat();
            stringFormat.SetMeasurableCharacterRanges(GetRanges());
            stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            Region[] regions = e.Graphics.MeasureCharacterRanges(Text,
                Font,
                new RectangleF(this.ClientRectangle.X,
                    this.ClientRectangle.Y,
                    4000,
                    4000),
                stringFormat);

            e.Graphics.DrawString(Text,
                    Font,
                    new SolidBrush(LinkColor),
                    new Point(this.ClientRectangle.X, this.ClientRectangle.Y),
                    stringFormat);

            int i = 0;
            foreach (var item in GetStringRgn().ToList())
            {
                bool isKeyword = GetStringRgn().First(x => x.Item1 == item.Item1).Item3;
                if (isKeyword)
                {
                    PointF ptf = new PointF(regions[i].GetBounds(e.Graphics).X - 3,
                                    regions[i].GetBounds(e.Graphics).Y);
                    e.Graphics.FillRegion(new SolidBrush(BackColor), regions[i]);
                    e.Graphics.DrawString(Text.Substring(item.Item1, item.Item2 - item.Item1 + 1),
                        Font,
                        new SolidBrush(KeywordColor),
                        ptf,
                        stringFormat);
                }
                i++;
            }
        }

        private CharacterRange[] GetRanges()
        {
            return GetStringRgn().ToArray().Select(x => new CharacterRange(x.Item1, x.Item2 - x.Item1 + 1)).ToArray();
        }

        private IEnumerable<Tuple<int, int, bool>> GetStringRgn()
        {
            string[] key = keyWord.Split(',');
            for (int j = 0; j < key.Length; j++)
            {
                if (key[j] == "" || Text == "")
                {
                    if (Text == "") yield break;
                    yield return new Tuple<int, int, bool>(0, Text.Length - 1, false);
                    yield break;
                }
                int pre = 0;
                int i = 0;
                while (i <= Text.Length - key[j].Length)
                {
                    if (Text.Substring(i, key[j].Length).ToUpper() == key[j].ToUpper())
                    {
                        if (IgnoreCase || Text.Substring(i, key[j].Length) == key[j])
                        {
                            if (pre != i) yield return new Tuple<int, int, bool>(pre, i - 1, false);
                            yield return new Tuple<int, int, bool>(i, i + key[j].Length - 1, true);
                            i += key[j].Length;
                            pre = i;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
                if (pre <= Text.Length - 1) yield return new Tuple<int, int, bool>(pre, Text.Length - 1, false);
            }

            //    if (keyWord == "" || Text == "")
            //    {
            //        if (Text == "") yield break;
            //        yield return new Tuple<int, int, bool>(0, Text.Length - 1, false);
            //        yield break;
            //    }
            //    int pre = 0;
            //    int i = 0;
            //    while (i <= Text.Length - keyWord.Length)
            //    {
            //        if (Text.Substring(i, keyWord.Length).ToUpper() == keyWord.ToUpper())
            //        {
            //            if (IgnoreCase || Text.Substring(i, keyWord.Length) == keyWord)
            //            {
            //                if (pre != i) yield return new Tuple<int, int, bool>(pre, i - 1, false);
            //                yield return new Tuple<int, int, bool>(i, i + keyWord.Length - 1, true);
            //                i += keyWord.Length;
            //                pre = i;
            //            }
            //            else
            //            {
            //                i++;
            //            }
            //        }
            //        else
            //        {
            //            i++;
            //        }
            //    }
            //    if (pre <= Text.Length - 1) yield return new Tuple<int, int, bool>(pre, Text.Length - 1, false);
            //}

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
