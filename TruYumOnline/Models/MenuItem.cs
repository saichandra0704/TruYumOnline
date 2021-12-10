using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;



namespace TruYumOnline.Models

{

    public class MenuItem

    {

        public int MeId { get; set; }



        [Required(ErrorMessage = "Name is required")]

        [Display(Name = "Menu Name")]

        public string MeName { get; set; }



        [Required(ErrorMessage = "Price is required")]

        [Display(Name = "Price")]

        public decimal MePrice { get; set; }



        [Required(ErrorMessage = "Active is required")]

        [Display(Name = "Active")]

        public string MeActive { get; set; }



        [Required(ErrorMessage = "Launch Date is required")]

        [Display(Name = "Launch Date")]

        public DateTime? MeDateOfLaunch { get; set; }



        [Required(ErrorMessage = "Category is required")]

        [Display(Name = "Category")]

        public string MeCategory { get; set; }



        [Required(ErrorMessage = "Free Delivery Field is required")]

        [Display(Name = "Free Delivery")]

        public string MeFreeDelivery { get; set; }



        public virtual ICollection<Cart> Carts { get; set; }

    }

}