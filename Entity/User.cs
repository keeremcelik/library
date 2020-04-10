using System;

namespace Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public bool isApproved { get; set; }

    }
}
