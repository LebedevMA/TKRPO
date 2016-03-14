using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace dostavka
{
    namespace Functionality
    {
        public class Order
        {
            public int PK_Order;
            public DateTime DateTime;
            public float Sum;
            public float Part;
            public float DriverMoney;
            public int Status; // 0 - ожидание, 1 - выполнение, 2 - отменен, 3 - завершен
            public String Comment;
            public String Address;
            public int Countryside;

            public List<OrderLine> Lines;

            public int PK_Driver;
            public int PK_Client;


            public Order()
            {
            }
            public static Order FromPK(OracleConnection conn, int PK, bool GetLines)
            {
                return null;
            }

            public bool LinesChangeAllowed()
            {
                return false;
            }
            public bool CafeChangeAllowed()
            {
                return false;
            }
            public bool AddressChangeAllowed()
            {
                return false;
            }
            public bool DateTimeChangeAllowed()
            {
                return false;
            }
            public bool DriverChangeAllowed()
            {
                return false;
            }
            public bool ClientChangeAllowed() {
                return false;
            }
            public bool DriverMoneyChangeAllowed()
            {
                return true;
            }
        }
        public class OrderLine
        {
            public int PK_OrderLine;
            public float Amount;
            public float Cost;
            public int PK_Dish;
            public Order Order;

            public OrderLine()
            {
            }

            public static OrderLine FromPK(OracleConnection conn, int PK)
            {
                return null;
            }
        }
        public class OrdersController
        {
            public static List<Order> GetOrdersList(OracleConnection conn, bool GetLines)
            {
                return null;
            }
            public static List<Order> GetOrdersList(OracleConnection conn, bool GetLines, int Status)
            {
                return null;
            }
            public static void AddOrder(OracleConnection conn, Order TheOrder)
            {
            }
            public static void UpdateOrder(OracleConnection conn, Order TheOrder, bool UpdateLines)
            {
            }
            public static void AddOrderLine(OracleConnection conn, Order TheOrder, OrderLine TheLine)
            {
            }
            public static void DeleteOrderLine(OracleConnection conn, OrderLine TheLine)
            {
            }
            public static void DeleteOrderLines(OracleConnection conn, Order TheOrder)
            {
            }

            public static float CountCost(OracleConnection conn, OrderLine TheLine)
            {
                return 0;
            }
            public static float CountSum(Order TheOrder, float CityTariff, float CountryTariff)
            {
                return 0;
            }
            public static float CountPart(float Sum, float Part)
            {
                return 0;
            }
        }
        public class Dish
        {
            public int PK_Dish;
            public String Name;
            public float Price;
            public int PK_Cafe;

            public Dish()
            {
            }

            public static Dish FromPK(OracleConnection conn, int PK)
            {
                return null;
            }

            public static Dish FromName(OracleConnection conn, String Name, int PK_Cafe) {
                return null;
            }

            public override string ToString()
            {
                return Name;
            }
        }
        public class DishController
        {
            public static List<Dish> GetDishList(OracleConnection conn)
            {
                return null;
            }
            public static List<Dish> GetDishList(OracleConnection conn, int PK_Cafe)
            {
                return null;
            }
        }
        public class Driver
        {
            public int PK_Driver;
            public String Name;
            public String Phone;
            public Driver()
            {
            }

            public static Driver FromPK(OracleConnection conn, int PK)
            {
                return null;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        public class DriverController
        {
            public static List<Driver> GetDriversList(OracleConnection conn)
            {
                return null;
            }
        }
        public class Client
        {
            public int PK_Client;
            public String Name;
            public String Phone;
            public int Discount;
            public Client()
            {
            }

            public static Client FromPK(OracleConnection conn, int PK)
            {
                return null;
            }

            public override string ToString()
            {
                return Name;
            }
        }
        public class ClientController
        {
            public static List<Client> GetClientsList(OracleConnection conn)
            {
                return null;
            }
            public static void AddClient(OracleConnection conn, Client TheClient)
            {
            }
            public static void UpdateClient(OracleConnection conn, Client TheClient)
            {
            }
        }
        public class Cafe {
            public int PK_Cafe;
            public String Name;
            public String Address;
            public String Phone;
            public Cafe() {
            }
            public static Cafe FromPK(OracleConnection conn, int PK)
            {
                return null;
            }
            public static Cafe FromName(OracleConnection conn, String Name)
            {
                return null;
            }
        }
        public class CafeController {
            public static List<Cafe> GetCafeList(OracleConnection conn)
            {
                return null;
            }
        }
    }
}
