using System;

namespace WebLoginRegisterApi.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
