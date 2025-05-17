namespace BlazorApp3.Data
{
    public partial class Product
    {
        public int InStac 
        {
            get
            {
                int colvo = 0;
               var Stotage = ProductInStorages.Where(el => el.Storage.TypeStorageId == 1).ToList();

                foreach (var item in Stotage) 
                {
                    colvo += item.Quantaty;
                }

                return colvo;
            }
        }


        public int InMob
        {
            get
            {
                int colvo = 0;
                var Stotage = ProductInStorages.Where(el => el.Storage.TypeStorageId == 2).ToList();

                foreach (var item in Stotage)
                {
                    colvo += item.Quantaty;
                }

                return colvo;
            }
        }




        public int All
        {
            get
            {
                return InStac + InMob;
            }
        }
    }
}
