using BespokedBikes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using BespokedBikes.Data;

namespace BespokedBikes.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(); //sql connection
        SqlCommand com = new SqlCommand(); //sql command
        SqlDataReader dr;

        // create data model object with different lists 
        DataModel dm = new DataModel();

        private readonly ApplicationDBContext _db;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = BespokedBikes.Properties.Resources.ConnectionString; 

        }

        public IActionResult Index()
        {
            dm.customers = new List<Customer>();
            dm.salespeople = new List<Salesperson>();
            dm.products = new List<Product>();
            dm.sales = new List<Sale>();

            FetchData();
            return View(dm);
        }

        public IActionResult Create()
        {
            //IEnumerable<Sale> saleList = _db.;
            var saleVM = new Sale();
            return View(saleVM);
        }

        public IActionResult CreateSale(Sale sale)
        {
            //return View(Index());
            return RedirectToAction(nameof(Index));
        }


        // -------------------------------------------------------------------Method to fetch data -------------------------------------------------------------------

        private void FetchData(){
            //this fetches all the salespeople to display 
            //if(dm.salespeople.Count > 0)
            //{
            //    dm.salespeople.Clear();
            //}
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [SalesPersonID] ,[FirstName],[LastName],[SalesPersonAddress] ,[Phone],[StartDate] ,[TerminationDate] ,[Manager]FROM[dbo].[Salesperson]";
                dr = com.ExecuteReader();
                while(dr.Read()){
                    {
                        dm.salespeople.Add(new Salesperson()
                        {
                            SalesPersonID = (int)dr["SalesPersonID"],
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            SalesPersonAddress = dr["SalesPersonAddress"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            StartDate = dr["StartDate"].ToString(),
                            TerminationDate = dr["TerminationDate"].ToString(),
                            Manager = dr["Manager"].ToString()

                        });
                    }
                }
            } catch(Exception ex)
            {
                throw ex; 
            }
            con.Close();

            // this is fetching data from customers 
            if (dm.customers.Count > 0)
            {
                dm.customers.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [CustomerID],[FirstName],[LastName],[Phone],[CustomerAddress],[StartDate]FROM[dbo].[Customer]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    {
                        dm.customers.Add(new Customer()
                        {
                            CustomerID = (int)dr["CustomerID"],
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            CustomerAddress = dr["CustomerAddress"].ToString(),
                            StartDate = dr["StartDate"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();

 
            // this is fetching data from products 
            if (dm.products.Count > 0)
            {
                dm.products.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [ProductID], [ProductName], [Manufacturer], [Style], [PurchasePrice], [SalePrice], [QtyOnHand], [CommisionPercentage] FROM[dbo].[Products]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    {
                        dm.products.Add(new Product()
                        {
                            ProductID = (int)dr["ProductID"],
                            ProductName = dr["ProductName"].ToString(),
                            Manufacturer = dr["Manufacturer"].ToString(),
                            Style = dr["Style"].ToString(),
                            PurchasePrice = (decimal)dr["PurchasePrice"],
                            SalePrice = (decimal)dr["SalePrice"],
                            QtyOnHand = (int)dr["QtyOnHand"],
                            CommisionPercentage = (int)dr["CommisionPercentage"]

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();

            // this is fetching data from sales 
            if (dm.sales.Count > 0)
            {
                dm.sales.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [SaleID],[ProductID],[SalesPersonID],[CustomerID],[SalesDate]FROM[dbo].[Sales]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    {
                        dm.sales.Add(new Sale()
                        {
                            SaleID = (int)dr["SaleID"],
                            ProductID = (int)dr["ProductID"],
                            SalesPersonID = (int)dr["SalesPersonID"],
                            CustomerID = (int)dr["CustomerID"],
                            SalesDate = dr["SalesDate"].ToString()

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
        }

        // -------------------------------------------------------------------Method to fetch data ends-------------------------------------------------------------------

        //public ActionResult UpdateSalesPerson(int? id)
        //{

        //}

        //public async Task<int> Update( entity)
        //{

        //    entity. = DateTime.Now;
        //    dbContext.Update(entity);
        //    return await dbContext.SaveChangesAsync();
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}