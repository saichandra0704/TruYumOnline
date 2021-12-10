using System.Collections.Generic;



namespace TruYumOnline.Models

{

    public class UserRecord

    {

        public int UsId { get; set; }

        public string UsFname { get; set; }

        public string UsLname { get; set; }

        public string UsUsername { get; set; }

        public string UsPassword { get; set; }

        public string UsRole { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

    }

}