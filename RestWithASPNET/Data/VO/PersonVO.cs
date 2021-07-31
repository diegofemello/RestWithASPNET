using RestWithASPNET.Model.Base;

namespace RestWithASPNET.Data.VO
{

    public class PersonVO : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string Address { get; set; }

        public string Gender { get; set; }
    }
}
