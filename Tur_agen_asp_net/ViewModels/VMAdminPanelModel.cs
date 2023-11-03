using Tur_agen_asp_net.Models;

namespace Tur_agen_asp_net.ViewModels
{
    public class VMAdminPanelModel
    {

      //public  VMAdminPanelModel() {
      //      //Tours = new List<Tour>();
      //      //Users = new List<Users>();
      //  }

        public List<Tour>? Tours { get; set; }
        public List<Users>? Users { get; set; }
    }
}
