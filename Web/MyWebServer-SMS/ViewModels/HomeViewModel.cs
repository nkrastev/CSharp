namespace SMS.ViewModels
{
    
    using System.Collections.Generic;   
    public class HomeViewModel
    {
        public string CurrentUsername { get; set; }

        public List<HomeProductViewModel> Products { get; set; } = new List<HomeProductViewModel>();
    }
}
