using System;

namespace eShiftCompany
{
    internal class MailboxAddress
    {
        private string fromName;
        private string fromEmail;
        private string email;

        public MailboxAddress(string email)
        {
            this.email = email;
        }

        public MailboxAddress(string fromName, string fromEmail)
        {
            this.fromName = fromName;
            this.fromEmail = fromEmail;
        }

        public string Address { get; internal set; }

        internal static object Parse(string v)
        {
            throw new NotImplementedException();
        }
    }
}