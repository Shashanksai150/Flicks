using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayerLib;
using EntityLayerLib;
using ExceptionLib;

namespace ConsoleUI_Flicks
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your choice");
            Console.WriteLine("1.Customer Login");
            Console.WriteLine("2.Customer registration");
            Console.WriteLine("3.Admin Login");
            int choice = Int32.Parse(Console.ReadLine());
            CustomerBLL cb = new CustomerBLL();
            MovieBLL mb = new MovieBLL();
            MovieRentalBLL mr = new MovieRentalBLL();
            CurrentlyRentedBLL cr = new CurrentlyRentedBLL();
            do
            {
                switch (choice)
                {
                    case 1:
                        int ch;
                        Console.WriteLine("Redirecting to Login page....");
                        Console.WriteLine("-----------*********---------");
                        CustomerLogin();
                        do
                        {
                            
                            Console.WriteLine("Enter a choice");
                            Console.WriteLine("1.Rent a Movie");
                            Console.WriteLine("2.Update my Profile");
                            Console.WriteLine("3.Change Password");
                            Console.WriteLine("4.See my currently rented movies");
                            //Console.WriteLine("4.Check my due amount");
                            Console.WriteLine("5.See my previously rented movies");
                            Console.WriteLine("6.Delete my account");
                            ch = Int32.Parse(Console.ReadLine());

                            switch (ch)
                            {

                                case 1:
                                    {
                                        char ch2;
                                        do
                                        {
                                            Console.WriteLine("Enter a choice");
                                            Console.WriteLine("a.See all movies");
                                            Console.WriteLine("b.Search a movie by title or Language or Genres");
                                            Console.WriteLine("c.Search a movie by Movie ID");
                                            Console.WriteLine("d.Search a movie by ID");
                                            Console.WriteLine("e.Search a movie by Year");
                                            Console.WriteLine("f.Get all top rated movies");
                                            Console.WriteLine("z.Exit");
                                            ch2 = Console.ReadKey().KeyChar;

                                            switch (ch2)
                                            {
                                                case 'a':
                                                    GetAllMovies();
                                                    Console.ReadLine();
                                                    addAcurrentlyrented();

                                                    break;
                                                case 'b':
                                                    GetAllmoviesbyTLG();
                                                    Console.ReadLine();
                                                    addAcurrentlyrented();
                                                    break;
                                                case 'c':
                                                    GetmovieById();
                                                    Console.ReadLine();
                                                    addAcurrentlyrented();
                                                    break;
                                                case 'd':
                                                    GetmovieById();
                                                    Console.ReadLine();
                                                    addAcurrentlyrented();
                                                    break;
                                                case 'e':
                                                    GetmovieByYear();
                                                    Console.ReadLine();
                                                    addAcurrentlyrented();
                                                    break;
                                                case 'f':
                                                    GetAllTopRatedMovies();
                                                    Console.ReadLine();
                                                    addAcurrentlyrented();
                                                    break;
                                                case 'z':
                                                    Console.WriteLine("Exit");
                                                    break;
                                                default:
                                                    Console.WriteLine("Invalid choice , Re-Enter a vaid choice");
                                                    break;

                                            }
                                        } while (ch2 != 'z');
                                    }
                                    break;
                                case 2:
                                    UpdateCustomer();
                                    break;
                                case 3:
                                    CustomerpasswordReset();
                                    break;
                                case 4:
                                    GetAllCurrentlyRented();
                                    break;
                                case 5:
                                    GetAllPreviouslyRented();
                                    break;
                                case 6:
                                    DeleteCustomer();
                                    break;
                                case 0:
                                    Console.WriteLine("Exit");
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice.");
                                    Console.WriteLine("Enter a valid choice");
                                    break;
                            }
                        } while (ch != 0);
                        break;
                    case 2:
                        RegisterCustomer();
                        choice = 5;
                        break;
                    case 3:
                        int ch3;
                        do
                        {
                            Console.WriteLine("-----------*********---------");
                            Console.WriteLine("Enter a choice");
                            Console.WriteLine("1.Add a Movie");
                            Console.WriteLine("2.Update a Movie");
                            Console.WriteLine("3.Delete a Movie");
                            Console.WriteLine("4.Find Customer");
                            Console.WriteLine("5.See my currently rented movies");
                            Console.WriteLine("6.Log a rent amount");
                            Console.WriteLine("7.Log a movie return ");
                            Console.WriteLine("8.Add a new Admin account");
                            ch3 = Int32.Parse(Console.ReadLine());

                            switch (ch3)
                            {
                                case 1:
                                    //AddAMOVIE
                                    AddaMovie();
                                    break;
                                case 2:
                                    UpdateaMovie();
                                    break;
                                case 3:
                                    DeleteaMovie();
                                    break;
                                case 4:
                                    FindCustomer();
                                    break;
                                case 5:
                                    GetAllCurrentlyRented();
                                    break;
                                case 6:
                                    LogARentPayment();
                                    break;
                                case 7:
                                    LogAMovieReturn();
                                    break;
                                case 8:
                                    AddAAdmin();
                                    break;
                                case 0:
                                    Console.WriteLine("Exit");
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice.");
                                    Console.WriteLine("Enter a valid choice");
                                    break;
                            }
                        } while (ch3 != 0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        Console.WriteLine("Enter a valid choice");
                        break;
                }

            } while (choice < 4);

            Console.ReadLine();

        }
         
        public static void CustomerLogin()
        {
            try
            {
                Console.WriteLine("Enter Number and Password");
                string n = Console.ReadLine();
                string p = Console.ReadLine();
                CustomerBLL cb = new CustomerBLL();
                Customers c = cb.GetCustomer(n);

                
                if (c == null)
                {
                    Console.WriteLine("Login unsuccessful");
                }
                else if (c.Password == p && c.MobileNumber == n)
                {
                    Console.WriteLine("Login Successful");
                }
                else 
                {
                    Console.WriteLine("Login unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void AdminLogin()
        {
            try
            {
                Console.WriteLine("Enter Number and Password");
                string n = Console.ReadLine();
                string p = Console.ReadLine();
                AdminBLL bll = new AdminBLL();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void GetAllMovies()
        {
            try
            {
                List<Movie> list = new List<Movie>();
                MovieBLL mb = new MovieBLL();
                list = mb.GetAllMovies();
                Console.WriteLine("List of all the Movies: ");

                if (list.Count == 0)
                {
                    Console.WriteLine("Could not find any Movie record");
                }
                else
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    foreach (Movie movie in list)
                    {
                        Console.WriteLine("Movie ID: " + movie.MovieID);
                        Console.WriteLine("Movie Title: " + movie.Title);
                        Console.WriteLine("Movie year: " + movie.Year);
                        Console.WriteLine("Movie Language: " + movie.Language);
                        Console.WriteLine("Movie Genres: " + movie.Genres);
                        Console.WriteLine("Movie Rating: " + movie.Rating);
                        Console.WriteLine("Movie BLueray price: " + movie.Bluerayprice);
                        Console.WriteLine("Movie Total stock: " + movie.TotalUnitsrented);
                        Console.WriteLine("----------------------------------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void GetAllmoviesbyTLG()
        {
            try
            {

                string v = Console.ReadLine();
                MovieBLL mb = new MovieBLL();
                List<Movie> list = new List<Movie>();
                list = mb.GetAllMoviesByTLG(v);
                Console.WriteLine("List of all the Movies: ");

                if (list.Count == 0)
                {
                    Console.WriteLine("Could not find any Movie record");
                }
                else
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    foreach (Movie movie in list)
                    {
                        Console.WriteLine("Movie ID: " + movie.MovieID);
                        Console.WriteLine("Movie Title: " + movie.Title);
                        Console.WriteLine("Movie year: " + movie.Year);
                        Console.WriteLine("Movie Language: " + movie.Language);
                        Console.WriteLine("Movie Genres: " + movie.Genres);
                        Console.WriteLine("Movie Rating: " + movie.Rating);
                        Console.WriteLine("Movie BLueray price: " + movie.Bluerayprice);
                        Console.WriteLine("Movie Total stock: " + movie.TotalUnitsrented);
                        Console.WriteLine("----------------------------------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void GetmovieByYear()
        {                       
            try
            {
                int i = int.Parse(Console.ReadLine());
                MovieBLL mb = new MovieBLL();
                List<Movie> list = new List<Movie>();
                list = mb.GetAllMoviesByYear(i);
                Console.WriteLine("List of all the Movies: ");

                if (list.Count == 0)
                {
                    Console.WriteLine("Could not find any Movie record");
                }
                else
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    foreach (Movie movie in list)
                    {
                        Console.WriteLine("Movie ID: " + movie.MovieID);
                        Console.WriteLine("Movie Title: " + movie.Title);
                        Console.WriteLine("Movie year: " + movie.Year);
                        Console.WriteLine("Movie Language: " + movie.Language);
                        Console.WriteLine("Movie Genres: " + movie.Genres);
                        Console.WriteLine("Movie Rating: " + movie.Rating);
                        Console.WriteLine("Movie BLueray price: " + movie.Bluerayprice);
                        Console.WriteLine("Movie Total stock: " + movie.TotalUnitsrented);
                        Console.WriteLine("----------------------------------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void GetmovieById()
        {
            try
            {
                var p = Console.ReadLine();
                Movie movie = new Movie();
                MovieBLL mb = new MovieBLL();
                movie = mb.GetMovie(p);
                if (movie == null)
                {
                    Console.WriteLine("Movie not found in the recoreds");
                }
                else
                {
                    Console.WriteLine("Movie ID: " + movie.MovieID);
                    Console.WriteLine("Movie Title: " + movie.Title);
                    Console.WriteLine("Movie year: " + movie.Year);
                    Console.WriteLine("Movie Language: " + movie.Language);
                    Console.WriteLine("Movie Genres: " + movie.Genres);
                    Console.WriteLine("Movie Rating: " + movie.Rating);
                    Console.WriteLine("Movie BLueray price: " + movie.Bluerayprice);
                    Console.WriteLine("Movie Total stock: " + movie.TotalUnitsrented);
                }
                }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void GetAllTopRatedMovies()
        {
            try
            {
                
                MovieBLL mb = new MovieBLL();
                List<Movie> list = new List<Movie>();
                list = mb.GetAllTop10Movies();
                Console.WriteLine("List of all the Movies: ");

                if (list.Count == 0)
                {
                    Console.WriteLine("Could not find any employee record");
                }
                else
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    foreach (Movie movie in list)
                    {
                        Console.WriteLine(movie.Mnum);
                        Console.WriteLine("Movie ID: "+movie.MovieID);
                        Console.WriteLine("Movie Title: " + movie.Title);
                        Console.WriteLine("Movie year: " + movie.Year);
                        Console.WriteLine("Movie Language: " + movie.Language);
                        Console.WriteLine("Movie Genres: " + movie.Genres);
                        Console.WriteLine("Movie Rating: " + movie.Rating);
                        Console.WriteLine("Movie BLueray price: " + movie.Bluerayprice);
                        Console.WriteLine("Movie Total stock: " + movie.TotalUnitsrented);
                        Console.WriteLine("----------------------------------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void UpdateCustomer()
        {
            try
            {
                Customers c = new Customers();
                Console.WriteLine("Enter Number");
                c.MobileNumber = Console.ReadLine();
                Console.WriteLine("Enter Password");
                c.Password = Console.ReadLine();
                Console.WriteLine("Enter Name");
                c.Name = Console.ReadLine();
                Console.WriteLine("Enter Address");
                c.Address = Console.ReadLine();
                Console.WriteLine("Enter City");
                c.City = Console.ReadLine();
                Console.WriteLine("Enter Region");
                c.Region = Console.ReadLine();
                Console.WriteLine("Enter Postal code");
                c.PostalCode = Console.ReadLine();
                Console.WriteLine("Enter Country");
                c.Country = Console.ReadLine();

                CustomerBLL cb = new CustomerBLL();
                var status = cb.UpdateCustomer(c);
                if (status)
                {
                    Console.WriteLine("Customer Updated Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not Update the Customer");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RegisterCustomer()
        {
            try
            {
                Customers c = new Customers();
                Console.WriteLine("Enter Number");
                c.MobileNumber = Console.ReadLine();
                Console.WriteLine("Enter Password");
                c.Password = Console.ReadLine();
                Console.WriteLine("Enter Name");
                c.Name = Console.ReadLine();              
                Console.WriteLine("Enter EmailID");
                c.EmailID = Console.ReadLine();
                Console.WriteLine("Enter Category");
                c.Category = Console.ReadLine();
                Console.WriteLine("Enter Address");
                c.Address = Console.ReadLine();
                Console.WriteLine("Enter City");
                c.City = Console.ReadLine();
                Console.WriteLine("Enter Region");
                c.Region = Console.ReadLine();
                Console.WriteLine("Enter Postal code");
                c.PostalCode = Console.ReadLine();
                Console.WriteLine("Enter Country");
                c.Country = Console.ReadLine();

                CustomerBLL cb = new CustomerBLL();
                var status = cb.AddNewCustomer(c);
                if (!status)
                {
                    Console.WriteLine("Customer Added Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not add the Customer");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CustomerpasswordReset()
        {
            try
            {
                Console.WriteLine("Enter Number");
                string n = Console.ReadLine();
                Console.WriteLine("Enter new Password");
                string p = Console.ReadLine();
                CustomerBLL cb = new CustomerBLL();
                Customers c = cb.GetCustomer(n);
                c.Password = p;
                
                var status = cb.UpdateCustomer(c);
                if (status)
                {
                    Console.WriteLine("Customer Password reseted Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not reset the Customer Password");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void GetAllCurrentlyRented()
        {
            try
            {
                Console.WriteLine("Enter Number");
                string num = Console.ReadLine();
                CurrentlyRentedBLL cr = new CurrentlyRentedBLL();
                List<CurrentlyRented> lists = new List<CurrentlyRented>();
                lists = cr.GetAllMoviesRentedByMobileNumber(num);
                if (lists.Count == 0)
                {
                    Console.WriteLine("Could not find any currently rented movies record");
                }
                else
                {
                    foreach (CurrentlyRented b in lists)
                    {
                        Console.WriteLine("Rent ID: " + b.RentID);
                        Console.WriteLine("Movie ID: "+b.MID);
                        Console.WriteLine("Mobile number: "+b.MobileNumber);
                        Console.WriteLine("Rented DT: "+b.RentedDateTime);
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetAllPreviouslyRented()
        {
            try
            {
                Console.WriteLine("Enter Number");
                string num = Console.ReadLine();
                MovieRentalBLL bll = new MovieRentalBLL();
                List<MoviesRented> lists = new List<MoviesRented>();
                lists = bll.GetAllMoviesRentedByMobileNumber(num);
                if (lists.Count == 0)
                {
                    Console.WriteLine("Could not find any currently rented movies record");
                }
                else
                {
                    foreach (MoviesRented b in lists)
                    {
                        Console.WriteLine("Rent ID: " + b.RentID);
                        Console.WriteLine("Movie ID: " + b.MID);
                        Console.WriteLine("Mobile number: " + b.MobileNumber);
                        Console.WriteLine("Rented DT: " + b.RentedDateTime);
                        Console.WriteLine("Returned DT: " + b.ReturnedDateTime);
                        Console.WriteLine("Days rented: " + b.DaysRented);
                        Console.WriteLine("Rent amount: " + b.RentAmount);
                        Console.WriteLine("Returned: " + b.Returned);
                        Console.WriteLine("Paid or not: " + b.PaidorNot);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteCustomer()
        {
            try
            {
                Console.WriteLine("Enter Number");
                string num = Console.ReadLine();
                //string number = Console.ReadLine();
                CustomerBLL customer = new CustomerBLL();
                var status = customer.DeleteCustomer(num);
                if (status)
                {
                    Console.WriteLine("Customer deleted Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not delete the Customer record");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddaMovie()
        {
            try
            {

                Movie movie = new Movie();
                Console.WriteLine("Enter Title");
                movie.Title = Console.ReadLine();
                Console.WriteLine("Enter Laguage");
                movie.Language = Console.ReadLine();
                Console.WriteLine("Enter Genres");
                movie.Genres = Console.ReadLine();
                Console.WriteLine("Enter Year");
                movie.Year = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Blueray price");
                movie.Bluerayprice = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Rating");
                movie.Rating = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter Totsl stock");
                movie.TotalStock = int.Parse(Console.ReadLine());
                MovieBLL bll = new MovieBLL();
                var status = bll.AddNewMovie(movie);
                if (status)
                {
                    Console.WriteLine("Movie added Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not add the Movie record");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateaMovie()
        {
            try
            {

                Movie movie = new Movie();
                Console.WriteLine("Enter Movie ID");
                movie.MovieID = Console.ReadLine();
                Console.WriteLine("Enter Title");
                movie.Title = Console.ReadLine();
                Console.WriteLine("Enter Laguage");
                movie.Language = Console.ReadLine();
                Console.WriteLine("Enter Genres");
                movie.Genres = Console.ReadLine();
                Console.WriteLine("Enter Year");
                movie.Year = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Blueray price");
                movie.Bluerayprice = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Rating");
                movie.Rating = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter Totsl stock");
                movie.TotalStock = int.Parse(Console.ReadLine());
                MovieBLL bll = new MovieBLL();
                var status = bll.UpdateMovie(movie);
                if (status)
                {
                    Console.WriteLine("Movie Updated Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not Update the Movie");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteaMovie()
        {
            try
            {
                Console.WriteLine("Enter Movie ID");
                string mid = Console.ReadLine();
                MovieBLL bll = new MovieBLL();
                var status = bll.DeleteMovie(mid);
                if (status)
                {
                    Console.WriteLine("Movie deleted Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not delete the Movie record");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FindCustomer()
        {
            try
            {
                Console.WriteLine("Enter Number");
                string number = Console.ReadLine();
                CustomerBLL bll = new CustomerBLL();
                Customers customer = new Customers();
                customer = bll.GetCustomer(number);
                if (customer != null)
                {
                    Console.WriteLine("Name: " + customer.Name); 
                    Console.WriteLine("Mobile number: " + customer.MobileNumber);
                    Console.WriteLine("Catogery: " + customer.Category);
                    Console.WriteLine("Address: " + customer.Address);
                    Console.WriteLine("City: " + customer.City);
                    Console.WriteLine("Region: " + customer.Region);
                    Console.WriteLine("Postal code: " + customer.PostalCode);
                    Console.WriteLine("Country: " + customer.Country);
                }
                else { Console.WriteLine("COULD NOT FIND THE CUSTOMER"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void LogARentPayment()
        {
            try
            {
                MovieRentalBLL bll = new MovieRentalBLL();
                MoviesRented cr = new MoviesRented();
                Console.WriteLine("Enter Rent ID");
                cr.RentID = Console.ReadLine();
                
                cr.Returned = true;
                
                Console.WriteLine("Logging a rent payment");
                cr.PaidorNot = true; 

                
                var status = bll.UpdateMoviesRented(cr);
                if (!status)
                {
                    Console.WriteLine("Rent payment logged Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not log the rent payment");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void LogAMovieReturn()
        {
            try
            {
                MovieRentalBLL bll = new MovieRentalBLL();
                MoviesRented cr = new MoviesRented();
                Console.WriteLine("Enter Rent ID");
                cr.RentID = Console.ReadLine();
                
                Console.WriteLine("Logging a movie return");
                cr.Returned = true;

                var status = bll.UpdateMoviesRented(cr);
                if (!status)
                {
                    Console.WriteLine("Movie returned Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not return the Movie");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddAAdmin()
        {
            try
            {
                Admin admin = new Admin();
                Console.WriteLine("Enter Admin ID");
                admin.AdminID = Console.ReadLine();
                Console.WriteLine("Password");
                admin.password = Console.ReadLine();
                Console.WriteLine("Admin Name");
                admin.AdminName = Console.ReadLine();
                AdminBLL bll = new AdminBLL();
                var status = bll.AddNewAdmin(admin);
                if (!status)
                {
                    Console.WriteLine("Admin added Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not add the Admin record");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void addAcurrentlyrented()
        {
            try
            {
                CurrentlyRented cr = new CurrentlyRented();
                Console.WriteLine("Enter Number");
                cr.MobileNumber = Console.ReadLine();
                Console.WriteLine("Enter Movie ID");
                cr.MID = Console.ReadLine();

                CurrentlyRentedBLL bll = new CurrentlyRentedBLL();
                var status = bll.AddCurrentlyRented(cr);
                if (!status)
                {
                    Console.WriteLine("Rented a movie Successfully!!");
                }
                else
                {
                    Console.WriteLine("Could not rent the movie");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
