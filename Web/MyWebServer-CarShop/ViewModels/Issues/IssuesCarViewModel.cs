namespace CarShop.ViewModels.Issues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class IssuesCarViewModel
    {
        public string CarId { get; set; }

        public bool IsCurrentUserMechanic { get; set; }

        public int Year { get; set; }

        public string Model { get; set; }

        public ICollection<IssueViewModel> Issues { get; set; } = new HashSet<IssueViewModel>();
    }
}
