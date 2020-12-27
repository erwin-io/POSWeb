using System;

namespace POSWeb.POSAdmin.Data.Entity
{
    public class EntityInformationModel
    {
        public string LegalEntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public long LocationId { get; set; }
    }
}
