using CourseWorkStore.Models;
using CourseWorkStore.Pages.Helpers;
using System;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;

namespace CourseWorkStore.Controls
{
    public partial class CartSummary : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart myCart = SessionHelper.GetCart(Session);
            csQuantity.InnerText = myCart.Lines.Sum(x => x.Quantity).ToString();
            csTotal.InnerText = myCart.ComputeTotalValue().ToString("c");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart",
                null).VirtualPath;
        }
    }
}