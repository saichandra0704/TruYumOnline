namespace TruYumOnline.Models

{

    public class Cart

    {

        public int CtId { get; set; }

        public int? CtUsId { get; set; }

        public int? CtPrId { get; set; }



        public virtual MenuItem CtPr { get; set; }

        public virtual UserRecord CtUs { get; set; }

    }

}