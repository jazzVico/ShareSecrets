using System;

namespace ShareSecrets.Models 
{
    public class Secret
    {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Text { get; set; }
    }
}