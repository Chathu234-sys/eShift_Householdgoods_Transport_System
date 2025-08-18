using MimeKit.Text;
using System;

namespace eShiftCompany
{
    internal class TextPart
    {
        private string v;
        private TextFormat plain;

        public TextPart(string v)
        {
            this.v = v;
        }

        public TextPart(TextFormat plain)
        {
            this.plain = plain;
        }

        public string Text { get; set; }

        public static implicit operator string(TextPart v)
        {
            throw new NotImplementedException();
        }
    }
}