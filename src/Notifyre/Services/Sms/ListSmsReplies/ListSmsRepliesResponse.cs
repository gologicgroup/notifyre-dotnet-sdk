using System;
using System.Collections.Generic;

namespace Notifyre
{
    public class ListSmsRepliesResponse
    {
        public List<SmsReplyDto> SmsReplies { get; set; }

        public class SmsReplyDto
        {
            public Guid RecipientID { get; set; }

            public string RecipientNumber { get; set; }

            public string SenderNumber { get; set; }

            public string ReplyID { get; set; }

            public string Message { get; set; }

            public long ReceivedDateUtc { get; set; }

            public ContactDetailsDto ContactDetails { get; set; }

        }

        public class ContactDetailsDto
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Organization { get; set; }

        }
    }
}
