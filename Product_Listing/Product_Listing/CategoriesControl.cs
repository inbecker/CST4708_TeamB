using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Product_Listing.Data;

namespace Product_Listing
{
    public partial class CategoriesControl : UserControl
    {
        private IDictionary<string, List<int>> categoryNameWithId = new Dictionary<string, List<int>>
        {
            {"IrishAle",new List<int>{ 3805, 4084, 4560 } },
            {"AmericanAle",new List<int>{ 3788, 3792, 3794 } },
            {"AmericanLager",new List<int>{ 3784, 3785, 3790 } },
            {"BelgianAndFrenchAle",new List<int>{ 3797, 3976, 3977 } },
            {"BritishAle",new List<int>{ 3793, 3979, 4079 } },
            {"OtherStyles",new List<int>{ 3789, 3791, 3799 } },
        };
        
        public CategoriesControl()
        {
            InitializeComponent();
        }

        public void InitData()
        {
        }

        public void ShowCategories()
        {
            this.panel9.Visible = true;
            this.beersViewControl.Visible = false;
        }
        public void ShowSpecificBeer()
        {
            this.panel9.Visible = false;
            this.beersViewControl.Visible = true;
        }

        private void beerCategory_Click(object sender, EventArgs e)
        {
            ShowSpecificBeer();
            ProductContext context = new ProductContext();
            var categoryName = ((Button)sender).Tag as string;
            var idList = this.categoryNameWithId[categoryName];
            this.beersViewControl.SetBeer(context.GetBeers(idList, categoryName));
        }
    }
}
